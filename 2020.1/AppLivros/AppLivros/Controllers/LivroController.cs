﻿using AppLivros.Dados;
using AppLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppLivros.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            int id = BancoDeDados.Instance().GetAll().Count + 1;
            livro.Id = id;

            BancoDeDados.Instance().Add(livro);

            ViewData["exibirAlert"] = true;

            ModelState.Clear();

            return View("Cadastrar");
        }

        public IActionResult Deletar(int id)
        {
            BancoDeDados.Instance().Remover(id);
            return RedirectToAction("Index", "Home");
        }
    }
}