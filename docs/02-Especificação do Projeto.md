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
| RF-01 | Permitir que o usuário crie e gerencie seu perfil na plataforma.                                                             | ALTA       |
| RF-02 | Proibir interação de usuários menores de 13 anos com demais usuários                                                         | ALTA       |
| RF-03 | Permitir que o usuário sincronize seu perfil da plataforma com o seu perfil da Steam® - Via única Steam® -> InfoGames        | BAIXA      |
| RF-04 | Permitir que o usuário faça cadastro e login usando SSO Steam®                                                               | MÉDIA      |
| RF-05 | Exibir notícias atualizadas sobre jogos que o usuário possui e/ou segue (Portal de notícias)                                 | BAIXA      |
| RF-06 | Permitir o usuário personalizar seu portal de notícias.                                                                      | ALTA       |
| RF-07 | Permitir o usuário curtir e comentar nas notícias.                                                                           | MÉDIA      |
| RF-08 | Permitir que outros usuários interajam (curtir e responder) com comentários                                                  | MÉDIA      |
| RF-09 | Proibir que usuários criem comentários ofensivos (xingamentos, ofensas à raça, religião, gênero, etc)                        | ALTA       |
| RF-10 | Ordenar comentários por engajamento (curtidas+comentários)                                                                   | BAIXA      |
| RF-11 | Permitir a pesquisa de jogos disponíveis na loja por nome e gênero                                                           | ALTA       |
| RF-12 | Permitir a filtrar e/ou ordenar a lista de resultados de pesquisa por classificação, preço, desconto e/ou data de lançamento | ALTA       |
| RF-13 | Definir todos jogos classificados como "Mature" ou "Proibido para menores" como "restritos"                                  | ALTA       |
| RF-14 | Criar verificação de idade para acessar conteúdo de jogos restritos                                                          | ALTA       |
| RF-15 | Proibir que usuários menores de 18 acessem conteúdo de jogos restritos                                                       | ALTA       |
| RF-16 | Permitir que usuários de 18 anos ou mais habilitem o acesso a conteúdo de jogos restritos                                    | MÉDIA      |
| RF-17 | Exibir informações de preço atual e histórico de jogos na Steam®                                                             | ALTA       |
| RF-18 | Exibir estatísticas de jogos, incluindo número de jogadores online.                                                          | ALTA       |
| RF-19 | Permitir que o usuário compartilhe a página do jogo                                                                          | MÉDIA      |
| RF-20 | Permitir que o usuários pesquise por outros usuários                                                                         | MÉDIA      |
| RF-21 | Permitir que usuários gerenciem seus amigos (convidar, adicionar, remover)                                                   | BAIXA      |
| RF-22 | Criar uma lista de resultados de pesquisa dinâmica                                                                           | MÉDIA      |
| RF-23 | Usar pesquisa contextual para jogos e usuários                                                                               | BAIXA      |
| RF-24 | Exibir jogos que atualmente estão em promoção (Portal de promoções)                                                          | MÉDIA      |

### Requisitos Não Funcionais

| ID      | Descrição do Requisito                                                                                                                           | Prioridade |
| ------- | ------------------------------------------------------------------------------------------------------------------------------------------------ | ---------- |
| RNF-001 | Implementar autenticação robusta para proteger contas.                                                                                           | ALTA       |
| RNF-002 | Garantir que o aplicativo seja responsivo para diferentes dispositivos, como desktops, tablets e smartphones.                                    | ALTA       |
| RNF-003 | Garantir a privacidade dos dados dos usuários em relação à Lei Geral de Proteção de Dados Pessoais - LGPD.                                       | ALTA       |
| RNF-004 | Adesão a direitos autorais e licenças de uso de dados provenientes das APIs.                                                                     | ALTA       |
| RNF-005 | O site deve permitir que os usuários compreendam as funções do sistema e manipulem de maneira adequada as funcionalidades que estão disponíveis. | MÉDIA      |
| RNF-006 | Tempo de resposta para informações aparecerem na tela deve ser menor que 03 segundos em 90% dos casos.                                           | BAIXA      |
| RNF-007 | Tempos de respostas rápidos para garantir uma experiência de usuário fluida.                                                                     | BAIXA      |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

| ID  | Restrição                                                                                                                                                                                |
| --- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 01  | A plataforma deve ser compatível com os principais navegadores web (Google Chrome, Mozilla Firefox, Safari e Microsoft Edge) para garantir uma experiência consistente para os usuários. |
| 02  | O design da interface do usuário deve ser responsivo, adaptando-se a diferentes tamanhos de tela, desde dispositivos móveis até monitores de desktop.                                    |

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos.

![Diagrama-Casos de Uso-InfoGames-OK](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t6-infogames/assets/145228139/fac4d7c5-ae61-4dd7-9dff-f4cabcc059af)
