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
    public class DetailsModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public DetailsModel(SistemaFolha.Data.SistemaFolhaContext context)
        {
            _context = context;
        }

      public Ferias Ferias { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //if (id == null || _context.Ferias == null)
            //{
            //    return NotFound();
            //}

            var ferias = await _context.Ferias.FirstOrDefaultAsync(m => m.FeriasId == id);
            if (ferias == null)
            {
            //    return NotFound();
            //}
            //else 
            //{
                Ferias = ferias;
            }
            return Page();
        }
    }
}
