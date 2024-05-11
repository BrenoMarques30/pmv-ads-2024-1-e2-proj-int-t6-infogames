using InfoGames.Data;
using InfoGames.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InfoGames.Middlewares {
    public class RecuperarJogos {
        public async void BuscarNaSteam(ApplicationDbContext _db) {

            var appListResponse = APICalls.GetApps();
            if (appListResponse == null) {
                Debug.WriteLine("Erro ao buscar lista de jogos na Steam");
                return;
            }

            // Remove espaços em branco no início do nome (se houver)
            foreach (var _jogo in appListResponse) {
                if (_jogo.Name is null) continue;
                if (_jogo.Name.Length > 0 && _jogo.Name[0] == ' ') _jogo.Name = new string(_jogo.Name.SkipWhile(c => c == ' ').ToArray());
            }

            // Ordena por nome
            var orderedApps = appListResponse.OrderBy(_jogo => _jogo.Name);


            var loja = _db.Lojas.FirstOrDefault(l => l.Nome == "Steam");
            if (loja == null) {
                Debug.WriteLine("Loja com nome 'Steam' não encontrada");
                return;
            }

            foreach (var _jogo in orderedApps) {
                if (_jogo.Name == "" || _jogo.Name == null || _jogo.Appid == null) continue;
                _db.Jogos.Add(new JogoModel { Id = Guid.NewGuid().ToString(), AppId = _jogo.Appid.ToString(), Nome = _jogo.Name, Loja = loja, LojaId = loja.Id });
            }
            try {
                // Attempt to update the entity in the database
                _db.Entry(loja).State = EntityState.Modified;
                _ = _db.SaveChanges();
            } catch (DbUpdateConcurrencyException ex) {
                // Handle the concurrency conflict
                // Reload the entity from the database to get the latest version
                await ex.Entries.Single().ReloadAsync();
                await _db.SaveChangesAsync();
                // Now you can try updating the entity again or handle the conflict as needed
                Debug.WriteLine("Erro ao atualizar o jogo no banco de dados: " + ex.Message + ex.HelpLink);
            }
            return;

        }
    }
}