# Web: Modelo Cliente-Servidor

O **modelo Cliente-Servidor** é um dos pilares da computação moderna. Ele define uma forma organizada de comunicação entre dois componentes principais:

- **Cliente:** A aplicação que **faz uma requisição** — ou seja, que pede algo;
- **Servidor:** A aplicação que **recebe o pedido**, processa a informação e **responde**.

Esse padrão é utilizado em praticamente todos os sistemas distribuídos — de um simples site na web até plataformas corporativas complexas.

É como se as duas partes se comunicassem:

> Cliente: _"Olá servidor, preciso do número de telefone da pessoa chamada John Doe, sei que você armazena a base de lista telefônica aí do seu lado. Pode me mandar?"_
>
> Servidor: _"Claro cliente! já localizei aqui o número para a pessoa com esse nome. Aqui está: (99) 95959-9595."_

Para que esse tipo de interação seja possível, existem diversos **padrões, protocolos e formatos** que regulam a comunicação entre sistemas, como:

- **Protocolos de comunicação:** HTTP, HTTPS, FTP, SMTP, AMQP, gRPC, entre outros;
- **Formatos de troca de dados:** Texto, XML, JSON, BSON, TOON, binário, entre outros.

## Protocolos de comunicação

Um **protocolo de comunicação** define _como_ duas partes devem se comportar durante interação mútua — em outras palavras, ele é a **regra de convivência e interação** que cliente e servidor precisam seguir para conviver em harmonia.

No desenvolvimento de aplicações, os protocolos mais comuns se dividem em duas categorias:

### Protocolos síncronos

São baseados no ciclo **requisição - resposta imediata**. Ou seja: o cliente envia um pedido e **aguarda a resposta no mesmo canal** antes de continuar.

O exemplo mais conhecido é o **[HTTP](../../dicionario-banrisul.md#http---hypertext-transfer-protocol) (e sua variação segura, [HTTPS](../../dicionario-banrisul.md#https---hypertext-transfer-protocol-secure))**, utilizado em praticamente toda a web.

Neste modelo, o ciclo costuma ser:

- Cliente: Abre uma conexão com o servidor;
- Cliente: Envia uma requisição indicando um **verbo de intenção** (`GET`, `POST`, `PUT`, `DELETE`, entre outros — verbos HTTP);
- Cliente: Aguarda o processamento e resposta do servidor;
- Servidor: Recebe o indicativo de conexão e aceita a abertura;
- Servidor: Recebe a requisição e a processa conforme a intenção expressa pelo cliente;
- Servidor: Devolve a resposta adequada ao cliente;
- Cliente: Recebe a resposta do servidor;
- Fecha ou reutiliza a conexão para um próximo ciclo.

Esse tipo de comunicação é mais intuitivo, sendo ideal para operações rápidas e transações que precisam de confirmação imediata.

### Protocolos assíncronos

Baseiam-se em um sistema denominado **mensageria** — onde o cliente envia uma mensagem e **não precisa aguardar a resposta de imediato**. Ele continua seu trabalho, e quando o servidor processar a mensagem, a resposta chega **por outro canal**, às vezes minutos (ou horas... ou dias) depois.

Esse tipo de comunicação usa um intermediário, chamado **[Message Broker](../../dicionario-banrisul.md#message-broker)**, que pode ser, por exemplo, o **RabbitMQ**, que através de um protocolo AMQP, possibilita um ciclo semelhante a este:

- Cliente: Abre uma conexão com o message broker;
- Servidor: Abre uma conexão com o message broker;
- Cliente: Envia uma mensagem de requisição para uma fila específica, mapeada pelo message broker;
- Servidor: Está previamente inscrito na mesma fila que o message broker mapeou, e assim que pode, recebe a mensagem de requisição através da fila em questão e inicia o processamento;
- Servidor: Quando finalizado o processamento e for necessário, envia a mensagem de resposta para a fila de retorno também mapeada pelo message broker;
- Cliente: Assim como o servidor, está previamente inscrito na fila de retorno, assim, recebe a mensagem de resposta através dessa fila;
- Cliente e Servidor: Mantêm conexões ativas com o message broker.

Esse tipo de comunicação é menos intuitivo, mas agrega níveis mais sofisticados de confiabilidade e resiliência, sendo ideal para transações que possibilitam processamento que não necessita ser imediato, mas precisa ser confiável e pode ocorrer em grandes volumes.

## Formatos de troca de dados

Se o protocolo de comunicação é a regra de convivência e interação, o **formato de troca de dados** pode ser entendido como o **idioma** usado por cliente e servidor para se comunicarem.

Ou seja, mesmo que ambos sigam as regras de boa convivência, se falarem idiomas diferentes, a interação vai continuar sendo ineficaz.

No desenvolvimento de aplicações, alguns formatos comuns de trocas de arquivos são:

- **Texto simples (plain text):** Ideal para mensagens rápidas e legíveis;
- **[XML](../../dicionario-banrisul.md#xml---extensible-markup-language):** Mais verboso, permite estruturas complexas e validações mais estruturadas de dados;
- **[JSON](../../dicionario-banrisul.md#json---javascript-object-notation):** Formato mais leve, muito usado em [API](/dicionario-banrisul.md#api---application-programming-interface)s web modernas.

## Backend e Frontend

No mundo web, os termos **backend** e **frontend** estão diretamente ligados ao modelo Cliente-Servidor:

- **Backend:** atua como **servidor**, processando, armazenando e fornecendo dados solicitados pelo frontend. Implementa a lógica de negócio e responde às requisições, garantindo informações corretas e estruturadas. Funciona exatamente como o servidor do modelo Cliente-Servidor, seguindo protocolos e entendendo o idioma dos dados.
- **Frontend:** é voltado para o usuário — geralmente um navegador, app móvel ou página web — e **se comporta como cliente**, fazendo requisições para obter dados, enviar informações ou realizar ações. Se comunica com o backend seguindo os mesmos princípios do modelo Cliente-Servidor.

A diferença de termos reflete o foco: O **frontend** prioriza a interface e a interação com o usuário, e o **backend** prioriza o processamento e fornecimento de dados. Em essência, a lógica de comunicação, regras de interação (protocolos de comunicação) e idioma (formatos de troca de dados) permanecem os mesmos, apenas adaptados ao contexto da web.

## Laboratório

Neste laboratório, importe o _boilerplate_ de **solução Cliente-Servidor** fornecido na pasta da aula, e com alguns passos, vamos colocar as aplicações cliente e servidor para executarem e se comunicarem em protocolo síncrono HTTP com formato de dados texto simples, de acordo com os conceitos estudados.
<!-- Boilerplate em [./_assets/01-cliente-servidor-boilerplate-v1/] -->

### Passo 1: Implementar a execução do servidor

No método `Main(...)` da `Program.cs` do projeto **Servidor**, nos trechos comentados com **TODO**, vamos implementar:

```csharp
public static void Main(string[] args)
{
   // [...]

   // TODO: Uso do objeto ServidorHttp para disponibilizar o servidor para recepção de requisições de clientes
   var servidor = new ServidorHttp(ObterCaminho());

   servidor.Iniciar();

   // [...]

   // TODO: [Instância de ServidorHttp].Encerrar();
   servidor.Encerrar();

   // [...]
}
```

> Nota: Após, os comentários com **TODO** podem ser removidos.

### Passo 2: Implementar a execução do cliente

No método `Main(...)` da `Program.cs` do projeto **Cliente**, nos trechos comentados com **TODO**, vamos implementar:

```csharp
public static void Main(string[] args)
{
   // [...]

   // TODO: Uso do objeto ClienteHttp para efetuar requisições para o servidor
   var cliente = new ClienteHttp();

   // [...]

   // TODO: [Instância de ClienteHttp].Encerrar();
   cliente.Encerrar();

   // [...]
}
```

> Nota: Após, os comentários com **TODO** podem ser removidos.

### Passo 3: Implementar a primeira requisição - `GET`

No mesmo método `Main(...)` da `Program.cs` do projeto cliente, agora vamos complementar com uma primeira chamada:

```csharp
public static void Main(string[] args)
{
   // [...]

   var cliente = new ClienteHttp();

   var respostaGet = cliente.EnviarGet(ObterCaminho());

   // [...]

   cliente.Encerrar();

   // [...]
}
```

Execute as duas aplicações e verifique se a comunicação `GET` foi bem sucedida nos respectivos consoles.

## [Exercícios](02-exercicios.md)
