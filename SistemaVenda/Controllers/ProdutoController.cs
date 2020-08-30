﻿using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class ProdutoController : Controller
    {
        
        readonly IServicoAplicacaoProduto ServicoAplicacao;
        readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public ProdutoController(IServicoAplicacaoProduto servicoAplicacao,
            IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacao = servicoAplicacao;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacao.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();

            
            if (id != null)
            {
                viewModel = ServicoAplicacao.CarregarRegistro((int)id);
            }

            viewModel.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid) /*ModelState verifica o data anotation da model (CategoriaViewModel)*/
            {
                ServicoAplicacao.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaCategorias = ServicoAplicacaoCategoria.ListaCategoriasDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            ServicoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
