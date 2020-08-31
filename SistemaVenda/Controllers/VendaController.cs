using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public VendaController(IServicoAplicacaoProduto servicoAplicacaoProduto,
            IServicoAplicacaoCliente servicoAplicacaoCliente,
            IServicoAplicacaoVenda servicoAplicacaoVenda)
        {
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoVenda.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();

            if(id != null)
            {
                viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            viewModel.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid) /*ModelState verifica o data anotation da model (CategoriaViewModel)*/
            {
                ServicoAplicacaoVenda.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaClientes = ServicoAplicacaoCliente.ListaClientesDropDownList();
                entidade.ListaProdutos = ServicoAplicacaoProduto.ListaProdutosDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoVenda.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
        }
    }
}
