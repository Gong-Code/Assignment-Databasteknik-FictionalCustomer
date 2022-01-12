#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModel.Models;
using FictionalCustomer.UI.Data;

namespace FictionalCustomer.UI.Pages.Programmers
{
    public class EditModel : PageModel
    {
        private readonly FictionalCustomer.UI.Data.ApplicationDbContext _context;

        public EditModel(FictionalCustomer.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Programmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammerExists(Programmer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProgrammerExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
