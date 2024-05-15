using InfoGames.Data;
using InfoGames.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Policy;
using System.ServiceModel.Syndication;


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

        public async void BuscarNaSteamXML(ApplicationDbContext db, string AppId) {
            var appNewsResponse = APICalls.GetAppNewsXML(AppId);
            if (appNewsResponse == null) {
                Debug.WriteLine("Erro ao buscar notícias do jogo na Steam");
                return;
            }
            if (appNewsResponse.Items == null) {
                Debug.WriteLine("Nenhuma notícia encontrada para esse jogo");
                return;
            }
            var jogo = db.Jogos.FirstOrDefault(j => j.AppId == AppId);
            if (jogo == null) {
                Debug.WriteLine("Jogo com AppId " + AppId + " não encontrado");
                return;
            }

            foreach (var _noticia in appNewsResponse.Items) {
                if (_noticia.Title == null) continue;
                var _publishDate = _noticia.PublishDate;
                DateTime dateTime = new DateTime(_publishDate.Year, _publishDate.Month, _publishDate.Day);
                var unixDate = new DateTimeOffset(dateTime).ToUnixTimeSeconds();
                string url = "";
                string thumbnail = "https://cdn.akamai.steamstatic.com/steam/apps/" + AppId + "/capsule_616x353.jpg";
                foreach (var link in _noticia.Links) {
                    if (link.RelationshipType == "enclosure") {
                        thumbnail = link.Uri.OriginalString;
                    } else if (link.RelationshipType == "alternate") {
                        url = link.Uri.OriginalString;
                    }
                }
                db.Noticias.Add(new NoticiaModel {
                    Id = Guid.NewGuid().ToString(),
                    Jogo = jogo,
                    JogoId = jogo.Id,
                    AppId = AppId,
                    Titulo = _noticia.Title.Text,
                    Url = url,
                    Thumbnail = thumbnail,
                    Conteudo = _noticia.Summary.Text,
                    Data = unixDate.ToString()
                });
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
