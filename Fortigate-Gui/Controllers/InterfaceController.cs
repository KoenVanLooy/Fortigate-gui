using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fortigate_Gui.Data;
using Fortigate_Gui.Helper;
using Fortigate_Gui.Models;
using Fortigate_Gui.ValidationAttributes;
using Fortigate_Gui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fortigate_Gui.Controllers
{
    public class InterfaceController : Controller
    {

        private readonly ApplicationDbContext _context;
        public InterfaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get Create:index
        public async Task<IActionResult> Index()
        {
            //Gives List with include
            return View(await _context.Interfaces.Include(x => x.EnumType)
                .Include(x => x.EnumPhysical) 
                .Include(x => x.EnumMode)
                .ToListAsync());
        }

        // GET: Interfacess/Details/5
       
        [NoDirectAccessAttribute]
        public IActionResult Create()
        {
            CreateInterfaceViewModel viewModel = new CreateInterfaceViewModel
            {
               
                Interface = new Interface(),
                Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name"),
                Types = new SelectList(_context.EnumTypes,"EnumTypeID","Name"),
                Physicals = new SelectList(_context.EnumPhysicals,"EnumPhysicalID","Name"),
                //Many to Many relations EnumAccess
                SelectedEnumAcces = new List<int>(),
                AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name")
            };

            return View(viewModel);
        }

        // POST: Create:index
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateInterfaceViewModel viewModel)
        {
            viewModel.Interface.Ip = viewModel.IpAddress;
            EnumPhysical physical = _context.EnumPhysicals.SingleOrDefault(x => x.EnumPhysicalID == viewModel.Interface.EnumPhysicalID);
            // Coupling viewModel to Model NO_VLAN sets name different
            if (viewModel.VlanName == "NO_VLAN")
            {
                viewModel.Interface.Name = physical.Name;
                viewModel.Interface.VlanId = 0;
                viewModel.Interface.VlanInterface = "NO_VLANInterface";
            }
            else
            {
                viewModel.Interface.Name = viewModel.VlanName;
                viewModel.Interface.VlanInterface = physical.Name;
            }
            //Saves from viewModel to DB
            if (ModelState.IsValid)

            {
                List<AccessInterface> newLines = new List<AccessInterface>();
                if (viewModel.SelectedEnumAcces == null)
                {
                    viewModel.SelectedEnumAcces = new List<int>();
                }
                foreach (int enumAccesID in viewModel.SelectedEnumAcces)
                {
                    AccessInterface accessInterface = new AccessInterface();
                    accessInterface.EnumAccesID = enumAccesID;
                    accessInterface.InterfaceID = viewModel.Interface.InterfaceID;

                    newLines.Add(accessInterface);
                }

                //Save To DB
                _context.Add(viewModel.Interface);
                await _context.SaveChangesAsync();
                Interface @interface = await _context.Interfaces
                  .Where(x => x.InterfaceID == viewModel.Interface.InterfaceID)
                  .Include(y => y.AccessInterfaces)
                  .Include(t => t.EnumPhysical)
                  .Include(z => z.EnumMode)
                  .SingleOrDefaultAsync();


                foreach (AccessInterface accessInterface1 in newLines)
                {
                    //Add all selected EnumAccess
                    @interface.AccessInterfaces.Add(accessInterface1);
                }
                await _context.SaveChangesAsync();

                return Json(new
                {
                    //If modelstate is valid => return ViewALL
                    isValid = true,
                    html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.Interfaces.Include(x => x.EnumType)
                .Include(x => x.EnumPhysical)
                .Include(x => x.EnumMode)
                .ToListAsync())
                });

            }
            //If modelstate is invalid => return SelectLists
            viewModel.Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name", viewModel.Interface.EnumModeID);
            viewModel.AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name");
            viewModel.Types = new SelectList(_context.EnumTypes, "EnumTypeID", "Name");
            viewModel.Physicals = new SelectList(_context.EnumPhysicals, "EnumPhysicalID", "Name");
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", viewModel) });
        }

        [NoDirectAccessAttribute]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @interface = await _context.Interfaces.Include(x => x.AccessInterfaces).
                SingleOrDefaultAsync(y => y.InterfaceID == id);
            if (@interface.VlanId == 0)
            {
                @interface.VlanId = 1;
            }
            
            if (@interface == null)
            {
                return NotFound();
            }
            EditInterfaceViewModel viewModel = new EditInterfaceViewModel
            {
                Interface = @interface,
                IpAddress = @interface.Ip,
                Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name", @interface.EnumModeID),
                Types = new SelectList(_context.EnumTypes, "EnumTypeID", "Name", @interface.EnumTypeID),
                VlanName = @interface.Name,
                Physicals = new SelectList(_context.EnumPhysicals, "EnumPhysicalID", "Name",@interface.EnumPhysicalID),
                AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name"),
                SelectedEnumAcces = @interface.AccessInterfaces.Select(ai => ai.EnumAccesID)
            };

            return View(viewModel);
        }

        // POST: Interfacess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditInterfaceViewModel viewModel)
        {
            Interface @interface = await _context.Interfaces.Include(i => i.AccessInterfaces)
               .SingleOrDefaultAsync(x => x.InterfaceID == id);
            EnumPhysical physical = _context.EnumPhysicals.SingleOrDefault(x => x.EnumPhysicalID == viewModel.Interface.EnumPhysicalID);
            if (id != @interface.InterfaceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                @interface.Alias = viewModel.Interface.Alias;
                if (viewModel.Interface.EnumTypeID == 1)
                {
                    @interface.Name = physical.Name;
                    @interface.VlanId = 0;
                    @interface.VlanInterface = "NO_VLANInterface";
                }
                else
                {
                    @interface.Name = viewModel.VlanName;
                    @interface.VlanInterface = physical.Name;
                    @interface.VlanId = viewModel.Interface.VlanId;
                }
                @interface.Ip = viewModel.IpAddress;
                @interface.Subnet = viewModel.Interface.Subnet;
                @interface.EnumPhysicalID = viewModel.Interface.EnumPhysicalID;
                @interface.EnumTypeID = viewModel.Interface.EnumTypeID;
                @interface.EnumModeID = viewModel.Interface.EnumModeID;

                //Add all newly selected EnumAccess
                List<AccessInterface> accessInterfaces = new List<AccessInterface>();
                if (viewModel.SelectedEnumAcces == null)
                {
                    viewModel.SelectedEnumAcces = new List<int>();
                }
                foreach (int enumAccessID in viewModel.SelectedEnumAcces)
                {
                    accessInterfaces.Add(
                    new AccessInterface
                    {
                        EnumAccesID = enumAccessID,
                        InterfaceID = viewModel.Interface.InterfaceID
                    }
                  );
                }
                //removeall from interface to reset all enumAccess
                @interface.AccessInterfaces.RemoveAll(ai => !accessInterfaces.Contains(ai));
                @interface.AccessInterfaces.AddRange(accessInterfaces.Where(zi => !@interface.AccessInterfaces.Contains(zi)));
                
                    _context.Update(@interface);
                    await _context.SaveChangesAsync();
                
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", 
                    await _context.Interfaces.Include(y => y.EnumMode)
                    .Include(x=>x.EnumType)
                    .Include(x => x.EnumPhysical)
                    .ToListAsync()) });
            }
            // reset view with SelectLists
            viewModel.AccessList = new SelectList(_context.Interfaces, "InterfaceID", "Name");
            viewModel.SelectedEnumAcces = @interface.AccessInterfaces.Select(ai => ai.EnumAccesID);
            viewModel.Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name", @interface.EnumModeID);
            viewModel.Physicals = new SelectList(_context.EnumPhysicals, "EnumPhysicalID", "Name", @interface.EnumPhysicalID);
            viewModel.Types = new SelectList(_context.EnumTypes, "EnumTypeID", "Name", @interface.EnumTypeID);

            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", viewModel) });
        }

       

        // POST: Interfacess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @interface = await _context.Interfaces.FindAsync(id);
            _context.Interfaces.Remove(@interface);
            await _context.SaveChangesAsync();
            return Json(new
            {
                isValid = true,
                html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll",
                    await _context.Interfaces.Include(y => y.EnumMode)
                    .Include(x => x.EnumType)
                    .Include(x => x.EnumPhysical)
                    .ToListAsync())
            });
        }

        private bool InterfaceExists(int id)
        {
            return _context.Interfaces.Any(e => e.InterfaceID == id);
        }
    }
}
