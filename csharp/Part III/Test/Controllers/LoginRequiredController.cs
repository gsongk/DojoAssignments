using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Test.Controllers
{
    public class LoginRequiredController : Controller
    {
        public bool IsLoggedIn
        {
            get { return HttpContext.Session.GetInt32("id") != null; }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!IsLoggedIn)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }

    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32("id") == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }

}