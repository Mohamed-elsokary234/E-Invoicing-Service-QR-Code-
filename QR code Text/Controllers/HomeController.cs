using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QR_code_Text.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;

using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace QR_code_Text.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        //
        

        //
        [HttpPost]
        public IActionResult Index(string CompanyName,string TaxNumber,string BillDateTime, string TotalAfterVAT,string TotalVAT)
        {
            try
            {
                string InvoiceDateTime = DateTime.Parse(BillDateTime).ToString("yyyy-MM-ddTHH:mm:ssZ");

                string TextCode = encodeQrText(CompanyName, TaxNumber, InvoiceDateTime, TotalAfterVAT, TotalVAT);

                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();

                    QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(TextCode, QRCodeGenerator.ECCLevel.Q, true);

                    QRCode qRCode = new QRCode(qRCodeData);

                    using (Bitmap obitmap = qRCode.GetGraphic(20))
                    {
                        obitmap.Save(ms, ImageFormat.Png);
                        ViewBag.QrCode = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
           
            
            #region convert from ascii code for Qr code
            /*
             * TextCode = encodeQrText(txtCompanyName.Text, txtTaxNumber.Text, dtpBillDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"), txtBillTotal.Text, txtVATTotal.Text);
            txtEncodedString.Text = TextCode;
            byte[] byteImage;
        QRCodeGenerator QR = new QRCodeGenerator();
        QRCodeData Data = QR.CreateQrCode(TextCode, QRCodeGenerator.ECCLevel.Q);
        QRCode Code = new QRCode(Data);
        picQRCode.Image = Code.GetGraphic(5);
            using (Bitmap bitMap = Code.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byteImage = ms.ToArray();
                    picQRCode.Image = System.Drawing.Image.FromStream(ms);
                }
}
             */
            #endregion
        }
        

        public string encodeQrText(string CompanyName, string TaxNumber, string BillDateTime, string TotalAfterVAT, string TotalVAT)
        {
            //use UTF8 with sallerName to solve arabic issue
            byte[] bytes = Encoding.UTF8.GetBytes(CompanyName);
            string L1 = bytes.Length.ToString("X");
            string tag1Hex = BitConverter.ToString(bytes);
            tag1Hex = tag1Hex.Replace("-", "");

            string L2 = TaxNumber.Length.ToString("X");
            string L3 = BillDateTime.Length.ToString("X");
            string L4 = TotalAfterVAT.Length.ToString("X");
            string L5 = TotalVAT.Length.ToString("X");
            //length tag must be 2 digit like '0C' 
            string hex = "01" + ((L1.Length == 1) ? ("0" + L1) : L1) + tag1Hex +
                         "02" + ((L2.Length == 1) ? ("0" + L2) : L2) + ToHexString(TaxNumber) +
                         "03" + ((L3.Length == 1) ? ("0" + L3) : L3) + ToHexString(BillDateTime) +
                         "04" + ((L4.Length == 1) ? ("0" + L4) : L4) + ToHexString(TotalAfterVAT) +
                         "05" + ((L5.Length == 1) ? ("0" + L5) : L5) + ToHexString(TotalVAT);

            return HexToBase64(hex);
        }

        private string ToHexString(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            string hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", "");
            return hexString;
        }

        private string HexToBase64(string strInput)
        {
            try
            {
                var bytes = new byte[strInput.Length / 2];
                for (var i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(strInput.Substring(i * 2, 2), 16);
                }
                return Convert.ToBase64String(bytes);
            }
            catch (Exception)
            {
                return "-1";
            }
        }


    }
}
