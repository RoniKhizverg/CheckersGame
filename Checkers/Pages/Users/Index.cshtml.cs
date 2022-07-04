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
    public class IndexModel : PageModel
    {
        private readonly Server.Data.ServerContext _context;

        public IndexModel(Server.Data.ServerContext context)
        {
            _context = context;
        }

        public IList<TblUsers> TblUsers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TblUsers != null)
            {
                TblUsers = await _context.TblUsers.ToListAsync();
            }
        }
    }
}
