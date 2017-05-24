using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorldProject.Services;
using Microsoft.Extensions.Configuration;
using TheWorldProject.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using TheWorldProject.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorldProject.Controllers.Web
{    
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        //private WorldContext _context;
        private IWorldRepository _repository;
        private ILogger _logger;

        public AppController(IMailService mailService, IConfigurationRoot config, IWorldRepository repository, ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    try
        //    {
        //        var data = _repository.GetAllTrips().ToList();
        //        return View(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get trips in Index page: {ex.Message}");
        //        return Redirect("/error");
        //    }
        //}

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            try
            {
                var data = _repository.GetAllTrips();
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get trips in Index page: {ex.Message}");
                return Redirect("/error");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("", "We don't support AOL addresses");
            }

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From TheWorld", model.Message);

                ModelState.Clear();

                ViewBag.UserMessage = "Message Sent";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
