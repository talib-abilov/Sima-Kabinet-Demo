using EllipticCurve;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using SimaApp.Application.Constants;
using SimaApp.Application.DTOS.Sima;
using SimaApp.Application.Features.Companies.Queries.IsCompanyExists;
using SimaApp.Application.Features.Users.Queries.GetUserProfile;
using SimaApp.Application.Features.Users.Queries.GetUserProfileRolesByPIN;
using SimaApp.Application.Interfaces.Redis;
using SimaApp.Application.Interfaces.Repositories;
using SimaApp.Application.Interfaces.Tokens;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Domain.Entities;
using SimaApp.Domain.Enums;
using SimaApp.Infrastructure.Helpers;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimaApp.Infrastructure.Sima
{
    public class SimaContractService : ISimaContractService
    {
        private readonly ITokenService _tokenService;
        private readonly IMediator _mediator;
        private readonly SimaOptions _options;
        private readonly IGeneratorService _generatorService;
        private readonly IRedisService _redisService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISimaNotifier _simaNotifier;
        //private readonly IHubContext<SimaHub> _hubContext;

        public SimaContractService(IOptions<SimaOptions> options, IGeneratorService generatorService, IRedisService redisService, IHttpContextAccessor contextAccessor, IFileService fileService, IMediator mediator, ITokenService tokenService, IUnitOfWork unitOfWork, ISimaNotifier simaNotifier)
        {
            _options = options.Value;
            _generatorService = generatorService;
            _redisService = redisService;
            _contextAccessor = contextAccessor;
            _fileService = fileService;
            _mediator = mediator;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _simaNotifier = simaNotifier;
        }


        public async Task<OperationInfo> CreateOperationAsync(string operationType)
        {
            var operationId = Guid.NewGuid().ToString();

            var nbfUtc = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var expUtc = DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds();
            var operation = new OperationInfo()
            {
                OperationId = operationId,
                NbfUTC = nbfUtc,
                ExpUTC = expUtc,
                Assignee = [],
                Type = operationType
            };
            return operation;
        }
        public async Task<GenerateQrResponseDto> GenerateQR(OperationInfo operation, IFormFile? file)
        {
            string? FileName = file?.FileName;
            string? Base64File = file is not null ? await _fileService.ConvertPdfToBase64Async(file) : null;

            var transaction = new SimaTransactionCache
            {
                OperationId = operation.OperationId,
                Type = operation.Type,
                Status = SimaTransactionStatus.Created.ToString(),
                NbfUTC = operation.NbfUTC,
                ExpUTC = operation.ExpUTC,
                FileName = FileName,
                RawFile = Base64File
            };
            await _redisService.SetAsync(
                SimaRedisKeys.Transaction(operation.OperationId),
                transaction,
                TimeSpan.FromMinutes(5));

            var signableContainer = new SignableContainer
            {
                ProtoInfo = new ProtoInfo
                {
                    Name = "web2app",
                    Version = "2.0"
                },

                OperationInfo = operation,

                DataInfo = new DataInfo
                {
                    DataURI = $"https://localhost:7182/api/auth/GetData?operationId={operation.OperationId}",
                },

                ClientInfo = new SimaApp.Application.DTOS.Sima.ClientInfo
                {
                    ClientId = _options.ClientId,
                    ClientName = "Talib Abilov intern",
                    IconURI = "https://play-lh.googleusercontent.com/ksQ28-tzpYDKDRyfoTgnNIU-nDCI85q0-U18FHZTuroUK3H-ncnxw_LNf4V8FV55TuYb3iO7UYO3rkpBBxI3Zg",
                    Callback = "https://localhost:7182/api/auth/callback",
                }
            };

            string q = JsonSerializer.Serialize(signableContainer);

            byte[] checksum = CryptHelper.ComputeSha256HashAsByte(q);

            byte[] signatureBytes = CryptHelper.ComputeHmacSha256(checksum, _options.MasterKey);

            string signature = Convert.ToBase64String(signatureBytes);


            var contract = new Contract
            {
                SignableContainer = signableContainer,

                Header = new Header
                {
                    AlgName = "HMACSHA256",
                    Signature = signature
                }
            };

            string signedContractJson = JsonSerializer.Serialize(contract);

            string tsquery = Convert.ToBase64String(Encoding.UTF8.GetBytes(signedContractJson));

            var qrUrl = $"https://web2app?tsquery={Uri.EscapeDataString(tsquery)}";


            var qrImageAsString = await _generatorService.GenerateQr(qrUrl);

            var qrImageAsByte = Convert.FromBase64String(qrImageAsString);

            return new GenerateQrResponseDto
            {
                //OperationId = operation.OperationId.ToString(),
                OperationId = "5faed91f-d58d-4d19-999d-197453a0d00e",
                QrCode = qrImageAsString
            };

        }
        public async Task<GetDataResponseDto> GetData(string operationId)
        {
            //var request = _contextAccessor.HttpContext!.Request;

            //var headers = request.Headers;

            //string tsCert = headers["ts-cert"].ToString();
            //string tsSign = headers["ts-sign"].ToString();
            //string signatureAlgorithm = headers["ts-sign-alg"].ToString();

            //string dataUri = "https://localhost:7182/api/Auth/Sima/GetData";
            //string dataUri = "localhost:7096/api/v1/login/getData?operationId=9ab3b1f5-a038-45c2-af93-7b5501a5e3e6";

            //using var reader = new StreamReader(dataUri);

            //var body = await reader.ReadToEndAsync();



            //var isValid = await VerifySignature.VerifyAsync(dataUri, tsCert, tsSign, signatureAlgorithm);

            //if (!isValid)
            //{
            //    throw new UnauthorizedAccessException("Invalid SİMA get data signature.");
            //}


            SimaTransactionCache? cache = await _redisService.GetAsync<SimaTransactionCache>($"sima:transaction:{operationId}");
            if (cache == null)
            {
                throw new Exception("cache tapilmadi");
            }

            var timeNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (timeNow > cache.ExpUTC)
            {
                throw new Exception("Qr kod vaxti bitmişdir");
            }


            string dataName = "AuthData";
            string data = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(operationId));
            string operationType = cache.Type;

            if (operationType == OperationType.Sign.ToString())
            {
                dataName = cache.FileName;
                data = cache.RawFile;
            }
            return new GetDataResponseDto
            {
                SessionId = Guid.NewGuid().ToString(),
                Type = "raw",
                DataObjects = [
                    new DataObjectDto{
                        Name = dataName,
                        Data = data
                    }],
                Claims = ["idinfo"],
            };
        }

        public async Task CallBackAsync()
        {
            var request = _contextAccessor.HttpContext!.Request;

            var headers = request.Headers;

            using var reader = new StreamReader(request.Body);

            //StringBuilder sb = new StringBuilder();
            //sb.Append(await reader.ReadToEndAsync());

            //var body = sb.ToString();
            var body = await reader.ReadToEndAsync();

            string tsCert = headers["ts-cert"].ToString();
            string tsSign = headers["ts-sign"].ToString();
            string signatureAlgorithm = headers["ts-sign-alg"].ToString();

            Console.WriteLine(body);

            var isValid = await VerifySignature.VerifyAsync(body, tsCert, tsSign, signatureAlgorithm);

            if (!isValid)
            {
                throw new UnauthorizedAccessException("Invalid SİMA callback signature.");
            }

            CallbackRequestDto callbackDto = JsonSerializer.Deserialize<CallbackRequestDto>(body);

            if (callbackDto == null)
            {
                throw new InvalidOperationException("Invalid callback body.");
            }


            var type = callbackDto.type;
            CertificateObjectDto dto = CertificateParser.ParseToObject(tsCert);

            if (type == OperationType.Sign.ToString())
            {
                var userProfile = await _unitOfWork.GetReadRepository<UserProfile>().GetAsync(x=>x.User.Employee.EmployeeDocument.PIN==dto.Pin && x.Company.TIN==dto.TaxId);
                if (userProfile == null)
                {
                    throw new UnauthorizedAccessException("UserProfile tapılmadı.");
                }
                var userProfileRole = await _unitOfWork.GetReadRepository<UserProfilesRoles>().GetAsync(x => x.UserProfileId == userProfile.Id);
                if (userProfileRole == null)
                {
                    throw new UnauthorizedAccessException("Kabinetə daxil olmaq üçün hüquqi şəxsə məxsus elektron imzanız olmalıdır.");
                }
                JwtSecurityToken token = await   _tokenService.CreateToken(userProfile);
                string _token = new JwtSecurityTokenHandler().WriteToken(token);

                await _simaNotifier.SendLoginTokenAsync(callbackDto.operationId, _token);
                await _simaNotifier.SendSignedDataHashAsync(callbackDto.operationId, callbackDto.signedDataHash!);
            }
            //else if(type == OperationType.Sign.ToString())
            //{
            //    var userProfile = await _unitOfWork.GetReadRepository<UserProfile>().GetAsync(x => x.User.Employee.EmployeeDocument.PIN == dto.Pin && x.Company.TIN == dto.TaxId);
            //    if (userProfile == null)
            //    {
            //        throw new UnauthorizedAccessException("UserProfile tapılmadı.");
            //    }
            //    var userProfileRole = await _unitOfWork.GetReadRepository<UserProfilesRoles>().GetAsync(x => x.UserProfileId == userProfile.Id);
            //    if (userProfileRole == null)
            //    {
            //        throw new UnauthorizedAccessException("Kabinetə daxil olmaq üçün hüquqi şəxsə məxsus elektron imzanız olmalıdır.");
            //    }
            //    await _simaNotifier.SendSignedDataHashAsync(callbackDto.operationId, callbackDto.signedDataHash!);

            //}
        }
    }
}
