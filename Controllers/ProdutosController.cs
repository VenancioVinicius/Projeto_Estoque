using Microsoft.AspNetCore.Mvc;

public class ProdutosController : Controller
{

    private readonly FabricaConexoes conexoes;

    public ProdutosController(FabricaConexoes linkproduto)
    {
        conexoes = linkproduto;
    }

    public IActionResult Index()
    {

        return View(conexoes.produtos.ToList());

    }
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Produtos produtos)
    {
        conexoes.produtos.Add(produtos);
        conexoes.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var produto = conexoes.produtos.Find(id);
        return View(produto);
    }

    [HttpPost]
    public IActionResult Edit(Produtos produtos)
    {
        conexoes.produtos.Update(produtos);
        conexoes.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var produto = conexoes.produtos.Find(id);
        return View(produto);
    }

    public IActionResult Delete(int id)
    {
        var produto = conexoes.produtos.Find(id);
        return View(produto);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var produto = conexoes.produtos.Find(id);

        if (produto != null)
        {
            conexoes.produtos.Remove(produto);
            conexoes.SaveChanges();
        }
        return RedirectToAction("Index");
    }

}