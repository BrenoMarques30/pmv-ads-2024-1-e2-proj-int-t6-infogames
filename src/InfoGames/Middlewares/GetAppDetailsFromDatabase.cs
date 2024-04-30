using InfoGames.Data;
using InfoGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoGames.Middlewares {
    public class GetAppDetailsFromDatabase : Controller {

        public async Task<IActionResult> Index(Jogo app, ApplicationDbContext _db) {
            app.DetalhesJogo = _db.DetalhesJogos.FirstOrDefault(j => j.IdJogo == app.Id);
            if (app.DetalhesJogo == null) {
                return NotFound();
            }
            app.DetalhesJogo.JogoCompleto = _db.JogosCompletos.FirstOrDefault(jc => jc.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.RequisitoPC = _db.RequisitosPC.FirstOrDefault(r => r.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.RequisitoMac = _db.RequisitosMac.FirstOrDefault(r => r.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.RequisitoLinux = _db.RequisitosLinux.FirstOrDefault(r => r.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.DetalhesDoPreco = _db.DetalhesDePrecos.FirstOrDefault(dp => dp.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.GrupoDePacotes = _db.GruposDePacotes.Where(gp => gp.IdDetalhesJogo == app.DetalhesJogo.Id).ToList();
            foreach (var gp in app.DetalhesJogo.GrupoDePacotes) {
                gp.Pacotes = _db.Pacotes.Where(p => p.IdGrupoDePacote == gp.Id).ToList();
            }
            app.DetalhesJogo.Plataforma = _db.Plataformas.FirstOrDefault(p => p.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.Metacritica = _db.Metacriticas.FirstOrDefault(m => m.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.Categoria = _db.Categorias.Where(c => c.IdDetalhesJogo == app.DetalhesJogo.Id).ToList();
            app.DetalhesJogo.Genero = _db.Generos.Where(g => g.IdDetalhesJogo == app.DetalhesJogo.Id).ToList();
            app.DetalhesJogo.Screenshot = _db.Screenshots.Where(s => s.IdDetalhesJogo == app.DetalhesJogo.Id).ToList();
            app.DetalhesJogo.Filme = _db.Filmes.Where(f => f.IdDetalhesJogo == app.DetalhesJogo.Id).ToList();
            foreach (var f in app.DetalhesJogo.Filme) {
                f.Mp4 = _db.Mp4s.FirstOrDefault(m => m.IdFilme == f.Id);
                f.Webm = _db.Webms.FirstOrDefault(w => w.IdFilme == f.Id);
            }
            app.DetalhesJogo.Conquista = _db.Conquistas.FirstOrDefault(c => c.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.DataDeLancamento = _db.DatasDeLancamento.FirstOrDefault(d => d.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.InformacaoDeSuporte = _db.InformacoesDeSuporte.FirstOrDefault(i => i.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.DescritorDeConteudo = _db.DescritoresDeConteudo.FirstOrDefault(d => d.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.Classificacao = _db.ClassificacoesIndicativas.FirstOrDefault(c => c.IdDetalhesJogo == app.DetalhesJogo.Id);
            app.DetalhesJogo.Demonstracao = _db.Demos.Where(d => d.IdDetalhesJogo == app.DetalhesJogo.Id).ToList();


            return RedirectToAction("Detalhes", app);
        }
    }
}
