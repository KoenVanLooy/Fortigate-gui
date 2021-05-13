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
    public class VpnSettingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VpnSettingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VpnSetting
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VpnSettings.Include(v => v.Group).Include(v => v.VpnPortal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VpnSetting/AddOrEdit
        // GET: VpnSetting/AddOrEdit/5
        [NoDirectAccessAttribute]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            // eerst controleren of de id is overschreven, indien neen, nieuw model aanmaken, indien ja model ophalen en tonen
            if (id == 0)
            {
                AddOrEditVpnSettingViewModel viewModel = new AddOrEditVpnSettingViewModel()
                {
                    VpnSetting = new VpnSetting(),
                    VpnPortals = new SelectList(_context.VpnPortals, "VpnPortalID", "PortalName"),
                    Groups = new SelectList(_context.Groups, "GroupID", "Name")
                };
                return View(viewModel);
            }
            else
            {
                VpnSetting vpnSetting = await _context.VpnSettings.FindAsync(id);
                if (vpnSetting == null)
                {
                    return NotFound();
                }
                AddOrEditVpnSettingViewModel viewModel = new AddOrEditVpnSettingViewModel()
                {
                    VpnSetting = vpnSetting,
                    VpnPortals = new SelectList(_context.Groups, "GroupID", "Name", vpnSetting.GroupID),
                    Groups = new SelectList(_context.VpnPortals, "VpnPortalID", "IpPool", vpnSetting.VpnPortalID)
                };
                return View(viewModel);
            }
        }

        // POST: VpnSetting/AddOrEdit
        // POST: VpnSetting/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, AddOrEditVpnSettingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(viewModel.VpnSetting);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Update(viewModel.VpnSetting);
                    await _context.SaveChangesAsync();
                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.VpnSettings.ToList()) });
            }
            viewModel.Groups = new SelectList(_context.Groups, "GroupID", "Name", viewModel.VpnSetting.GroupID);
            viewModel.VpnPortals = new SelectList(_context.VpnPortals, "VpnPortalID", "IpPool", viewModel.VpnSetting.VpnPortalID);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", viewModel.VpnSetting) });
        }

        // POST: VpnSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vpnSetting = await _context.VpnSettings.FindAsync(id);
            _context.VpnSettings.Remove(vpnSetting);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.VpnSettings.ToList()) });
        }

        private bool VpnSettingExists(int id)
        {
            return _context.VpnSettings.Any(e => e.VpnSettingID == id);
        }
    }
}