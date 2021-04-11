using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.VacationModels;
using Vacation_Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace VacationManager.Controllers
{
    public class VacationViewsController : Controller
    {
        private readonly vacationmanagerdbContext _context;
        public VacationViewsController()
        {
            _context = new vacationmanagerdbContext();
        }
        // GET: HomeController1
        public IActionResult Index(VacationIndexViewModel model)
        {
            List<VacationViewModel> vacations = _context.Vacations.Select(v => new VacationViewModel()
            {
                VacationId = v.VacationId,
                StartDate = v.StartDate,
                EndDate = v.EndDate,
                CreationDate = v.CreationDate,
                IsApproved = (bool)v.IsApproved,
                IsApprovedByCEO = (bool)v.IsApprovedByCeo,
                VacType = v.VacType,
                VacUserNavigation = v.VacUserNavigation,
            }).ToList();
            model.items = vacations;
            return View(model);
        }


        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users vacOwner = Startup.loggedInUser;
                Vacations vacation = new Vacations()
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CreationDate = DateTime.UtcNow,
                    IsApproved = false,
                    IsApprovedByCeo = false,
                    VacType = model.VacType,
                    VacUser = vacOwner.UserId
                };
                _context.Add(vacation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            Vacations vac =_context.Vacations.Find(id);
            VacationEditViewModel model = new VacationEditViewModel()
            {
                VacationId = vac.VacationId,
                StartDate = vac.StartDate,
                EndDate = vac.EndDate,
                VacType = vac.VacType,
                VacUser = vac.VacUser
            };

            return View(model);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VacationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Vacations vac = _context.Vacations.Find(model.VacationId);
                vac.StartDate = model.StartDate;
                vac.EndDate = model.EndDate;
                vac.VacType = model.VacType;
                _context.Update(vac);
                _context.SaveChanges();                             
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        private bool VacationExists(int vacId) 
        {
            return _context.Vacations.Any(v => v.VacationId == vacId);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            Vacations vac =  _context.Vacations.Find(id);
            _context.Remove(vac);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       [HttpGet]
        public ActionResult Approve(int id) 
        {
            Vacations vac = _context.Vacations.Find(id);
            if (Startup.loggedInUser.Role.Equals("Team Lead"))
            {
                vac.IsApproved = true;
            }
            else if (Startup.loggedInUser.Role.Equals("CEO"))
            {
                vac.IsApprovedByCeo = true;
            }
            _context.Update(vac);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
