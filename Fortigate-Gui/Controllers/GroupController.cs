using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Fortigate_Gui.Helper;
using Fortigate_Gui.ValidationAttributes;
using Fortigate_Gui.ViewModels;

namespace Fortigate_Gui.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groups.Include(c => c.ConfigFile);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Group/AddOrEdit
        // GET: Group/AddOrEdit/5
        [NoDirectAccessAttribute]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                AddOrEditGroupViewModel viewModel = new AddOrEditGroupViewModel
                {
                    Group = new Group(),
                    FortiUserList = new SelectList(_context.FortiUsers, "FortiUserID", "Name"),
                    SelectedFortiUsers = new List<int>()
                };
                return View(viewModel);
                //ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID");
                //return View(new Group());
            }
            else
            {
                Group group = await _context.Groups.Include(x => x.UserGroups)
                    .SingleOrDefaultAsync(x => x.GroupID == id);
                if (group == null)
                {
                    return NotFound();
                }
                AddOrEditGroupViewModel viewModel = new AddOrEditGroupViewModel()
                {
                    Group = group,
                    FortiUserList = new SelectList(_context.FortiUsers, "FortiUserID", "Name"),
                    SelectedFortiUsers = group.UserGroups.Select(x => x.FortiUserID)
                };
                return View(viewModel);
                //ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID", group.ConfigFileID);
                //return View(group);
            }
        }

        // POST: Group/AddOrEdit
        // POST: Group/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, AddOrEditGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    List<UserGroup> newUsers = new List<UserGroup>();
                    foreach (int FortiUserID in viewModel.SelectedFortiUsers)
                    {
                        newUsers.Add(new UserGroup
                        {
                            FortiUserID = FortiUserID,
                            GroupID = viewModel.Group.GroupID
                        });
                    }

                    _context.Add(viewModel.Group);
                    await _context.SaveChangesAsync();

                    Group group = await _context.Groups.Include(x => x.UserGroups)
                        .SingleOrDefaultAsync(x => x.GroupID == viewModel.Group.GroupID);
                    group.UserGroups.AddRange(newUsers);
                    _context.Update(group);
                    await _context.SaveChangesAsync();

                    //_context.Add(group);
                    //await _context.SaveChangesAsync();
                }
                else
                {
                    Group group = await _context.Groups.Include(x => x.UserGroups)
                        .SingleOrDefaultAsync(x => x.GroupID == id);

                    group.Name = viewModel.Group.Name;

                    List<UserGroup> newUsers = new List<UserGroup>();
                    foreach (int FortiUserID in viewModel.SelectedFortiUsers)
                    {
                        newUsers.Add(new UserGroup
                        {
                            FortiUserID = FortiUserID,
                            GroupID = viewModel.Group.GroupID
                        });
                    }

                    group.UserGroups
                        .RemoveAll(x => !newUsers.Contains(x));
                    group.UserGroups.AddRange(
                        newUsers.Where(x => !group.UserGroups.Contains(x)));
                    _context.Update(group);
                    await _context.SaveChangesAsync();

                    //_context.Update(group);
                    //await _context.SaveChangesAsync();
                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.Groups.ToList()) });
            }
                
            //ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID", group.ConfigFileID);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", viewModel) });
        }


        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.Groups.ToList()) });
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupID == id);
        }
    }
}
