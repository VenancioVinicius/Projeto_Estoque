using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Estoque.Views_Produtos
{
    public class DetailsModel : PageModel
    {
        private readonly FabricaConexoes _context;

        public DetailsModel(FabricaConexoes context)
        {
            _context = context;
        }

        public Produtos Produtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.produtos.FirstOrDefaultAsync(m => m.id == id);

            if (produtos is not null)
            {
                Produtos = produtos;

                return Page();
            }

            return NotFound();
        }
    }
}
