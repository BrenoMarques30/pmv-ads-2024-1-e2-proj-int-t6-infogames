using InfoGames.Data;
using InfoGames.Models;
using InfoGames.Models.Steam;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Webm = InfoGames.Models.Webm;
using Mp4 = InfoGames.Models.Mp4;

namespace InfoGames.Middlewares {
    public class RecuperarDetalhes {
        public static JogoModel? BuscarNaSteam(JogoModel _jogo, ApplicationDbContext _db) {
            if (_jogo is null) {
                Debug.WriteLine("Jogo não encontrado.");
                return null;
            }

            AppData? APIResponse = APICalls.GetAppDetails(_jogo.AppId);
            if (APIResponse is null) {
                Debug.WriteLine("Falha ao buscar detalhes do app \"" + _jogo.Nome + "\" na Steam");
                return null;
            }

            var _detalhesJogo = new DetalhesJogoModel(APIResponse, _jogo);

            if (APIResponse?.FullGame is not null) {
                JogoCompleto _jogoCompleto = new(APIResponse.FullGame, _detalhesJogo);
                _detalhesJogo.JogoCompleto = _jogoCompleto;
                _ = _db.JogosCompletos.Add(_jogoCompleto);
            }

            if (APIResponse?.PriceOverview is not null) {
                DetalhesDoPreco _priceOverview = new(APIResponse.PriceOverview, _detalhesJogo);
                _detalhesJogo.DetalhesDoPreco = _priceOverview;
                _ = _db.DetalhesDePrecos.Add(_priceOverview);
            }

            if (APIResponse?.PcRequirements is not null && APIResponse?.PcRequirements.GetType() is object) {
                Requirements requirements = new() {
                    Minimum = APIResponse.PcRequirements.Requirements?.Minimum,
                    Recommended = APIResponse.PcRequirements.Requirements?.Recommended,
                };
                RequisitoPC _requisito = new(requirements, _detalhesJogo);
                _detalhesJogo.RequisitoPC = _requisito;
                _ = _db.RequisitosPC.Add(_requisito);
            }

            if (APIResponse?.MacRequirements is not null && APIResponse?.MacRequirements.GetType() is object) {
                Requirements requirements = new() {
                    Minimum = APIResponse.MacRequirements.Requirements?.Minimum,
                    Recommended = APIResponse.MacRequirements.Requirements?.Recommended,
                };
                RequisitoMac _requisito = new(requirements, _detalhesJogo);
                _detalhesJogo.RequisitoMac = _requisito;
                _ = _db.RequisitosMac.Add(_requisito);
            }

            if (APIResponse?.LinuxRequirements is not null && APIResponse?.LinuxRequirements.GetType() is object) {
                Requirements requirements = new() {
                    Minimum = APIResponse.LinuxRequirements.Requirements?.Minimum,
                    Recommended = APIResponse.LinuxRequirements.Requirements?.Recommended,
                };
                RequisitoLinux _requisito = new(requirements, _detalhesJogo);
                _detalhesJogo.RequisitoLinux = _requisito;
                _ = _db.RequisitosLinux.Add(_requisito);
            }

            if (APIResponse?.PackageGroups is not null) {
                _detalhesJogo.GrupoDePacotes = new List<GrupoDePacote>();
                foreach (var packageGroup in APIResponse.PackageGroups) {
                    GrupoDePacote _grupoDePacote = new(packageGroup, _detalhesJogo);

                    if (packageGroup?.Subs is not null) {
                        _grupoDePacote.Pacotes = new List<Pacote>();
                        foreach (var sub in packageGroup.Subs) {
                            Pacote _sub = new(sub, _grupoDePacote);

                            _grupoDePacote.Pacotes.Add(_sub);
                            _db.Pacotes.Add(_sub);
                        }
                    }
                    _detalhesJogo.GrupoDePacotes.Add(_grupoDePacote);
                    _ = _db.GruposDePacotes.Add(_grupoDePacote);
                }
            }

            if (APIResponse?.Platforms is not null) {
                Plataforma _platform = new(APIResponse.Platforms, _detalhesJogo);
                _detalhesJogo.Plataforma = _platform;
                _ = _db.Plataformas.Add(_platform);
            }

            if (APIResponse?.Metacritic is not null) {
                Metacritica _metacritic = new(APIResponse.Metacritic, _detalhesJogo);
                _detalhesJogo.Metacritica = _metacritic;
                _ = _db.Metacriticas.Add(_metacritic);
            }

            if (APIResponse?.Categories is not null) {
                _detalhesJogo.Categoria = new List<Categoria>();
                foreach (var category in APIResponse.Categories) {
                    Categoria _category = new(category, _detalhesJogo);
                    _detalhesJogo.Categoria.Add(_category);
                    _ = _db.Categorias.Add(_category);
                }
            }

            if (APIResponse?.Genres is not null) {
                _detalhesJogo.Genero = new List<Generos>();
                foreach (var genre in APIResponse.Genres) {
                    Generos _genre = new(genre, _detalhesJogo);
                    _detalhesJogo.Genero.Add(_genre);
                    _ = _db.Generos.Add(_genre);
                }
            }

            if (APIResponse?.Screenshots is not null) {
                _detalhesJogo.Screenshot = new List<Screenshot>();
                foreach (var screenshot in APIResponse.Screenshots) {
                    Screenshot _screenshot = new(screenshot, _detalhesJogo);
                    _detalhesJogo.Screenshot.Add(_screenshot);
                    _ = _db.Screenshots.Add(_screenshot);
                }
            }

            if (APIResponse?.Movies is not null) {
                _detalhesJogo.Filme = new List<Filme>();
                foreach (var movie in APIResponse.Movies) {
                    Filme _movie = new(movie, _detalhesJogo);

                    if (movie.Webm is not null) {
                        Webm _webm = new(movie.Webm, _movie);
                        _movie.Webm = _webm;
                    }

                    if (movie.Mp4 is not null) {
                        Mp4 _mp4 = new(movie.Mp4, _movie);
                        _movie.Mp4 = _mp4;
                    }

                    _detalhesJogo.Filme.Add(_movie);
                    _ = _db.Filmes.Add(_movie);
                }
            }

            if (APIResponse?.Achievements is not null) {
                Conquista _conquista = new(APIResponse.Achievements, _detalhesJogo);

                if (APIResponse.Achievements.Highlighted is not null) {
                    _conquista.Destaque = new List<Destaque>();
                    foreach (var highlighted in APIResponse.Achievements.Highlighted) {
                        Destaque _destaque = new(highlighted, _conquista);
                        _conquista.Destaque.Add(_destaque);
                        _ = _db.Destaques.Add(_destaque);
                    }
                }
                _detalhesJogo.Conquista = _conquista;
                _ = _db.Conquistas.Add(_conquista);
            }

            if (APIResponse?.ReleaseDate is not null) {
                var _releaseDate = new DataDeLancamento(APIResponse.ReleaseDate, _detalhesJogo);

                _detalhesJogo.DataDeLancamento = _releaseDate;
                _ = _db.DatasDeLancamento.Add(_releaseDate);
            }

            if (APIResponse?.SupportInfo is not null) {
                InformacaoDeSuporte _supportInfo = new(APIResponse.SupportInfo, _detalhesJogo);
                _detalhesJogo.InformacaoDeSuporte = _supportInfo;
                _ = _db.InformacoesDeSuporte.Add(_supportInfo);
            }

            if (APIResponse?.ContentDescriptors is not null) {
                DescritorDeConteudo _contentDescriptors = new(APIResponse.ContentDescriptors, _detalhesJogo);
                _detalhesJogo.DescritorDeConteudo = _contentDescriptors;
                _ = _db.DescritoresDeConteudo.Add(_contentDescriptors);
            }

            if (APIResponse?.Ratings?.Dejus is not null) {
                ClassificacaoIndicativa _dejus = new(APIResponse.Ratings, _detalhesJogo);
                _detalhesJogo.Classificacao = _dejus;
                _ = _db.ClassificacoesIndicativas.Add(_dejus);

            }

            if (APIResponse?.Demos is not null) {
                _detalhesJogo.Demonstracao = new List<Demonstracoes>();
                foreach (var demo in APIResponse.Demos) {
                    if (demo is null) {
                        Debug.WriteLine("Appid da demo não encontrado.");
                        continue;
                    }
                    Demonstracoes _demonstracao = new(demo, _detalhesJogo);
                    _detalhesJogo.Demonstracao.Add(_demonstracao);
                    _ = _db.Demos.Add(_demonstracao);
                }
            }

            _jogo.DetalhesJogo = _detalhesJogo;
            _db.Jogos.Update(_jogo);

            try {
                // Attempt to update the entity in the database
                _db.Entry(_jogo).State = EntityState.Modified;
                _ = _db.SaveChanges();
            } catch (DbUpdateConcurrencyException ex) {
                // Handle the concurrency conflict
                // Reload the entity from the database to get the latest version
                _ = ex.Entries.Single().ReloadAsync();
                _ = _db.SaveChangesAsync();
                // Now you can try updating the entity again or handle the conflict as needed
                Debug.WriteLine("Erro ao atualizar o app \"" + _jogo.Nome + "\"no banco de dados: " + ex.Message + ex.HelpLink);
            }
            return _jogo;
        }

        public static JogoModel? BuscarNoBancoDeDados(JogoModel _jogo, ApplicationDbContext _db) {
            if (_jogo is null) {
                Debug.WriteLine("Jogo é null");
                return null;
            }
            _jogo.DetalhesJogo = BuscarDetalhes.PorIdJogo(_jogo.Id, _db);
            if (_jogo.DetalhesJogo == null) {
                Debug.WriteLine("Detalhes do Jogo não encontrados no banco de dados.");
                return BuscarNaSteam(_jogo, _db);
            }
            _jogo.DetalhesJogo.JogoCompleto = _db.JogosCompletos.FirstOrDefault(jc => jc.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.RequisitoPC = _db.RequisitosPC.FirstOrDefault(r => r.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.RequisitoMac = _db.RequisitosMac.FirstOrDefault(r => r.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.RequisitoLinux = _db.RequisitosLinux.FirstOrDefault(r => r.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.DetalhesDoPreco = _db.DetalhesDePrecos.FirstOrDefault(dp => dp.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.GrupoDePacotes = _db.GruposDePacotes.Where(gp => gp.IdDetalhesJogo == _jogo.DetalhesJogo.Id).ToList();
            foreach (var gp in _jogo.DetalhesJogo.GrupoDePacotes) {
                gp.Pacotes = _db.Pacotes.Where(p => p.IdGrupoDePacote == gp.Id).ToList();
            }
            _jogo.DetalhesJogo.Plataforma = _db.Plataformas.FirstOrDefault(p => p.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.Metacritica = _db.Metacriticas.FirstOrDefault(m => m.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.Categoria = _db.Categorias.Where(c => c.IdDetalhesJogo == _jogo.DetalhesJogo.Id).ToList();
            _jogo.DetalhesJogo.Genero = _db.Generos.Where(g => g.IdDetalhesJogo == _jogo.DetalhesJogo.Id).ToList();
            _jogo.DetalhesJogo.Screenshot = _db.Screenshots.Where(s => s.IdDetalhesJogo == _jogo.DetalhesJogo.Id).ToList();
            _jogo.DetalhesJogo.Filme = _db.Filmes.Where(f => f.IdDetalhesJogo == _jogo.DetalhesJogo.Id).ToList();
            foreach (var f in _jogo.DetalhesJogo.Filme) {
                f.Mp4 = _db.Mp4s.FirstOrDefault(m => m.IdFilme == f.Id);
                f.Webm = _db.Webms.FirstOrDefault(w => w.IdFilme == f.Id);
            }
            _jogo.DetalhesJogo.Conquista = _db.Conquistas.FirstOrDefault(c => c.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.DataDeLancamento = _db.DatasDeLancamento.FirstOrDefault(d => d.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.InformacaoDeSuporte = _db.InformacoesDeSuporte.FirstOrDefault(i => i.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.DescritorDeConteudo = _db.DescritoresDeConteudo.FirstOrDefault(d => d.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.Classificacao = _db.ClassificacoesIndicativas.FirstOrDefault(c => c.IdDetalhesJogo == _jogo.DetalhesJogo.Id);
            _jogo.DetalhesJogo.Demonstracao = _db.Demos.Where(d => d.IdDetalhesJogo == _jogo.DetalhesJogo.Id).ToList();


            return _jogo;
        }
    }
}