# Especificações do Projeto



## Personas

Rodolfo Nunes tem 23 anos, é programador recém-formado e trabalha para uma empresa desenvolvedora de jogos digitais. Encarregado de programar as mecânicas de jogos, ele pesquisa regularmente as mecânicas de jogabilidade mais presentes e utilizadas pela concorrência de mercado para, além de compreendê-las e reproduzi-las, possuir capacidade de inová-las. Ele busca por meios de informação acessíveis e confiáveis para utilizar em sua pesquisa.

Laura Fagundes possui 18 anos, é estudante universitária e joga online com pessoas ao redor do globo, todas as noites ao retornar de suas aulas. Apesar de jogar frequentemente alguns jogos de ação competitivos nos últimos anos, ela é interessada nas próximas sensações do ano, em matéria de jogos multijogador. Dessa forma, ela acompanha diariamente as notícias de novos jogos que adquirem sucesso.

Ana Silva tem 28 anos, trabalha como desenvolvedora de software em uma empresa de tecnologia. Entusiasta de jogos eletrônicos, adora se manter atualizada sobre as últimas novidades, lançamentos e tendências da indústria. Ela costuma navegar por vários sites e fóruns para obter informações, mas sente falta de uma fonte centralizada para encontrar notícias confiáveis, análises detalhadas, estatísticas de jogos e preços atualizados em um único lugar.


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Programador  | Informações acessíveis e confiáveis.     | Ter fontes confiáveis para embasar suas pesquisas e aprimorar o trabalho.  |
|     | Notificações de lançamentos relevantes.  | Ficar atualizado sobre novas mecânicas e tendências no mercado de jogos. |
|Estudante    | Notícias diárias de novos jogos          | Descobrir as últimas sensações do mundo dos jogos online.    |
|       |Acompanhamento de jogos de sucesso        |Manter-se atualizado(a) com informações e estatísticas de novos jogos. |
|Entusiasta Gamer    | Receber notícias atualizadas       | Estar sempre informada sobre as últimas novidades.    |
|       | Acessar análises detalhadas        | Tomar decisões informadas sobre novos lançamentos. |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Cadastro de Usuário: | ALTA | 
|      | •	Permitir que os usuários criem e gerenciem contas individuais. |  | 
|      | •	Coletar dados de usuário, como nome, senha, endereço de e-mail, jogos de sua preferência etc. |     | 
|RF-002| Portal de Notícias:| ALTA | 
|      | •	Exibir notícias atualizadas sobre a indústria de jogos.|    | 
|      | •	Gerenciar o conteúdo de publicação ou edição de notícias.|    | 
|      | •	Possibilitar que os usuários comentem ou contribuam com notícias.|    | 
|      | •	Possibilitar o usuário personalizar seu portal de notícias. |    | 
|RF-003| Estatística de Jogos: | ALTA | 
|      | •	Integrar informações de preços com APIs de diferentes lojas online. |    | 
|      | •	Apresentar estatísticas de jogos, incluindo número de jogadores online. |    | 
|RF-004| Interface Atrativa: | MÉDIA |
|      | • Construir um design de fácil manipulação e responsivo para diferentes dispositivos. |     |
|      | • Prover uma interface com Facilidade de navegação e busca eficiente de informações. |     |

**Prioridade: Alta / Média / Baixa.


### Requisitos Não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| Segurança: | ALTA | 
|       | • Implementar medidas de segurança, garantindo a segurança dos dados os quais o usuário não quer compartilhar. |      | 
|       | • Implementar autenticação robusta para proteger contas. |      | 
|RNF-002| Aplicação Responsiva: | ALTA | 
|       | • Garantir que o aplicativo seja responsivo para diferentes dispositivos, como desktops, tablets e smartphones. |       | 
|RNF-003| Legal: | ALTA | 
|       | •	Garantir a privacidade dos dados dos usuários em relação à Lei Geral de Proteção de Dados Pessoais - LGPD. |    | 
|       | •	Adesão a direitos autorais e licenças de uso de dados provenientes das APIs. |    | 
|RNF-004| Usabilidade: | MÉDIA | 
|       | •	O site deve permitir que os usuários compreendam as funções do sistema e manipulem de maneira adequada as funcionalidades que estão disponíveis. |    | 
|RNF-005| Desempenho: | BAIXA | 
|       | •	Tempo de resposta para informações aparecerem na tela deve ser menor que 03 segundos em 90% dos casos. |    | 
|       | •	Tempos de respostas rápidos para garantir uma experiência de usuário fluida. |    | 

**Prioridade: Alta / Média / Baixa.



## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre letivo da PUC Minas. |
|02| O desenvolvimento do projeto deve incluir a implementação de um módulo de backend para suportar as funcionalidades da plataforma.        |
|03| A plataforma deve ser compatível com os principais navegadores web (Google Chrome, Mozilla Firefox, Safari e Microsoft Edge) para garantir uma experiência consistente para os usuários.  |
|04| O design da interface do usuário deve ser responsivo, adaptando-se a diferentes tamanhos de tela, desde dispositivos móveis até monitores de desktop.    |


## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

![Diagrama-Casos de Uso-InfoGames-OK](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t6-infogames/assets/145228139/fac4d7c5-ae61-4dd7-9dff-f4cabcc059af)

