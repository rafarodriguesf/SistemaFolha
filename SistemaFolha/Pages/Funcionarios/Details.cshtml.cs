using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaFolha.Data;
using SistemaFolha.Models;

namespace SistemaFolha.Pages.Funcionarios
{
    public class DetailsModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public DetailsModel(SistemaFolha.Data.SistemaFolhaContext context)
        {
            _context = context;
        }

      public Funcionario Funcionario { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            else
            {
                Funcionario = funcionario;
            }
            return Page();
        }
    }
}
