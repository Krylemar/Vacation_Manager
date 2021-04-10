using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.ProjectModels;
using Vacation_Manager.Models.TeamModels;
using Vacation_Manager.Models.UserModels;

namespace Vacation_Manager.Controllers
{  
    public class TeamViewsController : Controller
    {
        private readonly vacationmanagerdbContext _context;
        public TeamViewsController()
        {
            _context = new vacationmanagerdbContext();
        }
        // GET: TeamsController
        public ActionResult Index(TeamIndexViewModel model) //Unknown issue
        {
            List<TeamViewModel> items =_context.Teams.Select(t => new TeamViewModel()
            {
                TeamId = t.TeamId,
                TeamName = t.TeamName,
                TeamProjectNavigation = t.TeamProjectNavigation,
                TeamLeadNavigation = t.TeamLeadNavigation,
                NameOutput = string.Concat(t.TeamLeadNavigation.FirstName, " ", t.TeamLeadNavigation.LastName)
            }).ToList();

            model.items = items;
            

            return View(model);
        }


        // GET: TeamsController/Create
        public ActionResult Create()
        {
            //TeamCreateViewModel userModel = new TeamCreateViewModel();
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
           
            List<ProjectViewModel> projectItems = _context.Projects.Select(p => new ProjectViewModel()
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName
            }).ToList();

            //userModel.projectItems = projectItems;
            //userModel.userItems = items;

            ViewBag.projectItems = projectItems;
            ViewBag.userItems = items;

            return View(
                );
        }

        // POST: TeamsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreateViewModel model) //Working
        {
            if (ModelState.IsValid) 
            {
                Teams team = new Teams()
                {
                    TeamName = model.TeamName,
                    TeamLeadNavigation = _context.Users.Find(model.LeaderId),
                    TeamLead = model.LeaderId,
                    TeamProjectNavigation = _context.Projects.Find(model.ProjectId),
                    TeamProject = model.ProjectId,
                };
                _context.Add(team);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: TeamsController/Edit/5
        public ActionResult Edit(int id)
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

            ViewBag.UserList = items;

            List<ProjectViewModel> projectItems = _context.Projects.Select(p => new ProjectViewModel()
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName
            }).ToList();

            ViewBag.ProjectList = projectItems;

            return View();
        }

        // POST: TeamsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeamEditViewModel model) //Not Tested
        {
            Teams team = new Teams
            {
                TeamId = model.TeamId,
                TeamName = model.TeamName,
                TeamLeadNavigation = _context.Users.Find(model.LeaderId),
                TeamLead = model.LeaderId,
                TeamProjectNavigation = _context.Projects.Find(model.ProjectId),
                TeamProject = model.ProjectId
            };

            try
            {
                _context.Update(team);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(team.TeamId))
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

        // GET: TeamsController/Delete/5
        public ActionResult Delete(int id) //Not Tested
        {
            Teams team = _context.Teams.Find(id);
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id) 
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
