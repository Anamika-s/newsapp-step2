using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_WebApp.Models;
using News_WebApp.Repository;
namespace News_WebApp.Controllers
{
    public class LoginController : Controller
    {


        /* 
         * Retrieve the UserRepository object from the dependency Container through constructor Injection.
        */

        IUserRepository _userRepo;
        public LoginController(IUserRepository repository)
        {
            _userRepo = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            bool found = _userRepo.IsAuthenticated(user.UserId, user.Password);
            if(found==true)
            {
                TempData["userId"] = user.UserId;
                return RedirectToAction("Index" ,"News");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid User Id and Password");
                

                return View();
            }
        }
        /*Call The Index Action to display default view
         
        */

        /*Use a Httpverb i.e POST for action i.e Index which acccepts User Object as a parameter
         * check the user credentials true or false. 
         * If user credentials are true store the userid in temporary storage and redirect the action to News controller and default Index view
         * If user creadentials are false display an error message(AddModelError) i.e Invalid User Id and Password
         */

    }
}