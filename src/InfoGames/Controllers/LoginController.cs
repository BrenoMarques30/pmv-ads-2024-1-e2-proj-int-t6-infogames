using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using InfoGames.Helper;
using InfoGames.Models;
using InfoGames.Data;
using System.Diagnostics;

namespace InfoGames.Controllers;

public class LoginController : Controller {
    private readonly ISessao _sessao;
    private readonly ApplicationDbContext _db;

    public LoginController(ISessao sessao, ApplicationDbContext db) {

        _sessao = sessao;
        _db = db;
    }

    public IActionResult Index() {
        // Caso usuario esteja logado não voltar ao login
        //if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
        return View();
    }


    // GET: Login/Create
    public IActionResult Create() {
        return View();
    }

    // GET: Login/Reset
    public IActionResult Reset() {
        return View();
    }

    public IActionResult Sair() {
        _sessao.RemoverSessaoUsuario();
        return RedirectToAction("Index", "Login");
    }
    public Usuario? BuscarPorLogin(string email) {
        return _db.Usuario.FirstOrDefault(m => m.Email == email);
    }

    [HttpPost]
    public IActionResult Entrar(LoginModel loginModel) {
        try {

            if (ModelState.IsValid) {
                Usuario? usuario = BuscarPorLogin(loginModel.Login);
                Debug.WriteLine(usuario?.Email);
                if (usuario != null) {
                    if (usuario.SenhaValida(loginModel.Senha)) {
                        _sessao.CriarSessaoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["MensagemErro"] = $"Senha inválida. Por favor, tente novamente.";
                    return View("Index");
                }
                TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";


            }
            ViewBag.nomeUsuario = loginModel.Login;
            return View("Index");
        } catch (Exception erro) {
            TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Reset(LoginModel loginModel) {
        try {
            if (ModelState.IsValid) {
                Usuario? usuario = BuscarPorLogin(loginModel.Login);

                if (usuario != null) {
                    usuario.AtualizarSenha(loginModel.Senha);
                    _db.Update(usuario);
                    await _db.SaveChangesAsync();
                    TempData["AvisoSenha"] = $"Senha alterada com Sucesso! Considere agora se conectar.";
                    return View("Index");
                }
                TempData["MensagemErro"] = $"Email inválido. Por favor, tente novamente.";


            }

            return View("Index");
        } catch (Exception erro) {
            TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }
}

