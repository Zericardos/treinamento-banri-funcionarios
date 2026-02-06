# Dicionário Banrisul

## A

### API - Application Programming Interface

É um conjunto de padrões, ferramentas e protocolos que permitem que aplicativos de software se comuniquem entre si para trocar dados, recursos e funcionalidades. Ela permite a criação mais simplificada e segura de plataformas, ao viabilizar a integração e a comunicação entre diferentes sistemas e seus componentes.

### Arquitetura 3 Camadas: DAL, BLL e UI

#### BLL - Business Logic Layer

[Business Logic Layer](https://www.geeksforgeeks.org/dbms/business-logic-layer/), ou Camada de Lógica de Negócios, é o coração de uma aplicação que utiliza a Arquitetura de Três Camadas. Ela é a camada do meio, responsável por implementar e executar as regras e os processos de negócios específicos do domínio da aplicação. A BLL garante que os dados e as operações sigam as regras de negócios, independentemente de como a informação é apresentada ao usuário (Camada de Apresentação) ou de como é armazenada (Camada de Acesso a Dados - DAL).

#### DAL - Data Access Layer

[Data Access Layer](https://www.geeksforgeeks.org/dbms/data-access-layer/), ou Camada de Acesso a Dados, é frequentemente usado em arquiteturas de software, especialmente na Arquitetura de Três Camadas, para descrever a camada que lida exclusivamente com as operações de persistência e recuperação de dados. A DAL é a parte da aplicação responsável por isolar o restante do sistema da forma como os dados são armazenados, acessados e manipulados.

#### UI - User Interface

[User Interface](https://www.geeksforgeeks.org/web-templates/user-interface-ui/), ou Camada de Apresentação, é a camada superior da Arquitetura de Três Camadas. Ela é a parte do sistema que o usuário final vê e com a qual interage diretamente. A principal função da Camada de Apresentação é exibir informações ao usuário e capturar sua entrada (comandos, dados, cliques), servindo como o ponto de contato entre o ser humano e o software.

## B

### Bergs

Bergs é literalmente apenas um acrônimo para **Banco do estado do Rio Grande do Sul**.

### BFF - Backend for Frontend

O [BFF](https://medium.com/jeitosanar/backend-for-frontend-uma-estrat%C3%A9gia-sob-demanda-para-a-entrega-de-microsservi%C3%A7os-2f12d4cb9e3f) é um padrão de arquitetura em que se cria um backend específico para cada tipo de frontend. Ele funciona como uma camada intermediária que adapta e organiza dados vindos de vários serviços, entregando ao frontend exatamente o que ele precisa — seja um app web, mobile ou até uma Smart TV.

## C

### Camada Q - Camada "Query"

Camada de acesso a dados de aplicações MM4 e MMD, responsável por todas as operações de acesso a dados via SQL explícito. Ela fornece utilitários e infraestrutura para montar comandos como `SELECT`, `INSERT`, `UPDATE` e `DELETE` com cláusulas como `WHERE`, `JOIN`, `IN`, `BETWEEN`, etc., gerenciar parâmetros, conexões, transações e exceções, sem depender de fato de um [ORM](#orm---object-relational-mapping). Opera geralmente em cima de classes já baseadas em [TO](#to---transfer-object)s, permitindo criar rotinas de consulta e persistência de forma padronizada e fortemente tipada, porém com liberdade total para personalização de comandos SQL que forem necessários. O resultado é uma interação com a base de dados mais previsível, performática e consistente entre projetos.

> Nota: O termo "Query" é um apelido adotado informalmente para representar a natureza da camada dentro de uma heurística possível, mas não constitui parte da nomenclatura oficial. Não se sabe originalmente qual foi a origem da letra "Q".

### Camada S - Camada "Service"

Camada de regras de negócio das aplicações MM4 e MMD, responsável por validar [TO](#to---transfer-object)s, aplicar cálculos, definir fluxos e coordenar operações de negócio. Atua acima da [Camada Q](#camada-q---camada-query), chamando seus métodos de persistência e controlando transações atômicas. Executa lógicas específicas do domínio de negócio e centraliza integrações com aplicações externas (MM4 ou MMD).

> Nota: O termo "Service" é um apelido adotado informalmente para representar a natureza da camada dentro de uma heurística possível, mas não constitui parte da nomenclatura oficial. Não se sabe originalmente qual foi a origem da letra "S".

### Camada U - Camada "Unit Test"

Camada de testes automatizados das aplicações MM4 e MMD, responsável por validar principalmente comportamentos das [Camadas S](#camada-s---camada-service), garantindo que as respectivas regras de negócio funcionem corretamente, tanto em cenários de testes unitários quanto de testes de integração.

Utiliza o framework base **NUnit** e outros recursos personalizados de framework para proporcionar funcionalidades de construção de testes como:

- Testagem unitária com isolamento de dependências por meio de [mocks](#mock), garantindo que funcionalidades críticas sejam verificadas de forma repetível, controlada e independente;
- Testagem integrada com interação real na base de dados, porém com consistência e segurança garantidas pelo controle de escopo transacional com _rollback_ automático;
- Inspeção de resultados e validação de mensagens de retorno através de uma vasta gama de possibilidades de asserções.

Ferramentas do [PZP](#pzp---ferramenta-de-apoio-ao-desenvolvimento) como o **Gerador de testes MM C#** e o **Testador MM C#** proporcionam utilidades de criação automática do projeto de testes e execução para validação dos testes respectivamente.

> Nota: O termo "Unit Test" é um apelido adotado informalmente para representar a natureza da camada dentro de uma heurística possível, mas não constitui parte da nomenclatura oficial. Não se sabe originalmente qual foi a origem da letra "U".

### Camada W - Camada "Web"

<!-- TODO Renato -->

> Nota: O termo "Web" é um apelido adotado informalmente para representar a natureza da camada dentro de uma heurística possível, mas não constitui parte da nomenclatura oficial. Não se sabe originalmente qual foi a origem da letra "W".

## CD - Continuous Delivery/Deployment

A [entrega contínua (CD)](https://circleci.com/continuous-delivery/) é uma metodologia de desenvolvimento de software que enfatiza testes automatizados, integração frequente de código e implantação rápida para reduzir o tempo do ciclo de desenvolvimento. Ela permite que as equipes de desenvolvimento de software entreguem alterações de código em produção de forma consistente, com intervenção manual mínima, e promove agilidade, colaboração e lançamentos de software confiáveis.

## CI - Continuous Integration

A [Integração Contínua (CI)](https://www.atlassian.com/continuous-delivery/continuous-integration) é uma prática de desenvolvimento de software onde os desenvolvedores integram seu código em um repositório compartilhado várias vezes ao dia. Cada integração é verificada por meio de uma compilação automatizada e testes automáticos para detectar erros o mais rápido possível.

### Circular Dependency

A [Dependência Circular](https://medium.com/@kacar7/the-significance-of-circular-dependency-in-software-development-8995fd06bc34) (ou dependência cíclica) é um conceito importante na engenharia de software que ocorre quando dois ou mais módulos, classes ou componentes de um sistema referenciam ou dependem uns dos outros para funcionar corretamente, formando um ciclo. Por exemplo, se a parte A precisa da parte B para funcionar, mas a parte B também precisa da parte A, ela cria um loop.

### CMD (Command Prompt)

Interpretador de linhas de comando do Windows (`cmd.exe`) que permite interagir com o sistema operacional ou aplicativos por meio de comandos textuais. É uma ferramenta fundamental para automação, configuração e gerenciamento de sistemas.

### Computador Central

Computador Central (Mainframe IBM): Sistema de grande porte da IBM projetado para processar grandes volumes de dados e transações simultâneas com alta confiabilidade, disponibilidade e segurança. É utilizado em ambientes corporativos críticos para gestão de bancos de dados, aplicações financeiras, governamentais e de grande escala.

#### DROSCOE

Aplicação desenvolvida no [Computador Central (Mainframe IBM)](#computador-central) para gerenciamento de credenciais de acesso ao ambiente corporativo. Permite, principalmente, redefinir senhas que são utilizadas em sistemas como o [Consulta Objetos](#consulta-objetos), garantindo que usuários possam manter ou recuperar o acesso autorizado à gestão dos bancos de dados corporativos do Banrisul.

#### RACF - Resource Access Control Facility

Sistema de controle de acesso do mainframe IBM responsável por gerenciar permissões e credenciais de usuários nos ambientes corporativos. No contexto do Banrisul, um código temporário RACF é gerado através de um [workflow](#workflow) específico e utilizado no [DROSCOE](#droscoe) para redefinir senhas de acesso ao [Consulta Objetos](#consulta-objetos), funcionando de forma semelhante a um [OTP](#otp---one-time-password) para garantir segurança no processo de redefinição.

### Consulta Objetos

Aplicação utilizada no ecossistema do Banrisul para acessar bancos de dados corporativos, como IBM DB2 e Oracle, permitindo consultar, criar, atualizar e eliminar informações de acordo com permissões de usuário. Atua como [SGDB](#sgdb) cliente para gestão centralizada de dados dos sistemas.

### CRUD

[CRUD](https://developer.mozilla.org/en-US/docs/Glossary/CRUD) é a sigla para as quatro operações fundamentais em bancos de dados: Create (Criar), Read (Ler), Update (Atualizar) e Delete (Apagar). Essas operações são a base da manipulação de dados na maioria dos softwares, permitindo a criação, visualização, modificação e exclusão de registros.

### CSS - Cascading Style Sheets

O [CSS](https://developer.mozilla.org/en-US/docs/Web/CSS) é uma linguagem de estilo que define a aparência de páginas web, como cores, fontes e layout. Ele separa o conteúdo da estrutura visual, facilitando a criação de sites elegantes e consistentes.

### CSS - Código de Sigla de Sistema

Identificador único de **três letras** atribuído a cada sistema do Banrisul.

Serve como referência técnica oficial em todos os ambientes e ferramentas corporativas — como autenticação, logs, bancos de dados e documentações.

É definido na fase inicial do projeto pelos analistas ou arquitetos, seguindo critérios de clareza, unicidade e coerência, considerando acessibilidade, público-alvo, propósito, segurança e integração com outros sistemas.

> Nota: Não confunda este com [CSS - Cascading Style Sheets](#css---cascading-style-sheets).

#### CSSs Mais Comuns

##### BEI

CSS classificador do sistema [Workflow](#workflow) do Banrisul.

##### BOP

<!-- TODO Renato -->

##### BTR

<!-- TODO Renato -->

##### BWS

<!-- TODO Renato -->

##### PDE

CSS classificador do sistema utilizado pela equipe [Bancos de Dados](#equipe-bancos-de-dados) do Banrisul.

##### PHA

CSS classificador do sistema projetado para gerenciar e controlar o acesso a produtos e serviços com base em perfis de usuários. Sua principal função é garantir que cada colaborador tenha acesso apenas às funcionalidades, informações e recursos que correspondem ao seu perfil ou função dentro do Banrisul.

##### PWX

<!-- TODO Renato -->

##### PXC

CSS classificador do sistema _guarda-chuva_ das iniciativas de desenvolvimento de pessoas e educação corporativa do Banrisul.

Abrange ações voltadas à capacitação técnica e institucional, como produção de conteúdos educacionais, onboarding de novos colaboradores, cursos e treinamentos, além de palestras e eventos internos ou externos voltados à disseminação de conhecimento.

##### PXU

CSS classificador do sistema projetado para prover suporte de comunicação síncrona e assíncrona entre sistemas construídos sobre diferentes plataformas (ex.: IBM mainframe, Windows, Linux) com diferentes linguagens de programação (ex.: COBOL, C#, Java).

## D

### DAO - Data Access Object

[Data Access Object](https://www.geeksforgeeks.org/system-design/data-access-object-pattern/), ou Objeto de Acesso a Dados, é um padrão de design na programação orientada a objetos. Ele tem como objetivo principal separar a lógica de negócios de uma aplicação da lógica de persistência de dados (como acesso a um banco de dados, arquivos ou outros serviços de armazenamento).

### Dependency Hell

[Dependency Hell](https://mandhan.medium.com/dependency-hell-79097a5d312f) é um termo que descreve a dificuldade de gerenciar um projeto de software devido ao excesso de dependências – ou seja, bibliotecas e frameworks dos quais o projeto depende para funcionar. À medida que um projeto cresce, a gestão dessas dependências pode se tornar um pesadelo, especialmente quando diferentes pacotes requerem versões distintas das mesmas bibliotecas.

### DG - Direção Geral

Órgão responsável pela administração e gestão estratégica do Banrisul.

A referência DG também é comumente utilizada para o próprio prédio onde este orgão (e as unidades de trabalho) se localizam, no endereço Rua Caldas Júnior, bairro Centro Histórico, cidade de Porto Alegre/RS.

> Nota: Durante contatos com o [HelpDesk](#equipe-helpdesk) do Banrisul, é comum o atendente questionar a sede do colaborador — nesses casos a resposta **DG** é recomendada.

### DTO - Data Transfer Object

O [Data Transfer Object (DTO)](https://devnit.medium.com/a-m%C3%A1gica-por-tr%C3%A1s-da-convers%C3%A3o-de-dados-o-padr%C3%A3o-dto-explicado-25f68a718b5a) é um padrão de design de software cujo principal propósito é transportar dados de forma eficiente e segura entre diferentes camadas, módulos ou sistemas de uma aplicação.
É como se fosse um "envelope de dados" que define o contrato de entrada e saída de informação em um ponto de contato do sistema.

## E

### Equipe Bancos de Dados

A equipe **Bancos de Dados** é responsável pelo planejamento, administração e evolução das bases de dados da organização. Atua na modelagem, implementação, monitoramento, permissionamento e otimização de desempenho, assegurando disponibilidade, integridade, segurança e continuidade das informações. Também presta suporte técnico a projetos e sistemas que dependem de dados, colaborando para que aplicações utilizem as estruturas de maneira eficiente e confiável.

### Equipe Fábrica

A equipe **Fábrica** é responsável por conectar pessoas aos projetos, garantindo que cada time receba o apoio necessário para iniciar e conduzir suas atividades. Atua em parceria com empresas terceiras e com os grupos de estagiários para organizar alocações, acompanhar movimentações e apoiar a integração de novos colaboradores. Fornece o suporte inicial de setup e organização das ferramentas de trabalho, assegurando que cada pessoa tenha condições adequadas para desempenhar suas funções desde o primeiro dia.

### Equipe HelpDesk

A equipe denominada **HelpDesk** é o ponto de contato inicial para suporte técnico no ecossistema do Banrisul. É responsável por atender e resolver incidentes relacionados a estações de trabalho, rede, acessos, periféricos e softwares corporativos.

Atua garantindo o funcionamento contínuo do ambiente de trabalho dos colaboradores e, quando necessário, encaminha demandas às equipes subjacentes ([Fábrica](#equipe-fábrica), [Bancos de Dados](#equipe-bancos-de-dados), [Infraestrutura](#equipe-infraestrutura), etc) para tratamento especializado.

Normalmente pode ser contatada via telefone pelo número `(51) 3215-2000` — menus 2 (atendimento para Direção Geral) e depois 3 (HelpDesk).

> Nota: Durante o contato é comum o atendente questionar a sede do colaborador — nesses casos a resposta [**DG**](#dg---direção-geral) é recomendada.

### Equipe Infraestrutura

A equipe denominada **Infraestrutura** (ou simplesmente **Infra**) é a responsável por prover o conjunto de serviços de desenvolvimento, sustentação e suporte à família de frameworks MM. São responsáveis por evoluir as funcionalidades dos principais ambientes de desenvolvimento e seus respectivos ferramentais.

## F

### Fallback

[Fallback](https://artigos.valuehost.com.br/glossario/o-que-e-fallback/) é uma estratégia de tecnologia usada quando um recurso principal falha. Ele funciona como um plano de contingência: se algo não estiver disponível, o sistema ativa automaticamente uma alternativa para continuar funcionando. Por exemplo, se um servidor de imagens cair, o fallback mostra um ícone ou texto substituto. Isso mantém a experiência do usuário mesmo diante de problemas.

## G

## H

### Hook

[Hooks](https://programarsemcodigo.com.br/glossario/o-que-e-hooks-de-programacao/) de programação são ferramentas que permitem aos desenvolvedores personalizar e estender as funcionalidades de aplicações sem a necessidade de modificar diretamente o código-fonte. Eles permitem conectar lógicas personalizadas a diferentes partes do ciclo de vida de um componente, proporcionando maior flexibilidade e reutilização de código.

### HSTS - HTTP Strict Transport Security

[HSTS](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Headers/Strict-Transport-Security) é um mecanismo de segurança web que protege os sites contra alguns tipos de ataques cibernéticos. Ele instrui os navegadores a se conectarem apenas via [HTTPS](#https---hypertext-transfer-protocol-secure), garantindo que todas as comunicações sejam criptografadas e seguras.

### HTML - HyperText Markup Language

O [HTML](https://www.alura.com.br/artigos/html?utm_term=&utm_campaign=topo-aon-search-gg-dsa-artigos_conteudos&utm_source=google&utm_medium=cpc&campaign_id=11384329873_164068847699_703853156311&utm_id=11384329873_164068847699_703853156311&hsa_acc=7964138385&hsa_cam=topo-aon-search-gg-dsa-artigos_conteudos&hsa_grp=164068847699&hsa_ad=703853156311&hsa_src=g&hsa_tgt=aud-409949667484:dsa-2273097816642&hsa_kw=&hsa_mt=&hsa_net=google&hsa_ver=3&gad_source=1&gad_campaignid=11384329873&gbraid=0AAAAADpqZIAbFMlnoSjEWDGAKKB0kMd11&gclid=EAIaIQobChMI6pKqoof6kAMVkTRECB35dgZvEAAYASAAEgJfjPD_BwE#o-que-e-html) é utilizado para estruturar e formatar o conteúdo de páginas web, ele define o significado e a estrutura do conteúdo, não sendo uma linguagem de programação. "Hipertexto" refere-se aos links que conectam páginas da Web entre si, seja dentro de um único site ou entre sites. O HTML usa "Marcação" para anotar texto, imagem e outros conteúdos para exibição em um navegador da Web.

### HTTP - Hypertext Transfer Protocol

[HTTP](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Guides/Overview) é o protocolo fundamental de comunicação para a web. Ele é um conjunto de regras que define como as informações de hipermídia (como páginas web, imagens, vídeos) são solicitadas, transmitidas e apresentadas entre um cliente (geralmente seu navegador) e um servidor (onde uma aplicação está hospedada).

### HTTPS - Hypertext Transfer Protocol Secure

[HTTPS](https://developer.mozilla.org/pt-BR/docs/Glossary/HTTPS) é a versão segura do [HTTP](#http---hypertext-transfer-protocol), o protocolo fundamental para a transferência de dados na web. Sua principal função é garantir que a comunicação entre o seu navegador e a aplicação que você está acessando seja criptografada e autenticada, protegendo seus dados contra interceptação e adulteração.

## I

### ID - Identidade Digital

Cartão com chip que contém um certificado digital A3 pessoal representando a [Matrícula](#matrícula), que credencia o profissional a atuar dentro do ecossistema do Banrisul.

### IDE - Integrated Development Environment

Ambiente de Desenvolvimento Integrado que reúne, em uma única aplicação, as principais ferramentas necessárias para criar, editar, compilar, debugar e testar softwares. No MM4, o Microsoft Visual Studio é a IDE padrão, oferecendo suporte nativo ao .NET Framework, integração com o [IIS](#iis---internet-information-services) Express e recursos avançados de build e debug.

### Idempotência

[Idempotência](https://dev.to/ikauedev/idempotencia-o-segredo-para-sistemas-confiaveis-3561) é um conceito fundamental em engenharia de software que se refere à propriedade de uma operação produzir o mesmo resultado independentemente de quantas vezes for executada. Isso significa que, se uma operação idempotente for aplicada repetidamente com os mesmos argumentos, seu efeito será sempre o mesmo.

### IIFE - Immediately Invoked Function Expression

[IIFE](https://developer.mozilla.org/pt-BR/docs/Glossary/IIFE) é uma função em JavaScript que é definida e executada imediatamente após sua criação. Ela é usada para criar um **escopo isolado**, evitando a poluição do escopo global e protegendo variáveis e funções de interferências externas.

### IIS - Internet Information Services

Servidor web da Microsoft responsável por hospedar e executar aplicações web em ambientes Windows. No contexto do MM4, é utilizado principalmente em sua versão _Express_, que permite rodar aplicações .NET ainda durante a fase de desenvolvimento, integrando com o sistema operacional local e com o Visual Studio, simulando o comportamento de um servidor real. O IIS trabalha em conjunto com o ANCM (ASP.NET Core Module) para integrar aplicações baseadas em .NET Framework ou .NET Core.

## J

### JSON - JavaScript Object Notation

[JSON](https://www.json.org/json-en.html) Formato de texto leve e independente de linguagem, usado principalmente para troca de dados na web.
Ele é fácil de ler e escrever por humanos e fácil para máquinas analisarem e gerarem. Apesar do nome, que inclui _JavaScript_, o JSON é um formato universalmente usado por praticamente todas as linguagens de programação.

## K

## L

### Live Reloading

É uma técnica que habilita alterações feitas no código-fonte de uma aplicação a serem refletidas imediatamente na interface do usuário, sem a necessidade de recarregar manualmente a página ou reiniciar o aplicativo. Isso acelera o processo de desenvolvimento, permitindo que os desenvolvedores vejam instantaneamente o impacto de suas mudanças.

## M

### Matrícula

Identificador único que credencia e classifica o profissional como um colaborador válido dentro do ecossitema do Banrisul.
O número de matrícula é embutido dentro do [ID](#id---identidade-digital), e utilizado como autenticador e autorizador em diversos sistemas. Também consta nos crachás permanentes dos colaboradores.

Possui alguns padrões para diferenciar as categorias de colaborador, por exemplo **B**99999 para colaboradores internos, **T**99999 para terceiros e **E**99999 para estagiários.

### Message Broker

Componente de software responsável por gerenciar mensagens entre sistemas (receber, enviar, armazenar, gerenciar acessos), garantindo comunicação assíncrona, desacoplamento entre serviços e entrega confiável. Exemplos comuns incluem RabbitMQ, Kafka e ActiveMQ.

### Metadado

[Metadados](https://www.w3.org/Metadata/) são informações estruturadas que descrevem outros dados, são literalmente “dados sobre dados”.
Eles indicam origem, formato, autor, data de criação, tamanho, localização e outras características que ajudam a organizar, localizar, entender e usar esses dados com mais eficiência.
Eles aparecem em praticamente tudo no ambiente digital: arquivos do computador (como fotos, PDFs e vídeos), bancos de dados, páginas HTML (tags <meta>), cabeçalhos HTTP em APIs, commits do Git, sistemas operacionais, músicas e vídeos (como tags ID3 ou EXIF), além de serviços em nuvem e contêineres.

### MM - Meta Modelo

É uma terminologia criada pelo Banrisul para designar uma família de frameworks implementados com base em práticas e ferramentas de mercado, com objetivos de simplificação, padronização e otimização do desenvolvimento dos sistemas que atendem as necessidades das devidas plataformas utilizadas no ecossistema.

### MM3 - Meta Modelo Versão 3

**Framework legado e descontinuado** que utilizava as tecnologias `ASP` e `VB6` para desenvolvimento integrado de backend e frontend para plataforma web.

### MM4 - Meta Modelo Versão 4

Framework que utiliza essencialmente `ASP.NET` e `C#`.

Em sua primeira fase, suportava desenvolvimento integrado de backend e frontend para plataforma web, sendo o substituto natural do MM3.

Em sua segunda fase, foi desacoplado para atuar exclusivamente como backend, deixando a responsabilidade de atuação de frontend para o MM5.

### MM5 - Meta Modelo Versão 5

Framework que utiliza [HTML](#html---hypertext-markup-language), [CSS](#css---cascading-style-sheets) e `JavaScript` para suportar o desenvolvimento de frontends para plataforma web.

### MMD - Meta Modelo "Daemon"

Framework que utiliza Java para suportar o desenvolvimento de serviços em uma camada interna do Banrisul, abrangendo operações de integração com aplicações legadas, operações recorrentes e transações em massa.

> Nota: O termo "Daemon" é um apelido adotado informalmente para representar a natureza do framework dentro de uma heurística possível, mas não constitui parte da nomenclatura oficial. Não se sabe originalmente qual foi a origem da letra "D".

### MMDesenv - Ambiente Operacional de Desenvolvimento

Espaço **compartilhado entre equipes**, voltado a testes integrados, validações colaborativas e execução de aplicações internas de menor criticidade.

É o servidor **N712**, que pode ser acessado na web por:

- <https://mmdesenv.corp.banrisul.com.br/pwx/>;
- <https://n712.corp.banrisul.com.br/pwx/>;
- <http://intrawsd/pwx/>.

E na navegação de rede de arquivos por:

- [\\\mmdesenv\\pxh\\](\\\mmdesenv\\pxh\\);
- [\\\n712\\pxh\\](\\\n712\\pxh\\).

> Nota: Priorize o acesso através do alias _mmdesenv_.

### MMM - Meta Modelo Mobile

Framework semelhante ao [MM5](#mm5---meta-modelo-versão-5), que utiliza [HTML](#html---hypertext-markup-language), [CSS](#css---cascading-style-sheets) e `JavaScript` em conjunto com ferramentas que provém [API](#api---application-programming-interface)s mobile para suportar o desenvolvimento de frontends para plataforma mobile.

## N

### Nome de Patrimônio

Identificador único atribuído a cada máquina, utilizado tanto no inventário de patrimônio quanto na rede corporativa. Serve como o "nome oficial" do equipamento, permitindo sua classificação, rastreamento, configuração e comunicação dentro da infraestrutura de TI sem depender de outros endereços. É uma referência padronizada que garante organização, controle, identificação consistente e padronização dos ativos computacionais.

## O

### ORM - Object-Relational Mapping

[Object-Relational Mapping (ORM)](https://www.devmedia.com.br/orm-object-relational-mapper/19056), ou Mapeamento Objeto-relacional, é uma técnica para aproximar o paradigma de desenvolvimento de aplicações orientadas a objetos ao paradigma do banco de dados relacional. O uso da técnica de mapeamento objeto-relacional é realizado através de um mapeador objeto-relacional que geralmente é a biblioteca ou framework que ajuda no mapeamento e uso do banco de dados.

### OTP - One Time Password

A [OTP](https://forense.io/glossario/o-que-e-one-time-password-otp-seguranca-digital/)  é uma senha temporária que é utilizada para autenticação em sistemas digitais. Ao contrário das senhas tradicionais, que podem ser reutilizadas várias vezes, uma OTP é válida apenas para uma única sessão ou transação. Ela é gerada automaticamente por um sistema, enviada ao usuário e, após um tempo ou uma sessão, ela para de funcionar.

## P

### PIN - Personal Identification Number

Senha cadastrada para autenticar o uso do ID.

> Nota: No ecossistema do Banrisul o PIN pode conter letras, números e caracteres especiais.

### PO - Product Owner

O [Product Owner (PO)](https://www.scrum.org/resources/what-product-owner), ou Dono do Produto, é um dos papéis centrais no framework ágil Scrum, responsável por maximizar o valor do produto desenvolvido.
É a única pessoa autorizada a tomar decisões sobre o produto dentro de um time Scrum, garantindo que haja um único foco de decisões e evitando divergências que possam prejudicar o andamento do projeto.
O PO atua como o representante dos interesses dos stakeholders, traduzindo as necessidades dos clientes, usuários e outras partes interessadas em funcionalidades claras e bem definidas para a equipe de desenvolvimento.

### PoC - Proof of Concept

([PoC](https://www.geeksforgeeks.org/software-engineering/what-is-proof-of-concept-poc-in-software-development/))  é uma prova prática que tem como objetivo verificar se uma determinada ideia, tecnologia ou metodologia pode ser realizada ou que um conceito tem viabilidade prática.
É um experimento estruturado, geralmente de curta duração, desenvolvido com o objetivo de comprovar a viabilidade de uma ideia, solução, tecnologia ou metodologia em um contexto específico.
A Prova de Conceito (PoC) valida a viabilidade técnica e funcional de uma ideia antes de seu desenvolvimento completo, servindo como uma etapa preliminar em projetos de inovação, desenvolvimento de produtos ou adoção de novas tecnologias.
Ela permite testar hipóteses críticas, identificar riscos e embasar decisões estratégicas antes de investir tempo e recursos significativos.

### PZP - Ferramenta de Apoio ao Desenvolvimento

É o nome da aplicação que reúne as principais ferramentas de apoio ao desenvolvimento. Funciona como um **hub de produtividade**, que concentra em um único local todos os utilitários que compõem a experiência do desenvolvedor — desde geradores de código, validadores e testadores, até ferramentas de integração com bases de dados, automação e manutenção de sistemas.

## Q

### QA - Quality Assurance

A [Garantia de Qualidade](https://www.alura.com.br/artigos/agile-testing-o-que-e-qual-papel-qa-num-time-agil#o-que-e-qa) é um processo ou conjunto de atividades que visam garantir que um produto ou serviço atenda aos padrões de qualidade estabelecidos. No contexto de desenvolvimento de software, QA refere-se a práticas e técnicas usadas para monitorar e melhorar a qualidade de um software durante seu ciclo de vida, desde o planejamento até o lançamento e manutenção.

## R

### RDS - Remote Desktop Services

[RDS](https://learn.microsoft.com/pt-br/windows-server/remote/remote-desktop-services/overview) é uma plataforma do Microsoft Windows Server que permite aos usuários acessar e usar desktops virtuais e aplicativos instalados em um servidor remoto, como se estivessem executando localmente em seus próprios dispositivos.

Isso é conseguido através do Protocolo de Área de Trabalho Remota (RDP), que transmite a interface gráfica do servidor para o dispositivo do usuário (cliente) e envia as entradas do usuário (teclado, mouse) de volta ao servidor.

## S

### SAC - Sincronização de Acessos Concorrentes

Mecanismo de **lock lógico** aplicado a registros de uma tabela, utilizando um campo do tipo timestamp (ex.: `DataHoraUltimaAtualizacao`) como um _token de atualização_.
A lógica funciona assim: somente o comando `UPDATE` que enviar o **exato mesmo valor desse _token_** presente no registro está autorizado a modificá-lo.
Após uma atualização bem-sucedida, o sistema grava um novo timestamp, renovando o _token_. Isso garante que qualquer tentativa paralela feita com um _token_ antigo seja automaticamente rejeitada, protegendo o registro contra concorrência e sobrescrita de dados.

### SGDB

Aplicação responsável por possibilitar interação com bancos de dados. Ela fornece uma interface padronizada para que usuários possam consultar, inserir, alterar e excluir registros, e também efetuar outros tipos de operações mais avançadas como criar scripts de consulta e operação, tudo de forma segura e consistente.

### SPA - Single Page Application

Uma [SPA](https://developer.mozilla.org/en-US/docs/Glossary/SPA) é uma implementação de aplicação web que carrega apenas um único documento da web e, em seguida, atualiza o conteúdo do corpo desse mesmo documento por meio de APIs JavaScript, como Fetch, quando é necessário exibir conteúdo diferente.

### SSOT - Single Source of Truth

[Single Source of Truth](https://www.getguru.com/pt/reference/single-source-of-truth) ou Fonte Única da Verdade, é um conceito de design de sistemas e gestão de dados que visa garantir que todos os dados de uma organização ou sistema sejam derivados de um único local, consistente e com caráter de autoridade. Tem como objetivo principal eliminar a inconsistência de dados e a confusão gerada pelas distribuição de informações em fontes diferentes, que pode gerar desatualizações ou duplicidades.

## T

### Test Double (Dublê de Teste)

[Test Double](https://labs.bluesoft.com.br/2014/04/14/dubles-de-testes/) é um termo genérico para objetos que simulam ou substituem dependências reais (como bancos de dados, APIs externas) em testes de software, permitindo isolar o código sendo testado, controlar o ambiente e focar apenas na lógica que precisa ser verificada, usando tipos como Fakes, Stubs, Spies e Mocks para diferentes propósitos. 

#### Tipos de Dublês

[Os dublês de teste](https://dev.to/mahata/whats-test-doubles-2c59) são substitutos para objetos reais em testes, principalmente para isolar o código, sendo os principais tipos: Dummies (espaços reservados), Stubs (respostas pré-definidas), Fakes (versões funcionais simplificadas, por exemplo, bancos de dados em memória), Spies (gravam chamadas) e Mocks (verificam comportamentos/expectativas predefinidos).

##### Mock

[Mocks](https://www.geeksforgeeks.org/software-testing/what-is-mocking-an-introduction-to-test-doubles/) são objetos que utilizamos para “simular” interações de saída com dependências externas ao nosso teste. Essas interações de saída são chamadas que o nosso teste realiza para mudar o seu estado.

Com mocks podemos controlar e inspecionar as chamadas para essa falsa dependência. O Mock simula seu comportamento verificando se um ou mais métodos foram ou não chamados, a ordem de chamadas destes métodos, se esses métodos foram chamados com os argumentos certos, e quantas vezes foram chamados.

### TO - Transfer Object

É a principal estrutura de dados dos frameworks [MM](#mm---meta-modelo), que reúne as funções de Model e [DTO](#dto---data-transfer-object) em um único tipo. Representa tanto a estrutura de dados de uma tabela quanto o formato de transporte entre camadas. Também faz uso de wrappers internos para controles de estado.

## U

### UDS - Unidade de Desenvolvimento de Sistemas

Unidade núcleo principal do Banrisul onde acontece o desenvolvimento dos sistemas e serviços. Nesta unidade todo o core bancário é mantido.

### US - User Story

[User Story (ou História de Usuário)](https://agilealliance.org/glossary/user-stories/) é uma técnica utilizada em metodologias ágeis, como o Scrum, para capturar uma necessidade do produto de forma simples e clara, escrita sob a perspectiva do usuário final ou cliente.
Ela representa a menor unidade de trabalho baseada na necessidade do cliente que irá utilizar ou interagir com o produto.

### UTD - Unidade de Transformação Digital

Departamento destacado primeiramente como laboratório de vanguarda — ou seja — novas abordagens, metodologias (ex.: metodologias ágeis) e tecnologias podem primeiramente ser apuradas nesse ambiente controlado antes de serem amplamente adotadas por todo o ecossistema. Também atua como unidade de produtos e serviços, principalmente focando nos de cunho externo (destinados ao público).

## V

### VDI - Virtual Desktop Infrastructure

[VDI - (Infraestrutura de Desktop Virtual)](https://azure.microsoft.com/pt-br/resources/cloud-computing-dictionary/what-is-virtual-desktop-infrastructure-vdi) é uma tecnologia que permite hospedar ambientes de desktop completos (incluindo o sistema operacional, aplicações e configurações) em servidores centralizados (geralmente em um datacenter ou na nuvem), e entregá-los aos usuários finais remotamente.

Em vez de o usuário rodar tudo em sua máquina física, ele basicamente controla um desktop que está sendo executado em um servidor poderoso, acessando-o de qualquer dispositivo (PC antigo, _thin client_, tablet ou até smartphone).

### VPN - Virtual Private Network

Recurso que estabelece uma conexão de rede privada entre dispositivos na Internet, permitindo que os usuários transmitam dados de forma segura e anônima em redes públicas. Ela mascara os endereços IP do usuário e criptografa seus dados pessoais. Isso garante que suas experiências online sejam privadas, protegidas e mais seguras.

## W

### Workflow

Sistema do Banrisul para a abertura e gerenciamento de requisições de acessos a produtos serviços. Tanto o sistema quanto as suas requisições são denominados **Workflow**.

## X

### XML - Extensible Markup Language

[Extensible Markup Language](https://aws.amazon.com/pt/what-is/xml/) (XML) permite definir e armazenar dados de maneira compartilhável. A XML oferece suporte a troca de informações entre sistemas de computador, como sites, bancos de dados e aplicações de terceiros. Regras predefinidas facilitam a transmissão de dados como arquivos XML em qualquer rede, pois o destinatário pode usar essas regras para ler os dados com precisão e eficiência.

## Y

## Z
