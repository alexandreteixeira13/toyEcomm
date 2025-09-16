using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using toyEcommerce.Models;
using toyEcommerce.Repository;

namespace toyEcommerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProdutoRepositorio _produtoRepositorio;

    public HomeController(ILogger<HomeController> logger, ProdutoRepositorio produtoRepositorio)
    {
        _logger = logger;
        _produtoRepositorio = produtoRepositorio;

    }
    
    

    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoRepositorio.TodosProdutos();
        return View(produtos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}