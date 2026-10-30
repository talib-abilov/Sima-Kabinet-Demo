using Microsoft.AspNetCore.Http;
using SimaApp.Application.DTOS.Sima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Interfaces.Repositories
{
    public interface ISimaContractService
    {
        //Task<byte[]> GenerateQR(bool isAuth,IFormFile? file=null);
        //Task<byte[]> GenerateQR(OperationInfo operation, IFormFile? file = null);

        Task<GenerateQrResponseDto> GenerateQR(OperationInfo operation, IFormFile? file = null);

        //GetDataResponseDto GetData();
        Task<GetDataResponseDto> GetData(string operationId);
        Task CallBackAsync();
        Task<OperationInfo> CreateOperationAsync(string operationType);
        //byte[] DelegateSignAuthority();

    }
}
