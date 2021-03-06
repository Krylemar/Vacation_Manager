using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.UserModels;

namespace Vacation_Manager.Controllers
{
    public class UserViewsController : Controller
    {
        private readonly vacationmanagerdbContext _context;

        public UserViewsController()
        {
            _context = new vacationmanagerdbContext();
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
                UserTeamNavigation = c.UserTeamNavigation
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
        public ActionResult Create(UsersCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    Username = model.Username,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserTeam = model.Team,
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
                Team = user.UserTeam

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


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();    
        }
        [HttpPost]
        public async Task<IActionResult> Register(UsersCreateViewModel model)
        {
            Startup.isLogged= true;
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

            Startup.isLogged = true;
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(string username, string password) // не знам какво да върна
        {
            List<Users> items = _context.Users.Select(c => new Users()
            {
                UserId = c.UserId,
                Username = c.Username,
                Password = c.Password,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Role = c.Role,
                UserTeamNavigation = c.UserTeamNavigation
            }).ToList();
            foreach (var user in items)
            {
                if (user.Username.Equals(username))
                {
                    if (user.Password.Equals(password))
                    {
                        Startup.isLogged = true;
                        Startup.loggedInUser = user;
                        Startup.loggedInRole = Startup.loggedInUser.Role;
                        return RedirectToAction(nameof(Index));
                    }
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Startup.isLogged = false;
            ViewBag.LogoutMessage = "Довиждане, ще ми липсваш...";
            return RedirectToAction(nameof(Index), "Home");
        }

        //public ActionResult UserLanding() 
        //{

        //}
    }
}
