using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto_Estoque.Views_Produtos
{
    public class CreateModel : PageModel
    {
        private readonly FabricaConexoes _context;

        public CreateModel(FabricaConexoes context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produtos Produtos { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.produtos.Add(Produtos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
