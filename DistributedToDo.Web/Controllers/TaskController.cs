using AutoMapper;
using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using DistributedToDo.BLL.Interfaces;
using DistributedToDo.Web.Filters;
using DistributedToDo.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace DistributedToDo.Web.Controllers
{
    [Culture]
    [Authorize]
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

        public ActionResult Index()
        {
            IEnumerable<TaskModel> item = Mapper.Map<IEnumerable<TaskDTO>, IEnumerable<TaskModel>>(TaskService.GetTasks(User.Identity.Name));
            return View(item);
        }

        [HttpPost]
        public ActionResult Index(TaskModel model, string action)
        {
            if(action == "edit")
            {
                return RedirectToAction("Edit", model);
            }
            else if(action == "delete")
            {
                return RedirectToAction("Delete", model);
            }
            IEnumerable<TaskModel> item = Mapper.Map<IEnumerable<TaskDTO>, IEnumerable<TaskModel>>(TaskService.GetTasks(User.Identity.Name));
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
            TaskDTO item = Mapper.Map<TaskModel, TaskDTO>(model);
            item.UserName = User.Identity.Name;
            OperationDetails details = TaskService.Create(item);
            ViewBag.Message = details.Message;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string taskId)
        {
            TaskModel item = Mapper.Map<TaskDTO,TaskModel>(TaskService.GetTask(taskId));
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(TaskModel model)
        {
            TaskDTO item = Mapper.Map<TaskModel, TaskDTO>(model);
            item.UserName = User.Identity.Name;
            OperationDetails details = TaskService.Edit(item);
            ViewBag.Message = details.Message;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(TaskModel model)
        {
            var item = Mapper.Map<TaskModel, TaskDTO>(model);
            item.UserName = User.Identity.Name;
            TaskService.Delete(item);
            return RedirectToAction("Index");
        }
    }
}