using DistributedToDo.BLL.Interfaces;
using DistributedToDo.Web.Filters;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace DistributedToDo.Web.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        private IUserTaskService UserTaskService;

        public HomeController(IUserTaskService userTaskService)
        {
            UserTaskService = userTaskService;
        }

        public ActionResult Index()
        {
            ViewBag.UsersCount = UserService.GetUsersCount();
            ViewBag.TasksCount = UserTaskService.GetTasksCount();
            return View();
        }

        public ActionResult Contact()
        { 
            return View();
        }

        public ActionResult ChangeCulture(string locale, string actionName, string controllerName)
        {
            if (locale != "en")
                locale = "ru";
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["locale"];
            if (cookie != null)
                cookie.Value = locale;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("locale");
                cookie.HttpOnly = false;
                cookie.Value = locale;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction(actionName, controllerName);

        }

        public ActionResult LoginForm()
        {
            return PartialView("_Login");
        }
    }
}