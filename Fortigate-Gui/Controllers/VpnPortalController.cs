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
    public class VpnPortalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VpnPortalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VpnPortal
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VpnPortals;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VpnPortal/AddOrEdit
        // GET: VpnPortal/AddOrEdit/5
        [NoDirectAccessAttribute]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            // eerst controleren of de id is overschreven, indien neen, nieuw model aanmaken, indien ja model ophalen en tonen
            if (id == 0)
            {
               
                return View(new VpnPortal());
            }
            else
            {
                VpnPortal vpnPortal = await _context.VpnPortals.FindAsync(id);
                if (vpnPortal == null)
                {
                    return NotFound();
                }
               
                return View(vpnPortal);
            }
        }

        // POST: VpnPortal/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("VpnPortalID,PortalName,TunnelMode,SplitTunneling,WebMode,AutoConnect,KeepAlive,SavePassword,IpPool,SplitTunnelingRoute,ConfigFileID")] VpnPortal vpnPortal)
        {
            if (ModelState.IsValid)
            {
                if (vpnPortal.SplitTunneling == true && vpnPortal.SplitTunnelingRoute == null)
                {
                    ModelState.AddModelError("SplitTunnelingRoute", "SplitTunnelingRoute is required when Split Tunneling is enabled");
                    return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", vpnPortal) });
                }
                if (id == 0)
                {
                    _context.Add(vpnPortal);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Update(vpnPortal);
                    await _context.SaveChangesAsync();
                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.VpnPortals.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", vpnPortal) });
        }

        // POST: VpnPortal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vpnPortal = await _context.VpnPortals.FindAsync(id);
            _context.VpnPortals.Remove(vpnPortal);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.VpnPortals.ToList()) });
        }

        private bool VpnPortalExists(int id)
        {
            return _context.VpnPortals.Any(e => e.VpnPortalID == id);
        }
    }
}
