using Microsoft.AspNetCore.Mvc;
using toyEcommerce.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace toyEcommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CarrinhoRepositorio _carrinhoRepositorio;
        private readonly ProdutoRepositorio _produtoRepositorio;

        public CarrinhoController(CarrinhoRepositorio carrinhoRepositorio, ProdutoRepositorio produtoRepositorio)
        {
            _carrinhoRepositorio = carrinhoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }
        public async Task<IActionResult> Index()
        {
            var cartItems = _carrinhoRepositorio.CarrinhoItems(HttpContext.Session);

            foreach (var item in cartItems)
            {
                item.Produto = await _produtoRepositorio.ProdutosPorId(item.ProdutoId);

            }
            ViewBag.TotalCarrinho = _carrinhoRepositorio.TotalCarrinho(HttpContext.Session);
            return View(cartItems);
        }

        [HttpPost]

        public async Task<IActionResult> AdicionarCarrinho(int produtoId, int quantidade = 1)
        {
            var produto = await _produtoRepositorio.ProdutosPorId(produtoId);
            if (produto == null)
            {
                TempData["Message"] = "Produto não encontrado";
                return RedirectToAction("Index", "Home");
            }

            _carrinhoRepositorio.AdicionarCarrinho(HttpContext.Session, produto, quantidade);
            return RedirectToAction("Index", "Carrinho");
        }

        [HttpPost]
        public async Task<IActionResult> AlterarQuantidadeItem(int produtoId, int novaQuantidade){
            _carrinhoRepositorio.AlterarQuantidadeItem(HttpContext.Session, produtoId, novaQuantidade);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int produtoId)
        {
            _carrinhoRepositorio.RemoverItemCarrinho(HttpContext.Session, produtoId);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> LimparCarrinho()
        {
            _carrinhoRepositorio.LimparCarrinho(HttpContext.Session);
            return RedirectToAction("Index");

        }
    }
}
