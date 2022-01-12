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

namespace FictionalCustomer.UI.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly FictionalCustomer.UI.Data.ApplicationDbContext _context;

        public IndexModel(FictionalCustomer.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; }

        public async Task OnGetAsync()
        {
            Assignment = await _context.Assignments.ToListAsync();
        }
    }
}
