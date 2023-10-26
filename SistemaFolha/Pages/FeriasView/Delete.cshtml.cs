using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaFolha.Data;
using SistemaFolha.Models;

namespace SistemaFolha.Pages.FeriasView
{
    public class DeleteModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public DeleteModel(SistemaFolha.Data.SistemaFolhaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ferias Ferias { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ferias == null)
            {
                return NotFound();
            }

            var ferias = await _context.Ferias.FirstOrDefaultAsync(m => m.FeriasId == id);

            if (ferias == null)
            {
                return NotFound();
            }
            else 
            {
                Ferias = ferias;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ferias == null)
            {
                return NotFound();
            }
            var ferias = await _context.Ferias.FindAsync(id);

            if (ferias != null)
            {
                Ferias = ferias;
                _context.Ferias.Remove(Ferias);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
