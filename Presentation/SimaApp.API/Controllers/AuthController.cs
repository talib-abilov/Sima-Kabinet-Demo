using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using SimaApp.Application.DTOS.Sima;
using SimaApp.Application.Interfaces.Redis;
using SimaApp.Application.Interfaces.Repositories;
using SimaApp.Domain.Enums;
using SimaApp.Infrastructure.Helpers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ISimaContractService _simaContractService;
        private readonly IFileService _fileService;
        private readonly IRedisService _redisService;

        public AuthController(ISimaContractService simaContractService, IHttpContextAccessor accessor, IFileService fileService, IRedisService redisService)
        {
            _simaContractService = simaContractService;
            _accessor = accessor;
            _fileService = fileService;
            _redisService = redisService;
        }

        [HttpPost("Sima/Login")]
        public async Task<IActionResult> Login()
        {
            var operation = await _simaContractService.CreateOperationAsync(OperationType.Auth.ToString());
            return Ok(await _simaContractService.GenerateQR(operation));
        }
        [HttpPost("Sima/Sign")]
        public async Task<IActionResult> Sign(IFormFile file)
        {
            var operation = await _simaContractService.CreateOperationAsync(OperationType.Sign.ToString());

            return Ok(await _simaContractService.GenerateQR(operation,file));
        }
        [HttpGet("Sima/GetData")]
        public async Task<IActionResult> GetData(string operationId)
        {
            var response = await _simaContractService.GetData(operationId);

            return Ok(response);
        }


        [HttpPost("Callback")]
        public async Task<IActionResult> Callback()
        {
            await _simaContractService.CallBackAsync();
            return Ok(new CallBackResponseDto
            {
                Status = "success",
                Message = "Callback received successfully"
            });
        }
  
        [HttpGet("CertParse")]
        public IActionResult ParseCert()
        {
            HttpContextAccessor accessor = new HttpContextAccessor();
            var headers = accessor.HttpContext.Request.Headers;
            var ts_cert = headers["ts-cert"].ToString();
            CertificateObjectDto dto = CertificateParser.ParseToObject(ts_cert);
            return Ok(dto);
        }

      
        [HttpGet("TestPdf")]
        public async Task<IActionResult> TestPdf(string tsquery)
        {
            var cache = await _redisService
                .GetAsync<SimaTransactionCache>(
                    $"sima:transaction:{tsquery}");

            if (cache is null || string.IsNullOrEmpty(cache.RawFile))
                return NotFound();

            var pdfBytes = Convert.FromBase64String(cache.RawFile);

            await System.IO.File.WriteAllBytesAsync(
                "test.pdf",
                pdfBytes);

            return Ok("PDF yaradıldı");
        }
        //[HttpGet]
        //public IActionResult GetPdfBytes()
        //{
        //    return Ok(_simaContractService.DelegateSignAuthority());
        //}
    }
    }
