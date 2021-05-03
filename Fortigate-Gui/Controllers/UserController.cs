using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Fortigate_Gui.ValidationAttributes;
using Fortigate_Gui.Helper;
using Fortigate_Gui.ViewModels;

namespace Fortigate_Gui.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.FortiUsers.ToListAsync());
        }


        // GET: User/AddOrEdit
        // GET: User/AddOrEdit/5
        [NoDirectAccessAttribute]
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                AddOrEditUserViewModel viewModel = new AddOrEditUserViewModel { 
                    FortiUser = new FortiUser(),
                    GroupList = new SelectList(_context.Groups, "GroupID", "Name"),
                    SelectedGroups = new List<int>()
                };
                return View(viewModel);
            }
            else
            {
                FortiUser fortiUser = await _context.FortiUsers.Include(x => x.UserGroups)
                    .SingleOrDefaultAsync(x => x.FortiUserID == id);
                if (fortiUser == null)
                {
                    return NotFound();
                }
                AddOrEditUserViewModel viewModel = new AddOrEditUserViewModel()
                {   FortiUser = fortiUser,
                    GroupList = new SelectList(_context.Groups, "GroupID", "Name"),
                    SelectedGroups = fortiUser.UserGroups.Select(x => x.GroupID)
                };
                return View(viewModel);
            }
        }

        // POST: User/AddOrEdit
        // POST: User/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, AddOrEditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    List<UserGroup> newGroups = new List<UserGroup>();
                    foreach (int GroupID in viewModel.SelectedGroups)
                    {
                        newGroups.Add(new UserGroup
                        {
                            GroupID = GroupID,
                            FortiUserID = viewModel.FortiUser.FortiUserID
                        });
                    }

                    _context.Add(viewModel.FortiUser);
                    await _context.SaveChangesAsync();

                    FortiUser fortiUser = await _context.FortiUsers.Include(x => x.UserGroups)
                        .SingleOrDefaultAsync(x => x.FortiUserID == viewModel.FortiUser.FortiUserID);
                    fortiUser.UserGroups.AddRange(newGroups);
                    _context.Update(fortiUser);
                    await _context.SaveChangesAsync();

                    //_context.Add(fortiUser);
                    //await _context.SaveChangesAsync();
                }
                else
                {
                    FortiUser fortiUser = await _context.FortiUsers.Include(x => x.UserGroups)
                        .SingleOrDefaultAsync(x => x.FortiUserID == id);

                    fortiUser.Name = viewModel.FortiUser.Name;
                    fortiUser.Password = viewModel.FortiUser.Password;

                    List<UserGroup> newGroups = new List<UserGroup>();
                    foreach (int GroupID in viewModel.SelectedGroups)
                    {
                        newGroups.Add(new UserGroup
                        {
                            GroupID = GroupID,
                            FortiUserID = viewModel.FortiUser.FortiUserID
                        });
                    }

                    fortiUser.UserGroups
                        .RemoveAll(x => !newGroups.Contains(x));
                    fortiUser.UserGroups.AddRange(
                        newGroups.Where(x => !fortiUser.UserGroups.Contains(x)));
                    _context.Update(fortiUser);
                    await _context.SaveChangesAsync();

                    //_context.Update(fortiUser);
                    //await _context.SaveChangesAsync();

                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.FortiUsers.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", viewModel) });
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fortiUser = await _context.FortiUsers.FindAsync(id);
            _context.FortiUsers.Remove(fortiUser);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.FortiUsers.ToList()) });
        }

        private bool FortiUserExists(int id)
        {
            return _context.FortiUsers.Any(e => e.FortiUserID == id);
        }
    }
}
