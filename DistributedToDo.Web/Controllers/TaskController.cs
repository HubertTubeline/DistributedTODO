using AutoMapper;
using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Interfaces;
using DistributedToDo.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistributedToDo.Web.Controllers
{
    public class TaskController : Controller
    {
        private IUserTaskService TaskService { get; set; }
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        public TaskController(IUserTaskService userTaskService)
        {
            TaskService = userTaskService;
        }

        // GET: Task
        [HttpGet]
        public ActionResult Index()
        {
            var item = Mapper.Map<IEnumerable<TaskDTO>, IEnumerable<TaskModel>>(TaskService.GetTasks(User.Identity.Name));
            return View(item);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            var item = Mapper.Map<TaskModel, TaskDTO>(model);
            TaskService.Create(item);
            return View();
        }
    }
}