using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Estoque.Views_Produtos
{
    public class IndexModel : PageModel
    {
        private readonly FabricaConexoes _context;

        public IndexModel(FabricaConexoes context)
        {
            _context = context;
        }

        public IList<Produtos> Produtos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produtos = await _context.produtos.ToListAsync();
        }
    }
}
