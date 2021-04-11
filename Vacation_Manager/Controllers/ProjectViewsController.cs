using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.ProjectModels;

namespace Vacation_Manager.Controllers
{
    public class ProjectViewsController : Controller
    {
        private readonly vacationmanagerdbContext _context;
        public ProjectViewsController()
        {
            _context = new vacationmanagerdbContext();
        }
        // GET: ProjectsController
        public ActionResult Index(ProjectIndexViewModel model)
        {
            List<ProjectViewModel> items = _context.Projects.Select(p => new ProjectViewModel() 
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                Description = p.Description
            }).ToList();

            model.items = items;
            return View(model);
        }

        // GET: ProjectsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Projects project = new Projects()
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                    Teams = model.Teams               
                };
                _context.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Projects project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            ProjectEditViewModel model = new ProjectEditViewModel()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                Description = project.Description,
                Teams = project.Teams
            };
            return View(model);
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Projects project = new Projects
                {
                    ProjectId = model.ProjectId,
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                    Teams = model.Teams
                };

                try
                {
                    _context.Update(project);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            Projects project = _context.Projects.Find(id);
            foreach (var item in _context.Teams)
            {
                if (item.TeamProject == id)
                {
                    item.TeamProject = 1;
                }
            }
            _context.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id) 
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
        [HttpGet]
        public ActionResult Details(int id) 
        {
            Projects project = _context.Projects.Find(id);
            ProjectDetailsViewModel model = new ProjectDetailsViewModel() 
            {
                ProjectName = project.ProjectName,
                ProjectId = project.ProjectId
            };
            foreach (var item in project.Teams)
            {
                model.Teams.Add(item);
            }
            
            return View(model);
        }
        [HttpGet]
        public ActionResult AddTeam(ProjectViewModel model)
        {
            List<Teams> teams = _context.Teams.ToList();
            model.Teams = teams;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddTeam(int teamId, ProjectViewModel model) 
        {
            Teams team = _context.Teams.Find(teamId);
            model.Teams.Add(team);
            return RedirectToAction(nameof(Details));
        }
    }
}
