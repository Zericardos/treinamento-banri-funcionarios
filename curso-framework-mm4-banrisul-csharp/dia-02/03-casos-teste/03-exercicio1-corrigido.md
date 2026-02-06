# 1. Gestão de categorias de produtos bancários

<!-- ATENÇÃO: Esses casos de teste são replicados várias vezes ao longo dos próximos dias e tópicos. Caso modifique algo aqui, certifique-se de efetuar o devido ajuste em todas as réplicas. -->

## US1 - Inclusão de nova categoria

```md
TC1 - Inclusão de categoria bem sucedida
User Story: US1 - Inclusão de nova categoria

Pré-condições
    - Não existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser incluída

Entradas/Ações
    - Informar um código numérico
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a inclusão

Resultados Esperados
    - A aplicação inclui a nova categoria na base e exibe mensagem de sucesso

Pós-condições
    - A nova categoria passa a existir na base
```

```md
TC2 - Inclusão de categoria rejeitada devido a código numérico não informado
User Story: US1 - Inclusão de nova categoria

Pré-condições
    -

Entradas/Ações
    - Não informar um código numérico
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a inclusão

Resultados Esperados
    - A aplicação rejeita a inclusão e exibe mensagem informando que o código numérico é inválido

Pós-condições
    - Nenhuma nova categoria é incluída
```

```md
TC3 - Inclusão de categoria rejeitada devido a código numérico já existente
User Story: US1 - Inclusão de nova categoria

Pré-condições
    - Já existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser incluída

Entradas/Ações
    - Informar um código numérico
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a inclusão

Resultados Esperados
    - A aplicação rejeita a inclusão e exibe mensagem informando que já existe uma categoria com o código numérico

Pós-condições
    - Nenhuma nova categoria é incluída
```

```md
TC4 - Inclusão de categoria rejeitada devido a descrição não informada ou inválida
User Story: US1 - Inclusão de nova categoria

Pré-condições
    -

Entradas/Ações
    - Informar um código numérico
    - Não informar uma descrição ou informar uma descrição inválida
    - Acionar a inclusão

Resultados Esperados
    - A aplicação rejeita a inclusão e exibe mensagem informando que a descrição é inválida

Pós-condições
    - Nenhuma nova categoria é incluída
```

## US2 - Remoção de categoria

```md
TC5 - Remoção de categoria bem sucedida
User Story: US2 - Remoção de categoria

Pré-condições  
    - Já existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser removida

Entradas/Ações  
    - Informar um código numérico
    - Acionar a remoção

Resultados Esperados  
    - A aplicação remove a categoria da base e exibe mensagem de sucesso

Pós-condições  
    - A categoria deixa de existir na base
```

```md
TC6 - Remoção de categoria rejeitada devido a código numérico inexistente
User Story: US2 - Remoção de categoria

Pré-condições  
    - Não existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser removida

Entradas/Ações  
    - Informar um código numérico
    - Acionar a remoção

Resultados Esperados  
    - A aplicação rejeita a remoção e exibe mensagem informando que não existe uma categoria com o código numérico

Pós-condições  
    - Nenhuma categoria é removida
```

## US3 - Alteração de dados de categoria

```md
TC7 - Alteração de categoria bem sucedida
User Story: US3 - Alteração de dados de categoria

Pré-condições
    - Já existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser alterada

Entradas/Ações
    - Informar um código numérico
    - Informar uma nova descrição válida (apenas letras, números e acentuação)
    - Acionar a alteração

Resultados Esperados
    - A aplicação altera a categoria na base com a nova descrição, com os dados de auditoria (usuário responsável e data/hora atuais) e exibe mensagem de sucesso

Pós-condições
    - A categoria passa a ter a nova descrição e as novas informações de auditoria na base
```

```md
TC8 - Alteração de categoria rejeitada devido a código numérico inexistente
User Story: US3 - Alteração de dados de categoria

Pré-condições
    - Não existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser alterada

Entradas/Ações
    - Informar um código numérico
    - Informar uma nova descrição válida (apenas letras, números e acentuação)
    - Acionar a alteração

Resultados Esperados
    - A aplicação rejeita a alteração e exibe mensagem informando que não existe uma categoria com o código numérico

Pós-condições
    - Nenhuma categoria é alterada
```

```md
TC9 - Alteração de categoria rejeitada devido a descrição não informada ou inválida
User Story: US3 - Alteração de dados de categoria

Pré-condições
    -

Entradas/Ações
    - Informar um código numérico
    - Não informar uma nova descrição ou informar uma nova descrição inválida
    - Acionar a alteração

Resultados Esperados
    - A aplicação rejeita a alteração e exibe mensagem informando que a descrição é inválida

Pós-condições
    - Nenhuma categoria é alterada
```

## US4 - Listagem de categorias

```md
TC10 - Listagem de categorias bem sucedida
User Story: US4 - Listagem de categorias

Pré-condições  
    - Já existem na base categorias

Entradas/Ações  
    - Acionar a listagem

Resultados Esperados  
    - A aplicação lista todas as categorias
    - Para cada categoria são exibidos: código numérico, descrição e informações de auditoria (última alteração)

Pós-condições  
    -
```

```md
TC11 - Listagem de categorias vazia
User Story: US4 - Listagem de categorias

Pré-condições  
    - Não existem na base categorias

Entradas/Ações  
    - Acionar a listagem

Resultados Esperados  
    - A aplicação rejeita a listagem e exibe mensagem informando que não existem categorias

Pós-condições  
    -
```

## US5 - Consulta de categoria por código ou descrição

```md
TC12 - Consulta de categoria por código numérico bem sucedida
User Story: US5 - Consulta de categoria por código ou descrição

Pré-condições
    - Já existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser consultada

Entradas/Ações
    - Informar um código numérico
    - Acionar a consulta

Resultados Esperados
    - A aplicação retorna 1 categoria
    - São exibidos: código numérico, descrição e informações de auditoria (última alteração)

Pós-condições
    -
```

```md
TC13 - Consulta de categoria por código numérico rejeitada
User Story: US5 - Consulta de categoria por código ou descrição

Pré-condições
    - Não existe na base uma categoria cujo código numérico corresponde ao código da categoria a ser consultada

Entradas/Ações
    - Informar um código numérico
    - Acionar a consulta

Resultados Esperados
    - A aplicação rejeita a consulta e exibe mensagem informando que não existe uma categoria com o código numérico

Pós-condições
    -
```

```md
TC14 - Consulta de categoria por descrição bem sucedida
User Story: US5 - Consulta de categoria por código ou descrição

Pré-condições
    - Já existe na base uma categoria cuja descrição é idêntica à descrição da categoria a ser consultada

Entradas/Ações
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a consulta

Resultados Esperados
    - A aplicação retorna 1 categoria
    - São exibidos: código numérico, descrição e informações de auditoria (última alteração)

Pós-condições
    -
```

```md
TC15 - Consulta de categoria por descrição rejeitada
User Story: US5 - Consulta de categoria por código ou descrição

Pré-condições
    - Não existe na base uma categoria cuja descrição é idêntica à descrição da categoria a ser consultada

Entradas/Ações
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a consulta

Resultados Esperados
    - A aplicação rejeita a consulta e exibe mensagem informando que não existe uma categoria com a descrição

Pós-condições
    -
```
