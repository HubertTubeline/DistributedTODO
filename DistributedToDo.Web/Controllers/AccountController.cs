using AutoMapper;
using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using DistributedToDo.BLL.Interfaces;
using DistributedToDo.Web.Filters;
using DistributedToDo.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DistributedToDo.Web.Controllers
{
    [Culture]
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [Authorize]
        public  ActionResult Index()
        {
            UserDTO user = UserService.GetUser(User.Identity.Name);
            AccountModel item = Mapper.Map<AccountModel>(user);
            return View(item);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        { 
            AccountModel userDto = Mapper.Map<AccountModel>(UserService.GetUser(User.Identity.Name));
            return View(userDto);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(AccountModel user, HttpPostedFileBase image)
        {
            UserDTO model = Mapper.Map<UserDTO>(user);
            if (image != null)
            {
                string path = Server.MapPath("~/Files/" + model.Email + ".png");
                Image img = Image.FromStream(image.InputStream);
                img = resizeImage(img, 150, 150); //Ресайз изображения до размера 150х150
                img.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                model.Photo = "/Files/" + model.Email + ".png";
            }
            UserService.Edit(model);
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    return View();
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = Mapper.Map<UserDTO>(model);
                if (image != null)
                {
                    // Получаем расширение
                    string ext = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                    // сохраняем файл по определенному пути на сервере
                    string path = model.Email + ext;
                    image.SaveAs(Server.MapPath("~/Files/" + path));
                    userDto.Photo = "/Files/" + path;
                }
                userDto.Role = "user";
                OperationDetails operationDetails = await UserService.CreateAsync(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }


        private Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
    }
}