# Exercícios de Web: Modelo Cliente-Servidor

## 1. Transformando o cliente em um frontend

Neste exercício, você vai transformar de fato o cliente em um frontend, que vai permitir interatividade com o usuário.

A ideia é agregar **um menu de opções** na aplicação cliente, que permita ao usuário escolher qual operação HTTP realizar, e, nos casos de seleção dos métodos `POST` e `PUT`, solicitar também que o usuário digite a mensagem a ser enviada no corpo da requisição.

Utilize a **solução Cliente-Servidor** que foi preparada no laboratório anterior, nela você já vai possuir todos os recursos necessários para o exercício.

- No método `Main(...)` da `Program.cs` do projeto **Cliente**, implemente rotinas, métodos e classes (o que entender pertinente) para exibir um menu com as opções `GET`, `POST`, `PUT`, `DELETE` e um mecanismo de encerramento/saída;
  > Nota: Utilize o mecanismo de seleção que entender melhor, seja por um número representando a opção, ou por texto completo, etc.
- Para as opções `POST` e `PUT`, solicite que o usuário **digite uma mensagem adicional, que será anexada no corpo da requisição**;
- De acordo com cada opção, utilize a instância de `ClienteHttp` para chamar o método respectivo à opção selecionada, fazendo assim a requisição para o servidor;
- Exiba os resultados das requisições no console.
