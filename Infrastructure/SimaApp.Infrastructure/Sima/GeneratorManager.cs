using SimaApp.Application.Interfaces.Repositories;
using SkiaSharp;
using SkiaSharp.QrCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure.Sima
{
    public class GeneratorManager : IGeneratorService
    {
        public Task<string> GenerateQr(string qrUrl)
        {
            string qrImageBase64String;

            var qr = QRCodeGenerator.CreateQrCode(qrUrl, ECCLevel.L);

            var info = new SKImageInfo(306, 306);

            using (var surface = SKSurface.Create(info))
            {
                var canvas = surface.Canvas;

                canvas.Render(qr, info.Width, info.Height);

                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Jpeg, 100))
                {
                    qrImageBase64String = Convert.ToBase64String(data.AsSpan());
                }
            }

            return Task.FromResult(qrImageBase64String);
        }
    }
}
