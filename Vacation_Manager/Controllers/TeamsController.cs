using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.Team;
using Vacation_Manager.Models.Users;

namespace Vacation_Manager.Controllers
{
    public class TeamsController : Controller
    {
        private readonly vacationmanagerdbContext _context;
        public TeamsController(vacationmanagerdbContext context)
        {
            _context = new vacationmanagerdbContext();
        }
        // GET: TeamsController
        public ActionResult Index(TeamsIndexViewModel model)
        {
            List <TeamsViewModel> items = _context.Teams.Select(t => new TeamsViewModel()
            {
                TeamId = t.TeamId,
                TeamName = t.TeamName,
                TeamLeadNavigation = t.TeamLeadNavigation,
                TeamProjectNavigation = t.TeamProjectNavigation
            }).ToList();

            model.items = items;
            return View(model);
        }
        // GET: TeamsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeamsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeamsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
