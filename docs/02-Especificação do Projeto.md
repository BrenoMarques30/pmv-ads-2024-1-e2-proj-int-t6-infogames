# Especificações do Projeto

## Personas

Rodolfo Nunes tem 23 anos, é programador recém-formado e trabalha para uma empresa desenvolvedora de jogos digitais. Encarregado de programar as mecânicas de jogos, ele pesquisa regularmente as mecânicas de jogabilidade mais presentes e utilizadas pela concorrência de mercado para, além de compreendê-las e reproduzi-las, possuir capacidade de inová-las. Ele busca por meios de informação acessíveis e confiáveis para utilizar em sua pesquisa.

Laura Fagundes possui 18 anos, é estudante universitária e joga online com pessoas ao redor do globo, todas as noites ao retornar de suas aulas. Apesar de jogar frequentemente alguns jogos de ação competitivos nos últimos anos, ela é interessada nas próximas sensações do ano, em matéria de jogos multijogador. Dessa forma, ela acompanha diariamente as notícias de novos jogos que adquirem sucesso.

Ana Silva tem 28 anos, trabalha como desenvolvedora de software em uma empresa de tecnologia. Entusiasta de jogos eletrônicos, adora se manter atualizada sobre as últimas novidades, lançamentos e tendências da indústria. Ela costuma navegar por vários sites e fóruns para obter informações, mas sente falta de uma fonte centralizada para encontrar notícias confiáveis, análises detalhadas, estatísticas de jogos e preços atualizados em um único lugar.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

| EU COMO... `PERSONA` | QUERO/PRECISO ... `FUNCIONALIDADE`      | PARA ... `MOTIVO/VALOR`                                                   |
| -------------------- | --------------------------------------- | ------------------------------------------------------------------------- |
| Programador          | Informações acessíveis e confiáveis.    | Ter fontes confiáveis para embasar suas pesquisas e aprimorar o trabalho. |
|                      | Notificações de lançamentos relevantes. | Ficar atualizado sobre novas mecânicas e tendências no mercado de jogos.  |
| Estudante            | Notícias diárias de novos jogos         | Descobrir as últimas sensações do mundo dos jogos online.                 |
|                      | Acompanhamento de jogos de sucesso      | Manter-se atualizado(a) com informações e estatísticas de novos jogos.    |
| Entusiasta Gamer     | Receber notícias atualizadas            | Estar sempre informada sobre as últimas novidades.                        |
|                      | Acessar análises detalhadas             | Tomar decisões informadas sobre novos lançamentos.                        |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

| ID    | Descrição do Requisito                                                                                                       | Prioridade |
| ----- | ---------------------------------------------------------------------------------------------------------------------------- | ---------- |
| RF-001 | Permitir que o usuário crie e gerencie seu perfil na plataforma.                                                             | ALTA       |
| RF-002 | Proibir criação de perfil e interação de usuários menores de 13 anos com demais usuários                                     | ALTA       |
| RF-003 | Permitir que o usuário sincronize seu perfil da plataforma com o seu perfil da Steam® - Via única Steam® -> InfoGames        | BAIXA      |
| RF-004 | Permitir que o usuário faça cadastro e login usando SSO Steam®                                                               | MÉDIA      |
| RF-005 | Exibir notícias atualizadas sobre jogos que o usuário possui e/ou segue (Portal de notícias)                                 | BAIXA      |
| RF-006 | Permitir o usuário personalizar seu portal de notícias.                                                                      | ALTA       |
| RF-007 | Permitir o usuário curtir e comentar nas notícias.                                                                           | MÉDIA      |
| RF-008 | Permitir que outros usuários interajam (curtir e responder) com comentários                                                  | MÉDIA      |
| RF-009 | Proibir que usuários criem comentários ofensivos (xingamentos, ofensas à raça, religião, gênero, etc)                        | ALTA       |
| RF-010 | Ordenar comentários por engajamento (curtidas+comentários)                                                                   | BAIXA      |
| RF-011 | Permitir a pesquisa de jogos disponíveis na loja por nome e gênero                                                           | ALTA       |
| RF-012 | Permitir a filtrar e/ou ordenar a lista de resultados de pesquisa por classificação, preço, desconto e/ou data de lançamento | ALTA       |
| RF-013 | Definir todos jogos classificados como "Mature" ou "Proibido para menores" como "restritos"                                  | ALTA       |
| RF-014 | Criar verificação de idade para acessar conteúdo de jogos restritos                                                          | ALTA       |
| RF-015 | Proibir que usuários menores de 18 acessem conteúdo de jogos restritos                                                       | ALTA       |
| RF-016 | Permitir que usuários de 18 anos ou mais habilitem o acesso a conteúdo de jogos restritos                                    | MÉDIA      |
| RF-017 | Exibir informações de preço atual e histórico de jogos na Steam®                                                             | ALTA       |
| RF-018 | Exibir estatísticas de jogos, incluindo número de jogadores online.                                                          | ALTA       |
| RF-019 | Criar um backup dioturno com informações dos usuários e jogos                                                                | MÉDIA      |
| RF-020 | Permitir que o usuário compartilhe a página do jogo                                                                          | MÉDIA      |
| RF-021 | Permitir que o usuários pesquise por outros usuários                                                                         | MÉDIA      |
| RF-022 | Permitir que usuários gerenciem seus amigos (convidar, adicionar, remover)                                                   | BAIXA      |
| RF-023 | Criar uma lista de resultados de pesquisa dinâmica                                                                           | MÉDIA      |
| RF-24 | Usar pesquisa contextual para jogos e usuários                                                                               | BAIXA      |
| RF-025 | Exibir jogos que atualmente estão em promoção (Portal de promoções)                                                          | MÉDIA      |

### Requisitos Não Funcionais

| ID      | Descrição do Requisito                                                                                                                           | Prioridade |
| ------- | ------------------------------------------------------------------------------------------------------------------------------------------------ | ---------- |
| RNF-001 |                                                                                                                                                  | ALTA       |
| RNF-002 | Implementar autenticação robusta para proteger contas.                                                                                           | ALTA       |
| RNF-003 | Garantir que o aplicativo seja responsivo para diferentes dispositivos, como desktops, tablets e smartphones.                                    | ALTA       |
| RNF-004 | Garantir a privacidade dos dados dos usuários em relação à Lei Geral de Proteção de Dados Pessoais - LGPD.                                       | ALTA       |
| RNF-005 | Adesão a direitos autorais e licenças de uso de dados provenientes das APIs.                                                                     | ALTA       |
| RNF-006 | O site deve permitir que os usuários compreendam as funções do sistema e manipulem de maneira adequada as funcionalidades que estão disponíveis. | MÉDIA      |
| RNF-007 | Tempo de resposta para informações aparecerem na tela deve ser menor que 03 segundos em 90% dos casos.                                           | BAIXA      |
| RNF-008 | Tempos de respostas rápidos para garantir uma experiência de usuário fluida.                                                                     | BAIXA      |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

| ID  | Restrição                                                                                                                                                                                |
| --- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 01  | A plataforma deve ser compatível com os principais navegadores web (Google Chrome, Mozilla Firefox, Safari e Microsoft Edge), garantindo uma experiência consistente para os usuários, independentemente do navegador utilizado. |
| 02  | O design da interface do usuário deve ser responsivo, adaptando-se de forma eficaz e esteticamente atraente a uma variedade de dispositivos, desde smartphones e tablets até monitores de desktop, proporcionando uma experiência de usuário otimizada em qualquer dispositivo e tamanho de tela.                                    |
| 03  | O projeto será sem fins lucrativos.                                    |
| 04  | O repositório das entregas deverá ser feito no GitHub.                                    |


## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos.

![Diagrama-Casos de Uso-InfoGames-v3](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t6-infogames/assets/145228139/e41278d2-4d19-41c8-b84c-9b4eb0e5a87a)

