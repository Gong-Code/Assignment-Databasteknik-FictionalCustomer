#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataModel.Models;
using FictionalCustomer.UI.Data;

namespace FictionalCustomer.UI.Pages.Programmers
{
    public class DetailsModel : PageModel
    {
        private readonly FictionalCustomer.UI.Data.ApplicationDbContext _context;

        public DetailsModel(FictionalCustomer.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Programmer Programmer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programmer = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (Programmer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
