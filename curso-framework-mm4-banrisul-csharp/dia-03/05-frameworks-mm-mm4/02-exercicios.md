# Exercícios de Frameworks, MM e o MM4

## 1. Preparando hook do servidor para trabalhar com `GET`, `POST`, `PUT` e `DELETE`

Neste exercício, vamos trabalhar em cima do hook do servidor, preparando-o para trabalhar com os 4 verbos `GET`, `POST`, `PUT` e `DELETE`. O método `PUT` já está implementado como código de exemplo.

Utilize a **solução Cliente-Servidor** que foi preparada no laboratório anterior. Em cima dela vamos fazer algumas adaptações dos arquivos, e após, você irá implementar o exercício.

**Adaptação 1:** Atualize toda a classe `Program.cs` do projeto **Cliente** com o seguinte código:

```csharp
using PseudoFramework.ClienteUtils;
using PseudoFramework.SharedUtils;
using System;
using System.Linq;

namespace Cliente
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cliente = new ClienteHttp();

            Console.WriteLine("::::::::::::::::::");
            Console.WriteLine($":::: {ClienteHttp.IDENTIFICADOR} :::::");
            Console.WriteLine("::::::::::::::::::\n");

            while (true)
            {
                ExibirOpcoes();

                var opcao = ObterOpcao();

                if (opcao == "S")
                    break;

                Console.WriteLine();

                var saudacao = ExecutarOpcao<Saudacao>(cliente, opcao);

                if (saudacao != null)
                {
                    string cumprimentos = string.Concat(Enumerable.Repeat(saudacao.Cumprimento + " ", saudacao.NumeroCumprimentos));

                    Console.WriteLine($"{cumprimentos}{saudacao.PronomeTratamento} {saudacao.Nome}!");

                    Console.WriteLine();
                }
            }

            cliente.Encerrar();

            Console.ReadKey();
        }

        private static void ExibirOpcoes()
        {
            Console.WriteLine("1 - GET");
            Console.WriteLine("2 - POST");
            Console.WriteLine("3 - PUT");
            Console.WriteLine("4 - DELETE");
            Console.WriteLine("S - Sair");
        }

        private static string ObterOpcao()
        {
            Console.Write("Selecione a ação: ");

            return Console.ReadLine().Trim().ToUpper();
        }

        private static T ExecutarOpcao<T>(ClienteHttp cliente, string opcao)
        {
            var caminho = ConectorHttp.ObterCaminho();

            switch (opcao)
            {
                case "1":
                    return ExecutarGet<T>(cliente);

                case "2":
                    return ExecutarPost<Saudacao, T>(cliente, SolicitarSaudacao());

                case "3":
                    return ExecutarPut<Saudacao, T>(cliente, SolicitarSaudacao());

                case "4":
                    return ExecutarDelete<T>(cliente);

                default:
                    {
                        Console.WriteLine("Opção inválida.");

                        Console.WriteLine();

                        return default(T);
                    }
            }
        }

        private static T ExecutarGet<T>(ClienteHttp cliente)
        {
            var jsonResposta = cliente.EnviarGet(ConectorHttp.ObterCaminho());

            T objetoResposta = ConversorJson.Desserializar<T>(jsonResposta);

            return objetoResposta;
        }

        private static TOut ExecutarPost<TIn, TOut>(ClienteHttp cliente, TIn objetoRequisicao)
        {
            var jsonResposta = cliente.EnviarPost(ConectorHttp.ObterCaminho(), objetoRequisicao);

            TOut objetoResposta = ConversorJson.Desserializar<TOut>(jsonResposta);

            return objetoResposta;
        }

        private static TOut ExecutarPut<TIn, TOut>(ClienteHttp cliente, TIn objetoRequisicao)
        {
            var jsonResposta = cliente.EnviarPut(ConectorHttp.ObterCaminho(), objetoRequisicao);

            TOut objetoResposta = ConversorJson.Desserializar<TOut>(jsonResposta);

            return objetoResposta;
        }

        private static T ExecutarDelete<T>(ClienteHttp cliente)
        {
            var jsonResposta = cliente.EnviarDelete(ConectorHttp.ObterCaminho());

            T objetoResposta = ConversorJson.Desserializar<T>(jsonResposta);

            return objetoResposta;
        }

        private static Saudacao SolicitarSaudacao()
        {
            var saudacao = new Saudacao();

            Console.Write("Digita o pronome de tratamento (sr., Mr., Sra., Srta., etc.: ");

            saudacao.PronomeTratamento = Console.ReadLine().Trim();

            Console.Write("Digita o nome da pessoa: ");

            saudacao.Nome = Console.ReadLine().Trim();

            Console.Write("Digita a saudação: ");

            saudacao.Cumprimento = Console.ReadLine().Trim();

            // TODO (OPCIONAL): Implemente a captura de número de cumprimentos também via console
            saudacao.NumeroCumprimentos = 2;

            Console.WriteLine();

            return saudacao;
        }
    }
}
```

**Adaptação 2:** Atualize toda a classe `Program.cs` do projeto **Servidor** com o seguinte código:

```csharp
using PseudoFramework.ServidorUtils;
using PseudoFramework.SharedUtils;
using System;
using System.Linq;

namespace Servidor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var servidor = new ServidorHttp(ConectorHttp.ObterCaminho());

            Console.WriteLine(":::::::::::::::::");
            Console.WriteLine($":::: {ServidorHttp.IDENTIFICADOR} :::");
            Console.WriteLine(":::::::::::::::::\n");

            Console.WriteLine("Pressione ENTER para encerrar...\n");

            servidor.ProcessarHook =
                (verbo, caminho, json) => InterceptarRequisicao(verbo, caminho, json);

            servidor.Iniciar();

            Console.ReadKey();

            servidor.Encerrar();

            Console.ReadKey();
        }

        private static Saudacao InterceptarRequisicao(string verboHttp, string caminho, string json)
        {
            switch (verboHttp)
            {
                case "PUT":
                    return InterceptarPut(json);

                default:
                    return null;
            }
        }

        private static Saudacao InterceptarPut(string json)
        {
            var saudacaoCliente = ConversorJson.Desserializar<Saudacao>(json);

            string cumprimentos = string.Concat(Enumerable.Repeat(saudacaoCliente.Cumprimento + " ", saudacaoCliente.NumeroCumprimentos));

            string saudacaoClienteExpressao = $"{cumprimentos}{saudacaoCliente.PronomeTratamento} {saudacaoCliente.Nome}!";

            Console.WriteLine($"\n\n{saudacaoClienteExpressao} \n");

            var saudacaoServidor = new Saudacao()
            {
                Cumprimento = "Olá",
                NumeroCumprimentos = 1,
                PronomeTratamento = "Sr.",
                Nome = "Cliente",
            };

            return saudacaoServidor;
        }
    }
}
```

Agora sim, ajuste a classe `Program.cs` do projeto **Servidor** para trabalhar com os demais verbos (`GET`, `POST` e `DELETE`). Siga as seguintes regras:

- `GET`: Vai sempre retornar um objeto fixo de saudação, cujo cliente já está preparado pra receber, desserializar e imprimir no console:
  
  ```csharp
  var saudacaoServidor = new Saudacao() {
    Cumprimento = "Olá",
    NumeroCumprimentos = 1,
    PronomeTratamento = "Sr.",
    Nome = "Cliente",
  }
  ```

- `POST`: Assim como o `PUT`, vai receber o objeto, desserializá-lo e imprimir no console, e após vai retornar a mesma saudação que o `GET` responde;
- `DELETE`: Vai retornar também a mesma saudação que o `GET` responde.

Ao final das implementações no servidor, rode as duas aplicações e faça requisições para cada um dos verbos, observando os resultados retornados no console da aplicação cliente.
