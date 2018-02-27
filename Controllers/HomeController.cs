using Microsoft.AspNet.Identity;
using portfoliosite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace portfoliosite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JSExercise()
        {
            return View();
        }
        public ActionResult JQueryExercise()
        {
            return View();
        }
        public ActionResult Contact()
        {
            Contact model = new Contact();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(string name, string email, string subject, string message)
        {

            var newContact = name;
            var svc = new EmailService();
            var msg = new IdentityMessage();
            msg.Subject = "Contact From Portfolio Site";
            msg.Body = "\r\n You have recieved a request to contact from " + newContact + "(" + email + ")" + "\r\n"
                         + "\r\n With the following message: \r\n\t"
                         + message;
            msg.Destination = "shanamcclain7@gmail.com";

            await svc.SendAsync(msg);
            TempData["BlogMessage"] = "Your Email has been sent";
            return RedirectToAction("Index", "Home");
        }

    }
}
