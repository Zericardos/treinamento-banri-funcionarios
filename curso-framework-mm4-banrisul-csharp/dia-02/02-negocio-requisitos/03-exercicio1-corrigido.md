# 1. Gestão de categorias de produtos bancários

<!-- ATENÇÃO: Essas user stories são replicadas várias vezes ao longo dos próximos dias e tópicos. Caso modifique algo aqui, certifique-se de efetuar o devido ajuste em todas as réplicas. -->

```gherkin
US1 - Inclusão de nova categoria

Como um analista de marketing
Eu quero incluir uma nova categoria informando seu código numérico e sua descrição
Para que o banco possa manter um cadastro oficial e padronizado de categorias utilizadas por diversas áreas

Regras
    - O código numérico é obrigatório
    - O código numérico é de livre escolha
    - O código numérico deve ser único na base
    - A descrição é obrigatória
    - A descrição deve conter apenas letras, números e acentuação

Critérios de Aceitação
    - Dado que informo um código numérico ainda não utilizado e uma descrição válida, então a aplicação inclui a categoria com sucesso
    - Dado que o código numérico não é informado ou já existe na base, então a aplicação rejeita a inclusão
    - Dado que a descrição não é informada ou é inválida, então a aplicação rejeita a inclusão
```

```gherkin
US2 - Remoção de categoria

Como um analista comercial
Eu quero remover uma categoria previamente cadastrada
Para evitar que equipes selecionem categorias obsoletas no cadastro de novos produtos

Regras
    - A remoção deve eliminar a categoria fisicamente da base
    - A remoção deve se dar pela seleção por código numérico

Critérios de Aceitação
    - Dado que informo o código numérico de uma categoria existente, então a aplicação remove a categoria com sucesso
    - Dado que o código numérico informado não existe na base, então a aplicação rejeita a remoção e informa que a categoria não foi encontrada
```

```gherkin
US3 - Alteração de dados de categoria

Como um gerente de marketing
Eu quero alterar a descrição de uma categoria já cadastrada
Para corrigir informações incompletas ou ajustá-la às estratégias atuais de marketing

Regras
    - Apenas a descrição pode ser alterada
    - O código numérico não pode ser modificado
    - A nova descrição é obrigatória
    - A nova descrição deve conter apenas letras, números e acentuação
    - A alteração deve registrar informações de auditoria: usuário responsável e data/hora atuais

Critérios de Aceitação
    - Dado que informo uma nova descrição válida, então a aplicação altera a categoria e registra as informações de auditoria com sucesso
    - Dado que o código numérico informado não existe na base, então a aplicação rejeita a alteração e informa que a categoria não foi encontrada
    - Dado que a nova descrição não é informada ou é inválida, então a aplicação rejeita a alteração e informa que a descrição é inválida
```

```gherkin
US4 - Listagem de categorias

Como um gerente de marketing
Eu quero visualizar a lista de todas as categorias cadastradas
Para apoiar a criação de campanhas, análises de portfólio e decisões estratégicas

Regras
    - A listagem deve retornar todas as categorias cadastradas
    - A listagem deve exibir: código numérico, descrição e informações de auditoria (última alteração)

Critérios de Aceitação
    - Ao solicitar a listagem, a aplicação retorna todas as categorias existentes com suas informações
    - Se não houver categorias cadastradas, então a aplicação rejeita a consulta e informa que a lista está vazia
```

```gherkin
US5 - Consulta de categoria por código ou descrição

Como um gerente de produtos digitais
Eu quero consultar uma categoria pelo seu código numérico ou pela descrição
Para validar rapidamente informações em reuniões e decisões com áreas internas e parceiros

Regras
    - A consulta pode ser realizada pelo código numérico ou pela descrição exata
    - A consulta deve retornar exatamente 1 categoria caso cadastrada
    - A consulta deve retornar: código numérico, descrição e informações de auditoria (última alteração)
    - Caso não exista categoria correspondente, a aplicação deve informar inexistência

Critérios de Aceitação
    - Dado que informo um código numérico válido de uma categoria existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo uma descrição exata de uma categoria existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo um código numérico inexistente, então a aplicação rejeita a consulta e informa que a categoria não foi encontrada
    - Dado que informo uma descrição inexistente, então a aplicação rejeita a consulta e informa que a categoria não foi encontrada
```
