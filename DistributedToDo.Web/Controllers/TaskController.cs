using AutoMapper;
using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using DistributedToDo.BLL.Interfaces;
using DistributedToDo.Web.Filters;
using DistributedToDo.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
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
        [HttpGet]
        public ActionResult Index()
        {
            List<GeoLocation> taskMarkers = new List<GeoLocation>();
            IEnumerable<TaskModel> item = Mapper.Map<IEnumerable<TaskModel>>(TaskService.GetTasks(User.Identity.Name));
            int taskIndex = 0;
            char label = 'A';
            foreach (TaskModel x in item)
            {
                taskIndex++;
                if (x.GeoLat != null && x.GeoLong != null)
                {
                    taskMarkers.Add(new GeoLocation { Label = label, Name = x.Name, GeoLat = x.GeoLat, GeoLong = x.GeoLong });
                    x.Label = label++;
                    if (label == '[') label = 'a';
                }
            }
            ViewBag.taskindex = taskIndex;
            ViewBag.taskMarkers = taskMarkers;
            return View(item);
        }

        [HttpPost]
        public ActionResult Index(TaskModel model, string action)
        {
            if (action == "edit")
            {
                return RedirectToAction("Edit", new { taskId = model.Id });
            }
            else if (action == "check")
            {
                return RedirectToAction("Check", new { taskId = model.Id });
            }
            IEnumerable<TaskModel> item = Mapper.Map<IEnumerable<TaskModel>>(TaskService.GetTasks(User.Identity.Name));
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
            if (ModelState.IsValid)
            {
                TaskDTO item = Mapper.Map<TaskDTO>(model);
                item.UserName = User.Identity.Name;
                if (item.GeoLat == "0" && item.GeoLong == "0")
                    item.GeoLat = item.GeoLong = null;

                OperationDetails details = TaskService.Create(item);
                ViewBag.Message = details.Message;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string taskId)
        {
                TaskDTO model = TaskService.GetTask(taskId);
                if (model.UserName == User.Identity.Name)
                {
                    TaskModel item = Mapper.Map<TaskModel>(model);
                    return View(item);
                }
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                TaskDTO item = Mapper.Map<TaskDTO>(model);
                item.UserName = User.Identity.Name;
                OperationDetails details = TaskService.Edit(item);
                ViewBag.Message = details.Message;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Check(string taskId, char label)
        {
            TaskDTO task = TaskService.GetTask(taskId);
            task.Checked = (task.Checked) ? false : true;
            OperationDetails details = TaskService.Edit(task);
            ViewBag.Message = details.Message;
            TaskModel model = Mapper.Map<TaskModel>(task);
            model.Label = label;
            return PartialView("_Task", model);
        }
    }
}