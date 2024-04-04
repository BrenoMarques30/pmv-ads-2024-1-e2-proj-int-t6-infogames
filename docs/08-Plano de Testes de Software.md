# Plano de Testes de Software

| Caso de Teste       | CT-01 – Cadastrar perfil                                                                                                     |
| ------------------- | ---------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-01 - Permitir que o usuário crie e gerencie seu perfil na plataforma.                                                     |
| Objetivo do Teste   | Verificar se o usuário consegue se cadastrar na aplicação.                                                                   |
| Passos              | 1. Selecionar "Entrar";<br>2. Selecionar "Cadastre-se";<br>3. Preencher os campos obrigatórios;<br>4. Selecionar "Registrar" |
| Critério de Êxito   | - O cadastro foi realizado com sucesso e o usuário consegue fazer log in.                                                    |

| Caso de Teste       | CT-02 – Editar perfil                                                                                                                  |
| ------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-01 - Permitir que o usuário crie e gerencie seu perfil na plataforma.                                                               |
| Objetivo do Teste   | Verificar se o usuário consegue modificar as informações do seu perfil                                                                 |
| Prerequisitos       | 1. O usuário está logado                                                                                                               |
| Passos              | 1. Selecionar "Perfil" (ícone do avatar);<br>2. Selecionar "Editar";<br>3. Preencher os campos obrigatórios;<br>4. Selecionar "Salvar" |
| Critério de Êxito   | - As informações são salvas com sucesso.                                                                                               |

| Caso de Teste       | CT-03 – Bloqueio de interação para menores de 13 anos                                                                                        |
| ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-02 - Proibir interação de usuários menores de 13 anos com demais                                                                          |
| Objetivo do Teste   | Verificar se o usuário com menos de 13 anos consegue comentar em notícias                                                                    |
| Prerequisitos       | 1. O usuário está logado                                                                                                                     |
| Passos              | 1. Selecionar "Portal de notícias";<br>2. Sob uma notícia, selecionar o ícone de comentários;<br>3. Procurar pelo campo de envio de mensagem |
| Critério de Êxito   | - Campo de comentário está desativado para menores de 13 anos                                                                                |

| Caso de Teste       | CT-04 – Exibição notícias relevantes e atuais                                                        |
| ------------------- | ---------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-05 - Exibir notícias atualizadas sobre jogos que o usuário possui e/ou segue (Portal de notícias) |
| Objetivo do Teste   | Verificar se notícias atualizadas são exibidas no feed do usuário                                    |
| Prerequisitos       | 1. O usuário está logado;<br>2. O usuário acionou alguns jogos aos seus favoritos                    |
| Passos              | 1. Selecionar "Portal de notícias";<br>2. Verificar as notícias disponíveis                          |
| Critério de Êxito   | - As notícias exibidas são relevantes (baseadas nos favoritos do usuário) e atuais                   |

| Caso de Teste       | CT-05 – Personalização feed de notícias                                                                                                                                      |
| ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-06 - Permitir o usuário personalizar seu portal de notícias.                                                                                                              |
| Objetivo do Teste   | Verificar que o usuário é capaz de personalizar seu feed de notícias                                                                                                         |
| Prerequisitos       | 1. O usuário está logado;<br>2. O usuário acionou alguns jogos aos seus favoritos                                                                                            |
| Passos              | 1. Selecionar "Portal de notícias";<br>2. Selecionar "Gerenciar favoritos";<br>3. Remover um jogo da lista;<br>4. No campo de pesquisa, procurar por outro jogo;<br>5. Teste |
| Critério de Êxito   | - As notícias exibidas são relevantes (baseadas nos favoritos do usuário) e atuais                                                                                           |

| Caso de Teste       | CT-06 – Interação de usuário por comentários e curtidas                                                                                                     |
| ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-07 - Permitir o usuário curtir e comentar nas notícias.                                                                                                  |
| Objetivo do Teste   | Verificar se notícias possuem campo de comentários e curtir                                                                                                 |
| Prerequisitos       | 1. O usuário está logado;<br>2. As notícias têm comentários e curtidas                                                                                      |
| Passos              | 1. Selecionar "Portal de notícias";<br>2. Sob uma notícia, selecionar o ícone de comentários;<br>3. Escrever um comentário e enviar;<br>4. Curtir a notícia |
| Critério de Êxito   | - As notícias são exibidas com número de curtidas, é possível ver comentários de outros usuários e adicionar mais comentários                               |

| Caso de Teste       | CT-07 – Pesquisar jogos                                                                        |
| ------------------- | ---------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-11 - Permitir a pesquisa de jogos disponíveis na loja por nome e gênero                     |
| Objetivo do Teste   | Verificar que é possivel pesquisar jogos por nome e gênero                                     |
| Passos              | 1. No campo de pesquisa, digitar o nome de um jogo (ex.: Dota);<br>2. Selecionar a tecla Enter |
| Critério de Êxito   | O jogo pesquisado é exibido como resultado. Jogos similares também são exibidos                |

| Caso de Teste       | CT-08 – Filtrar resultados                                                                                                           |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| Requisito Associado | RF-12 - Permitir a filtrar e/ou ordenar a lista de resultados de pesquisa por classificação, preço, desconto e/ou data de lançamento |
| Objetivo do Teste   | Verificar que é possível filtrar e ordenar resultados                                                                                |
| Prerequisitos       | 1. Usuário está na tela de resultados da pesquisa (CT-07)                                                                            |
| Passos              | 1. Clicar no botão de filtros;<br>2. Selecionar um tipo de filtro e ordenamento;<br>3. Aplicar o filtro                              |
| Critério de Êxito   | A lista de resultados é atualizada baseada nos parâmetros de pesquisa, filtro e ordenamento                                          |

| Caso de Teste       | CT-09 – Filtragem de conteúdo adulto                                                                                                      |
| ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| Requisito Associado | RF-15 - Proibir que usuários menores de 18 acessem conteúdo de jogos restritos                                                            |
| Objetivo do Teste   | Garantir que menores de 18 anos não sejam expostos a conteúdo sensível                                                                    |
| Prerequisitos       | 1. O usuário com menos de 18 anos está logado;                                                                                            |
| Passos              | 1. No campo de pesquisa, digitar o nome de um jogo proibido para menores de 18 anos (ex.: Cyberpunk 2077);<br>2. Selecionar a tecla Enter |
| Critério de Êxito   | Nenhum resultado com classificação indicativa 18+ é exibido                                                                               |

| Caso de Teste       | CT-10 – Portal de promoções                                                 |
| ------------------- | --------------------------------------------------------------------------- |
| Requisito Associado | RF-24 - Exibir jogos que atualmente estão em promoção (Portal de promoções) |
| Objetivo do Teste   | Verificar que é possível visualizar jogos que estão atualmente em promoção  |
| Prerequisitos       | 1. O usuário está logado;                                                   |
| Passos              | 1. Selecionar 'Promoções' no menu superior                                  |
| Critério de Êxito   | Jogos que estão atualmente em promoção são listados no portal de promoções  |
