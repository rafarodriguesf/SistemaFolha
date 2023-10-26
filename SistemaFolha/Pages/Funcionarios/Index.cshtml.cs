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
    public class IndexModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public IndexModel(SistemaFolha.Data.SistemaFolhaContext context)
        {
            _context = context;
        }

        public IList<Funcionario> Funcionario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Funcionario != null)
            {
                Funcionario = await _context.Funcionario
                .Include(f => f.Cargo).ToListAsync();
            }
        }
    }
}
