# Frameworks, MM e o MM4

Um framework é uma **estrutura de software que fornece um conjunto organizado de componentes reutilizáveis, padrões arquiteturais, bibliotecas, ferramentas e regras de uso** que facilitam o desenvolvimento de aplicações. Ele funciona como um esqueleto pré-definido, sobre o qual soluções específicas podem ser construídas, garantindo consistência, produtividade e previsibilidade ao longo do ciclo de desenvolvimento.

Ao contrário de bibliotecas isoladas, que o desenvolvedor utiliza conforme necessidade, um framework geralmente define o fluxo principal da aplicação, estabelecendo **como** e **quando** seus componentes serão utilizados. Assim, o desenvolvedor escreve o código que "preenche" as partes necessárias dentro de uma estrutura já validada.

Frameworks não são apenas conjuntos de classes ou funções — eles materializam uma forma particular de resolver problemas, apoiada por decisões arquiteturais, práticas recomendadas e mecanismos de padronização.

Principais características de um framework:

- Reutilização estruturada: Evita retrabalho, pois funcionalidades comuns já vêm prontas;
- Padrões e boas práticas incorporados: Encapsula convenções de arquitetura, segurança, manutenção e estilo;
- Extensibilidade: permite adicionar comportamentos específicos sem modificar sua base;
- Fluxo definido: O fluxo principal é conduzido pelo framework — o desenvolvedor implementa as funcionalidades em cima de pontos definidos do fluxo;
- Consistência entre projetos: Projetos que usam o mesmo framework tendem a seguir a mesma linha estrutural e de qualidade;
- Produtividade aumentada: Acelera entregas, reduz erros e diminui a curva de aprendizagem interna.

Usar um framework é trabalhar dentro de um **ambiente com regras**:

- Você ganha componentes que já resolvem problemas comuns;
- Ganha uma arquitetura consistente;
- Ganha ferramentas e convenções.

Em troca, seu código se adapta ao modo de funcionamento do framework e essa relação aumenta a eficiência e reduz drasticamente o "custo cognitivo" de manutenção.

Ao longo da jornada vamos trabalhar exclusivamente com as ferramentas, padrões e utilitários do framework [MM4](/dicionario-banrisul.md#mm4---meta-modelo-versão-4), porém, é importante antes de aprofundar no MM4, conhecer também os demais integrantes da família de frameworks [MM](/dicionario-banrisul.md#mm---meta-modelo).

## Frameworks MM

Os frameworks da família **[MM](/dicionario-banrisul.md#mm---meta-modelo)** seguem fielmente o conceito de framework descritos acima.

A seguir vamos conhecer cada integrante da família MM, e sus objetivos com enfoque de atendimento das 3 principais plataformas do ecossistema Banrisul: Web, Mobile e Serviços de backoffice.

### MM3, MM4 e MM5 (Web)

- O **[MM3](/dicionario-banrisul.md#mm3---meta-modelo-versão-3)** utilizava as tecnologias `ASP` e `VB6`, sendo o primeiro MM desenvolvido para a plataforma web. Está descontinuado, e sua descontinuação se deu devido a desafios relacionados a desempenho e manutenção frente às limitações das tecnologias e o término do suporte oficial da Microsoft;
- O **[MM4](/dicionario-banrisul.md#mm4---meta-modelo-versão-4)** utiliza essencialmente `ASP.NET` e `C#`, e é o substituto natural do MM3 para atendimento à web. Possui camadas de backend e frontend, porém, seu frontend (no formato de arquivos `XHTML` em uma dinâmica de renderização do lado servidor) está em processo de descontinuação;
- O **[MM5](/dicionario-banrisul.md#mm5---meta-modelo-versão-5)** utiliza-se da dinâmica de [SPA](/dicionario-banrisul.md#spa---single-page-application)s com a maior parte da renderização do lado cliente, com uso de arquivos padrão HTML (HTML5). Tem como principal objetivo substituir o frontend do MM4.

> Dica: A associação entre MM4 e MM5 pode gerar certa confusão. Para fins de melhor compreensão, mantenha sempre em mente que a relação MM4 e MM5 não é de total substituição, e sim de **coexistência com substituição apenas do frontend**.

### MMM (Mobile)

- O **[MMM](/dicionario-banrisul.md#mmm---meta-modelo-mobile)** é uma adaptação do MM5 que atende à plataforma mobile através do uso do **Apache Cordova**, que utiliza uma abordagem de **WebViews** para prover aplicativos híbridos e cross plataforma com acesso aos recursos (às APIs) dos aparelhos móveis através de plugins.

> Dica: Considere a mesma dinâmica de associação entre MMM e MM4 que o MM5 tem para com o MM4. Ou seja, **MMM também é só frontend, porém nesse caso mobile**.

### MMD (Serviços)

- O **[MMD](/dicionario-banrisul.md#mmd---meta-modelo-daemon)** utiliza Java, e tem como objetivo fornecer a camada de serviços automatizados do banco, abrangendo camadas de integração com o legado, operações recorrentes e transações em massa, através de ambientes de alta disponibilidade, alta taxa de transferência (throughput) e baixa latência.

## Foco de cada componente dos MMs

![Componentes MM](./_assets/01-componentes-mm.png)

## Laboratório

Neste laboratório, importe novamente o _boilerplate_ de **solução Cliente-Servidor - v2** fornecido na pasta desta aula. Você perceberá que o "framework" desse boilerplate agora evoluiu. Ele passou a ter um terceiro projeto, que agora agrega as funcionalidades de suporte ao cliente e ao servidor, e também adicionou utilitários para montagem da conexão HTTP e _serialização_ e _desserialização_ de JSON. Ou seja, agora o sistema tem suporte a requisições utilizando JSON ao invés de texto simples. Com isso, agora se torna necessária a utilização de objetos no cliente, para que possa fazer requisições ao servidor.
<!-- Boilerplate em [./_assets/02-cliente-servidor-boilerplate-v2/] -->

Vamos criar um exemplo de POST no cliente:

### Passo 1: Criar classe `Saudacao` no Cliente

Vamos criar uma nova classe na raíz do projeto **Cliente**, chamada `Saudacao`:

```csharp
namespace Cliente
{
    public class Saudacao
    {
        public string PronomeTratamento { get; set; }
        public string Nome { get; set; }
        public string Cumprimento { get; set; }
        public int NumeroCumprimentos { get; set; }
    }
}
```

### Passo 2: Implementar POST no Cliente

No método `Main(...)` da `Program.cs` do projeto **Cliente**, vamos enviar uma instância de `Saudacao` por POST:

```csharp
public static void Main(string[] args)
{
   // [...]

   // TODO: Implementar um POST
   var saudacao = new Saudacao()
   {
      Cumprimento = "Salve",
      NumeroCumprimentos = 2,
      PronomeTratamento = "Sr.",
      Nome = "John Doe",
   };

   cliente.EnviarPost(ConectorHttp.ObterCaminho(), saudacao); // using PseudoFramework.SharedUtils;

   // [...]
}
```

> Nota: Após, o comentário com **TODO** pode ser removido.

Já no lado do servidor, agora o mesmo aceita a implementação de [Hook](/dicionario-banrisul.md#hook)s, que servem basicamente para que **código personalizado ligado ao fluxo da requisição possa ser executado** enquanto a requisição trafega pelo servidor.

Vamos implementar a interceptação do POST através do hook:

### Passo 1: Criar classe `Saudacao` no Servidor

Criar a mesma classe `Saudacao`, agora na raíz do projeto **Servidor**:

```csharp
namespace Servidor
{
    public class Saudacao
    {
      public string PronomeTratamento { get; set; }
      public string Nome { get; set; }
      public string Cumprimento { get; set; }
      public int NumeroCumprimentos { get; set; }
    }
}
```

### Passo 2: Implementar interceptação de POST no Servidor

Vamos implementar o hook para interceptar o método POST no servidor (mais especificamente sua classe `Program`):

```csharp
public static void Main(string[] args)
{
   // [...]

   // TODO: Implementar hook de POST
   servidor.ProcessarHook = (verbo, caminho, json) =>
   {
         if (verbo == "POST")
         {
            Saudacao saudacao = ConversorJson.Desserializar<Saudacao>(json);

            string cumprimentos = string.Concat(Enumerable.Repeat(saudacao.Cumprimento + " ", saudacao.NumeroCumprimentos)); // using System.Linq;

            string saudacaoExpressao = $"{cumprimentos}{saudacao.PronomeTratamento} {saudacao.Nome}!";

            Console.WriteLine($"\n\n{saudacaoExpressao} \n");

            var momento = DateTime.Now;

            return new
            {
               origem = ServidorHttp.IDENTIFICADOR,
               verboHttp = verbo,
               caminho = caminho,
               momento = momento,
               respostaString = $"Resposta de {ServidorHttp.IDENTIFICADOR} para a requisição {verbo} em {caminho} processada às {momento} \"{saudacaoExpressao}\": OK"
            };
         }

         return null;
   };

   // [...]
}
```

> Nota: Após, o comentário com **TODO** pode ser removido.

Execute as duas aplicações e verifique se a comunicação `POST` foi bem sucedida nos respectivos consoles.

## [Exercícios](02-exercicios.md)
