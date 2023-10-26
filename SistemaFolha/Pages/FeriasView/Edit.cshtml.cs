using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaFolha.Data;
using SistemaFolha.Models;

namespace SistemaFolha.Pages.FeriasView
{
    public class EditModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public EditModel(SistemaFolha.Data.SistemaFolhaContext context)
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

            var ferias =  await _context.Ferias.FirstOrDefaultAsync(m => m.FeriasId == id);
            if (ferias == null)
            {
                return NotFound();
            }
            Ferias = ferias;
           ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
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

            _context.Attach(Ferias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriasExists(Ferias.FeriasId))
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

        private bool FeriasExists(int id)
        {
          return (_context.Ferias?.Any(e => e.FeriasId == id)).GetValueOrDefault();
        }
    }
}
