using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFolha.Data;
using SistemaFolha.Models;

namespace SistemaFolha.Pages.Funcionarios
{
    public class CreateModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public CreateModel(SistemaFolha.Data.SistemaFolhaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "NomeCargo");
            return Page();
        }

        [BindProperty]
        public Funcionario Funcionario { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Funcionario == null || Funcionario == null)
            //{
            //    return Page();
            //}

            _context.Funcionario.Add(Funcionario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
