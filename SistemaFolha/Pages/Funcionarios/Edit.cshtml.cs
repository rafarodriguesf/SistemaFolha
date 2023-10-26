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

namespace SistemaFolha.Pages.Funcionarios
{
    public class EditModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public EditModel(SistemaFolha.Data.SistemaFolhaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcionario Funcionario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario =  await _context.Funcionario.FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            Funcionario = funcionario;
           ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(Funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(Funcionario.FuncionarioId))
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

        private bool FuncionarioExists(int id)
        {
          return (_context.Funcionario?.Any(e => e.FuncionarioId == id)).GetValueOrDefault();
        }
    }
}
