using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using InfoGames.Models;
using InfoGames.Data;

namespace InfoGames.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsuariosController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _db.Usuario.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _db.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NomeDeUsuario,Senha,Email,Token,DataNascimento,ContaSuspensa,ContaRestrita,SteamIdVinculado,EmailVerificado")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _db.Add(usuario);
                await _db.SaveChangesAsync();

                // Verificar se o cabeçalho Referer está presente na requisição
                if (Request.Headers.ContainsKey("Referer"))
                {
                    // Obter o URL da página anterior a partir do cabeçalho Referer
                    string returnUrl = Request.Headers["Referer"].ToString();

                    // Adiciona a mensagem na sessão
                    TempData["Mensagem"] = "Usuário cadastrado com sucesso!";


                    // Redirecionar de volta para a página anterior
                    return Redirect(returnUrl);
                }
                else
                {
                    // Se o cabeçalho Referer não estiver presente, redirecione para uma página padrão
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NomeDeUsuario,Senha,Email,Token,DataNascimento,ContaSuspensa,ContaRestrita,SteamIdVinculado,EmailVerificado")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(usuario);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _db.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _db.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _db.Usuario.Remove(usuario);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _db.Usuario.Any(e => e.Id == id);
        }
    }
}
