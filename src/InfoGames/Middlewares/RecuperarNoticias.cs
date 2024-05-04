using InfoGames.Data;
using InfoGames.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace InfoGames.Middlewares {
    public class RecuperarNoticias {
        public async void BuscarNaSteam(ApplicationDbContext db, string AppId, string NumeroDeNoticias) {

            var appNewsResponse = APICalls.GetAppNews(AppId, NumeroDeNoticias);
            if (appNewsResponse == null) {
                Debug.WriteLine("Erro ao buscar notícias do jogo na Steam");
                return;
            }
            if (appNewsResponse.NewsItems == null) {
                Debug.WriteLine("Nenhuma notícia encontrada para esse jogo");
                return;
            }

            var jogo = db.Jogos.FirstOrDefault(j => j.AppId == AppId);
            if (jogo == null) {
                Debug.WriteLine("Jogo com AppId " + AppId + " não encontrado");
                return;
            }

            foreach (var _noticia in appNewsResponse.NewsItems) {
                if (_noticia.Title == "" || _noticia.Title == null) continue;
                db.Noticias.Add(new NoticiaModel { Id = Guid.NewGuid().ToString(), Jogo = jogo, JogoId = jogo.Id, Titulo = _noticia.Title, Conteudo = _noticia.Contents, Data = _noticia.Date });
            }
            try {
                // Attempt to update the entity in the database
                _ = db.SaveChanges();
            } catch (DbUpdateConcurrencyException ex) {
                // Handle the concurrency conflict
                // Reload the entity from the database to get the latest version
                await ex.Entries.Single().ReloadAsync();
                await db.SaveChangesAsync();
                // Now you can try updating the entity again or handle the conflict as needed
                Debug.WriteLine("Erro ao atualizar a notícia no banco de dados: " + ex.Message + ex.HelpLink);
            }
            return;
        }
    }
}
