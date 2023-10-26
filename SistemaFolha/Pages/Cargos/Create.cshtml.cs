using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaFolha.Data;
using SistemaFolha.Models;

namespace SistemaFolha.Pages.Cargos
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
            return Page();
        }

        [BindProperty]
        public Cargo Cargo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cargo == null || Cargo == null)
            {
                return Page();
            }

            _context.Cargo.Add(Cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
