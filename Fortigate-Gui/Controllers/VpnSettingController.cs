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
            var applicationDbContext = _context.VpnSettings.Include(v => v.group).Include(v => v.vpnPortal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VpnSetting/AddOrEdit
        // GET: VpnSetting/AddOrEdit/5
        [NoDirectAccessAttribute]
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id==0)
            {
                ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "Name");
                ViewData["VpnPortalID"] = new SelectList(_context.VpnPortals, "VpnPortalID", "IpPool");
                return View(new VpnSetting());
            }
            else
            {
                VpnSetting vpnSetting = await _context.VpnSettings.FindAsync(id);
                if (vpnSetting == null)
                {
                    return NotFound();
                }
                ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "Name", vpnSetting.GroupID);
                ViewData["VpnPortalID"] = new SelectList(_context.VpnPortals, "VpnPortalID", "IpPool", vpnSetting.VpnPortalID);
                return View(vpnSetting);
            }
        }

        // POST: VpnSetting/AddOrEdit
        // POST: VpnSetting/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("VpnSettingID,ServerCert,TunnelIpPool,TunnelIpv6Pool,SourceInterface,SourceAddress,SourceAddressV6,DefaultPort,GroupID,VpnPortalID")] VpnSetting vpnSetting)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(vpnSetting);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(vpnSetting);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VpnSettingExists(vpnSetting.VpnSettingID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.VpnSettings.ToList()) });
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "Name", vpnSetting.GroupID);
            ViewData["VpnPortalID"] = new SelectList(_context.VpnPortals, "VpnPortalID", "IpPool", vpnSetting.VpnPortalID);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", vpnSetting) });
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
