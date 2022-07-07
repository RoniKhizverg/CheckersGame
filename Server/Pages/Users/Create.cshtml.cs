using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Server.Data;
using Server.Model;

namespace Server.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly Server.Data.ServerContext _context;

        public CreateModel(Server.Data.ServerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblUsers TblUsers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblUsers.Add(TblUsers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
