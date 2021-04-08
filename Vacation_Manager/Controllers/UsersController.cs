using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.Users;

namespace Vacation_Manager.Controllers
{
    public class UsersController : Controller
    {
        private readonly vacationmanagerdbContext _context;

        private UserManager<UsersViewModel> userManager;
        private SignInManager<UsersViewModel> signManager;


        public UsersController(UserManager<UsersViewModel> usrMgr)
        {
            _context = new vacationmanagerdbContext();
            userManager = usrMgr;
        }

        // GET: UsersController
        public ActionResult Index(UsersIndexViewModel model)
        {
            List<UsersViewModel> items = _context.Users.Select(c => new UsersViewModel()
            {
                UserId = c.UserId,
                Username = c.Username,
                Password = c.Password,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Role = c.Role,
                UserTeamNavigation = c.UserTeamNavigation,

            }).ToList();

            model.items = items;

            return View(model);
        }


        // GET: UsersController/Create
        public ActionResult Create()
        {
            UsersCreateViewModel user = new UsersCreateViewModel();
            return View(user);
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    Username = model.Username,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserTeam = model.UserTeam,
                    Role = model.Role
                };
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            UsersEditViewModel model = new UsersEditViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                UserTeamNavigation = user.UserTeamNavigation

            };

            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    UserId = model.UserId,
                    Username = model.Username,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = model.Role,
                    UserTeam = model.Team
                };

                try
                {
                    _context.Update(user);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            Users user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: UsersController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{

        //}

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        //работещ метод за регистрация 
        [HttpPost]
        public async Task<IActionResult> Register(UsersViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    Username = model.Username,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserTeam = 1,
                    Role = "Unassigned"
                };
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        //Неработещ метод за регистрация с идентити
        
        //[HttpPost]
        //public async Task<IActionResult> Register(UsersViewModel user)
        //{
        //    if (ModelState.IsValid)
        //    {               
        //        UsersViewModel appUser = new UsersViewModel
        //        {
        //            UserId = 70,
        //            Username = user.Username,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Role = "Unassigned",
        //            UserTeam = 1

        //        };
                
        //        IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
        //        if (result.Succeeded)
        //            return RedirectToAction("Index");
        //        else
        //        {
        //            foreach (IdentityError error in result.Errors)
        //                ModelState.AddModelError("", error.Description);
        //        }
        //    }
        //    return View(user);
        //}
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password) 
        {
            if (UserExists(username) == true)
            {
                List<Users> user = _context.Users.Select(o => new Users
                {
                    UserId = o.UserId,
                    Username = o.Username,
                    Password = o.Password,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    UserTeam = (int)o.UserTeam,
                    Role = o.Role
                }).Where(p => p.Username.Equals(username)).ToList();
                if (user[0].Password.Equals(password))
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return null; // TO BE CHANGED
        }
        
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }
    }
}
