#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataModel.Models;

namespace FictionalCustomer.UI.Pages.Programmers
{
    public class IndexModel : PageModel
    {
        private readonly FictionalCustomer.UI.Data.ApplicationDbContext _context;

        public IndexModel(FictionalCustomer.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Programmer> Programmer { get;set; }

        public async Task OnGetAsync()
        {
            Programmer = await _context.Employees.ToListAsync();
        }
    }
}
