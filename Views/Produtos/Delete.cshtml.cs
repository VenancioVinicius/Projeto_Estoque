using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Estoque.Views_Produtos
{
    public class DeleteModel : PageModel
    {
        private readonly FabricaConexoes _context;

        public DeleteModel(FabricaConexoes context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.produtos.FindAsync(id);
            if (produtos != null)
            {
                Produtos = produtos;
                _context.produtos.Remove(Produtos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
