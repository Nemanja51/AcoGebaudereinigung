using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AcoGebaudereinigung.Models;
using AcoGebaudereinigung.Data;
using AcoGebaudereinigung.Models.ViewModels;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

namespace AcoGebaudereinigung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel vm = new HomePageViewModel()
            {
                Jobs = await _db.Jobs.ToListAsync(),
                Gallery = await _db.Gallery.ToListAsync()
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EmailSender(string contactName, string contactEmail, string contactMessage)
        {
            MailAddress to = new MailAddress("xxx@xxx.xx");
            MailAddress from = new MailAddress(contactEmail, contactName);

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Poruka sa websajta - AcoGebauderenigung";
            message.Body = contactMessage;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("xxx@xxx.com", "xxxxxxxxxxxxxxx"),
                EnableSsl = true
            };

            var macAddress = GetMACAddress();
            //var ipAddress = GetIpAddress();

            client.Send(message);

            return RedirectToAction(nameof(Index));
        }

        public string GetMACAddress()
        {
            string mac_src = "";
            string macAddress = "";

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    mac_src += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2)) + "-";
                    }
                }
            }
            return macAddress;
        }

        //public string GetIpAddress()
        //{
            
        //    var currentIp = HttpContext.Request;
        //    var kolacici =  currentIp.Cookies;

        //    return "";
        //}
    }
}
