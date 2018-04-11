using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Visma.SecureCoding.Web.Models;

namespace Visma.SecureCoding.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
