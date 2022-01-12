#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataModel.Models;
using FictionalCustomer.UI.Data;

namespace FictionalCustomer.UI.Pages.Programmers
{
    public class CreateModel : PageModel
    {
        private readonly FictionalCustomer.UI.Data.ApplicationDbContext _context;

        public CreateModel(FictionalCustomer.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Programmer Programmer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Programmer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
