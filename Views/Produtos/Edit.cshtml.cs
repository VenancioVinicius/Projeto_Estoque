using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Estoque.Views_Produtos
{
    public class EditModel : PageModel
    {
        private readonly FabricaConexoes _context;

        public EditModel(FabricaConexoes context)
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

            var produtos =  await _context.produtos.FirstOrDefaultAsync(m => m.id == id);
            if (produtos == null)
            {
                return NotFound();
            }
            Produtos = produtos;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(Produtos.id))
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

        private bool ProdutosExists(int id)
        {
            return _context.produtos.Any(e => e.id == id);
        }
    }
}
