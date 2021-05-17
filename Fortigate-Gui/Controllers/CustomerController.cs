using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Identity;
using Fortigate_Gui.Areas.Identity.Data;

namespace Fortigate_Gui.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;

        public CustomerController(ApplicationDbContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            //Get customer and Information of CustomUsers
            List<Customer> customers = await _context.Customers.Include(c => c.CustomUser).ToListAsync();
            return View(customers);
        }

        // GET: Customer/Details/5
        // Details gives Link with identityUser
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = await _context.Customers
                .Include(c => c.CustomUser)
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }    

        // GET: Customer/ChangeAdminStatus/5
        // Here can the administrator adjust other user to admin
        public async Task<IActionResult> ChangeAdminStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = await _context.Customers
                .Include(c => c.CustomUser)
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        //POST:Customer/ChangeAdminStatus/5
        [HttpPost, ActionName("ChangeAdminStatus")]
        [ValidateAntiForgeryToken]
        // Here can the administrator adjust other user to admin
        public async Task<IActionResult> ChangeAdminStatus(int id)
        {
            Customer customer = await _context.Customers
                 .Include(c => c.CustomUser)
                 .FirstOrDefaultAsync(m => m.CustomerID == id);
            //make user admin
            if (customer.Admin == false)
            {
                await _userManager.AddToRoleAsync(customer.CustomUser, "Admin");
                customer.Admin = true;
            }
            //Remove user admin
            else
            {
                await _userManager.RemoveFromRoleAsync(customer.CustomUser, "Admin");
                customer.Admin = false;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
