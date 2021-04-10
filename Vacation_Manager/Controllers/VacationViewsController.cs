﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.VacationModels;
using Vacation_Manager;

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
                IsApproved = v.IsApproved,
                VacUserNavigation = v.VacUserNavigation
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
