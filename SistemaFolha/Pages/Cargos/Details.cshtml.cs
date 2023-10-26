﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaFolha.Data;
using SistemaFolha.Models;

namespace SistemaFolha.Pages.Cargos
{
    public class DetailsModel : PageModel
    {
        private readonly SistemaFolha.Data.SistemaFolhaContext _context;

        public DetailsModel(SistemaFolha.Data.SistemaFolhaContext context)
        {
            _context = context;
        }

      public Cargo Cargo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cargo == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FirstOrDefaultAsync(m => m.CargoId == id);
            if (cargo == null)
            {
                return NotFound();
            }
            else 
            {
                Cargo = cargo;
            }
            return Page();
        }
    }
}
