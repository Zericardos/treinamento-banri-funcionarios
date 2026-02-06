# Desafio dojo: Backend completo de clientes

Você precisa criar uma aplicação MM4 para a gestão de clientes, compreendendo toda a parte operacional de criação, consultas e atualização de clientes.

As user stories disponibilizadas pelo time de negócio são as seguintes:

```gherkin
US1 - Contar os usuários por agência

Como um analista financeiro
Eu quero saber o número total de usuários de uma determinada agência
Para que o sistema possa ter um controle sobre o número de usuários por agência

Regras
    [R01] A agência é obrigatória
    [R02] A agência deve aceitar somente os seguintes valores: 515, 590, 422 e 9008

Critérios de Aceitação
    [CA01] Dado que informo uma agência válida, o sistema deve retornar sucesso e informar o número total de usuários dessa agência
    [CA02] Dado que a agência não é informada, então a aplicação rejeita a contagem com a mensagem "Uma agência válida (515, 590, 4022 ou 9008) deve ser informada."
    [CA03] Dado que informo o agência inválida, então a aplicação rejeita a contagem com a mensagem "Uma agência válida (515, 590, 4022 ou 9008) deve ser informada"
 ```

```gherkin
US2 - Inclusão de novo cliente

Como um analista financeiro
Eu quero incluir um novo cliente informando seu código, nome, o tipo de pessoa e sua agência
Para que o sistema mantenha um cadastro oficial e padronizado de clientes

Regras
    [R01] O código do cliente é obrigatória
    [R02] O código do cliente é de livre escolha
    [R03] O tipo de pessoa é obrigatório
    [R04] O tipo pessoa deve aceitar apenas "F" para físico e "J" para jurídico
    [R05] A combinação de código do cliente e tipo de pessoa deve ser única na base
    [R06] O nome é obrigatório
    [R07] O nome deve ser alfanumérico
    [R08] A agência é obrigatória
    [R09] A agência deve aceitar somente os seguintes valores: 515, 590, 422 e 9008
    [R10] O valor capital social deve ser sempre 0 (zero) no momento da inclusão
    [R11] O operador é obrigatório e deve ser sempre preenchido com a matrícula do usuário logado no momento da inclusão
    [R12] A data de última atualização é obrigatória e deve ser sempre preenchida com a data data/hora atual no momento da inclusão

Critérios de Aceitação
    [CA01] Dado que informo um código cliente válido, um nome válido, um tipo de pessoa válido e uma agência válida, e não existe um cliente com a mesma combinação de código cliente e tipo pessoa, o sistema deve retornar sucesso, cadastrar o usuário com o valor capital social sendo 0 (zero), preencher o código do operador de acordo com usuário logado e a data de atualização com a data/hora atuais
    [CA02] Dado que o código do cliente não é informado, então a aplicação rejeita a inclusão com a mensagem "Um código válido deve ser informado."
    [CA03] Dado que o nome do cliente não é informado, então a aplicação rejeita a inclusão com a mensagem "Um nome alfanumérico válido deve ser informado."
    [CA04] Dado que informo o nome inválido, então a aplicação rejeita a inclusão com a mensagem "Um nome alfanumérico válido deve ser informado."
    [CA05] Dado que o tipo pessoa não é informado, então a aplicação rejeita a inclusão com a mensagem "Um tipo pessoa válido ("F" ou "J") deve ser informado."
    [CA06] Dado que informo o tipo pessoa inválido, então a aplicação rejeita a inclusão com a mensagem "Um tipo pessoa válido ("F" ou "J") deve ser informado."
    [CA07] Dado que a agência não é informada, então a aplicação rejeita a inclusão com a mensagem "Uma agência válida (515, 590, 4022 ou 9008) deve ser informada."
    [CA08] Dado que informo o agência inválida, então a aplicação rejeita a inclusão com a mensagem "Uma agência válida (515, 590, 4022 ou 9008) deve ser informada"
    [CA09] Dado que já existe um cliente com a mesma combinação de código cliente e tipo pessoa, então a aplicação rejeita a inclusão com a mensagem "Já existe na base de dados um cliente com a combinação de código cliente e tipo pessoa informados."
```

```gherkin
 US3 - Listar clientes por nome

 Como um gerente de agência
 Eu quero visualizar a lista completa dos clientes que tem o mesmo nome
 Para apoiar consultas operacionais, análises financeiras e auditorias internas

Regras
    [R01] O nome é obrigatório
    [R02] O nome deve ser alfanumérico
    [R03] A listagem deve exibir para cada cliente:
        - Código do cliente
        - Nome do cliente
        - Tipo pessoa
        - Número da agência
        - Valor Capital Social
        - Operador da última atualização
        - Data/hora da última atualização

Critérios de Aceitação
    [CA01] Dado que solicito a listagem mandando um nome válido informado, se houver clientes cadastrados com esse nome, então a aplicação retorna todos os clientes cadastradas com as informações esperadas
    [CA03] Dado que o nome do cliente não é informado, então a aplicação rejeita a listagem com a mensagem "Um nome alfanumérico válido deve ser informado."
    [CA04] Dado que informo o nome inválido, então a aplicação rejeita a listagem com a mensagem "Um nome alfanumérico válido deve ser informado."
    [CA05] Dado que solicito a listagem mandando um nome válido, e não há clientes cadastrados com o nome pedido, então a aplicação rejeita a listagem com a mensagem "Não existem clientes cadastrados com o nome informado."
```

## Objetivos

- Criação do projeto de **camada Q:**
  - Deve conter o controle por _alias_
  - Deve conter o controle de _SAC_
- Criação do projeto de **camada S:**
  - A interface pública deve obrigatoriamente fazer uso dos métodos gerados pelo **Gerador de Classes MM4** para cada uma das operações respectivas às user stories
  - Todas as regras contidas nas user stories devem ser satisfeitas
  - Deve conter o objeto de mapa de mensagens
  - Deve retornar para os devidos cenários, **mensagens idênticas** às definidas nos critérios de aceitação das user stories
- Criação do projeto de **camada U:**
  - Todos os critérios de aceitação contidos nas user stories devem ser atendidos por testes (não é necessária a entrega de casos de teste)
    - No nome do teste deve constar o identificador da user story e do critério de aceitação que ele cobre (exemplos: `US2_CA01_IncluirClienteComSucessoTest`, `US3_CA04_ListarClienteComNomeInvalidoTest`, etc.)
  - As devidas mensagens retornadas da camada S devem ser validadas de acordo com os critérios de aceitação contidos nas user stories
  - Deve conter o objeto mock com ao menos 1 teste de falha ou exceção com dependência "mockada"
- É necessária a agregação de todos os projetos na **solução padrão** (arquivo .sln)