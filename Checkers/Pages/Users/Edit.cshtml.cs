﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Model;

namespace Server.Users
{
    public class EditModel : PageModel
    {
        private readonly Server.Data.ServerContext _context;

        public EditModel(Server.Data.ServerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblUsers TblUsers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tblusers =  await _context.TblUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (tblusers == null)
            {
                return NotFound();
            }
            TblUsers = tblusers;
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

            _context.Attach(TblUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsersExists(TblUsers.Id))
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

        private bool TblUsersExists(int id)
        {
          return (_context.TblUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
