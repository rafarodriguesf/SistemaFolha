using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFolha.Data;
using SistemaFolha.Models;

namespace SistemaFolha.Pages.FeriasView
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
        ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
            return Page();
        }

        [BindProperty]
        public Ferias Ferias { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Ferias == null || Ferias == null)
          //  {
          //      return Page();
          //  }

            _context.Ferias.Add(Ferias);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
