using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Model;

namespace Server.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Server.Data.ServerContext _context;

        public DetailsModel(Server.Data.ServerContext context)
        {
            _context = context;
        }

        public TblUsers TblUsers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblUsers = await _context.TblUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (TblUsers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
