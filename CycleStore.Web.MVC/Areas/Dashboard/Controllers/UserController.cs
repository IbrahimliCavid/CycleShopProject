using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Mapper;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var data = _userService.GetAll().Data;
            return View(data);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateDto dto)
        {
            var result = _userService.Add(dto);
            
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

             
                return View(dto);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _userService.GetById(id).Data;
            return View(UserMapper.ToUpdateDto(data));
        }

        [HttpPost]
        public IActionResult Edit(UserUpdateDto dto)
        {
            var result = _userService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Name", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            if (result.IsSuccess) return RedirectToAction("Index");
            return View(result);
        }
    }
}
