# Casos de teste

Depois de mapear os requisitos do negócio em user stories, também queremos definir formas para, durante o ciclo de desenvolvimento, validar se o que estamos entregando realmente atende aos requisitos especificados no início.

Para isso, utilizamos a técnica de casos de teste — mecanismo que nos ajuda a verificar, de maneira objetiva, se cada comportamento da aplicação funciona como deveria.

Casos de teste garantem que:

- As regras de negócio foram respeitadas
- Os critérios de aceitação foram cumpridos
- Comportamentos de erro e exceção estão corretamente implementados
- Nenhum comportamento inesperado está surgindo
- A qualidade da entrega é consistente e verificável

Existe também uma disciplina que trata das atividades de verificação, validação e garantia de qualidade — a engenharia de testes. Através dessa disciplina são formados analistas de testes, engenheiros de [QA](../../dicionario-banrisul.md#qa---quality-assurance) e especialistas em automação. Nosso foco não é aprofundar nessa área, mas sim entender algumas práticas que servirão como insumo para validar as funcionalidades desenvolvidas no dia a dia.

Aprender a **escrever e interpretar casos de teste com a devida valorização dos aspectos de qualidade** é uma habilidade importante para qualquer desenvolvedor profissional.

## Anatomia de casos de teste

Um caso de teste descreve um cenário específico que deve ser validado em uma funcionalidade. Ele sempre responde à pergunta: _Como verifico de forma objetiva e reproduzível que essa funcionalidade opera conforme o esperado?_

> Nota: O modelo de caso de teste apresentado aqui será o nosso padrão ao longo de toda a jornada. Porém, é importante lembrar que **cada empresa adapta a técnica conforme sua cultura — isso se aplica inclusive ao próprio Banrisul**, então variações são completamente normais dependendo do contexto.

Casos de teste são construídos com vistas principalmente para pré-condições, entradas/ações, resultado esperado e pós condições. Adicionalmente, também vamos agregar um identificador, uma breve descrição e um indicador de user story relacionada:

```md
<Identificador - Descrição>
User Story: <US>

Pré-condições
    - <Pré-condição 1>
    - <...>

Entradas/Ações  
    - <Entrada/Ação 1>
    - <...>

Resultados Esperados
    - <Resultado esperado 1>
    - <...>

Pós-condições
    - <Pós-condição 1>
    - <...>
```

Por exemplo, para a story:

```gherkin
US1 - Redefinição de senha

Como um usuário cadastrado na aplicação
Eu quero redefinir a minha senha
Para que eu possa voltar a utilizar a aplicação

Regras
    - Deve ser enviado um e-mail válido já cadastrado na aplicação
    - O link de redefinição expira após 30 minutos
    - O usuário deve definir uma senha que atenda aos requisitos definidos na US2 - Criação de senha
    - A redefinição só pode ser solicitada 1 vez por dia

Critérios de Aceitação
    - Ao informar um e-mail cadastrado, a aplicação exibe mensagem de sucesso e envia o link
    - Ao usar um link expirado, a aplicação informa que o processo deve ser refeito
    - A nova senha só é aceita se atender aos requisitos de complexidade definidos na US2 - Criação de senha
    - Após a redefinição, o usuário consegue acessar normalmente a aplicação com a nova senha
```

poderíamos criar os casos de teste:

```md
TC1 - Solicitação de redefinição bem sucedida
User Story: US1 - Redefinição de senha

Pré-condições
    - Usuário possui um e-mail cadastrado e ativo na aplicação
    - O serviço de envio de e-mails está disponível

Entradas/Ações
    - Informar um e-mail válido já registrado na aplicação
    - Solicitar redefinição de senha

Resultados Esperados
    - Um e-mail com o link de redefinição é disparado
    - A aplicação exibe mensagem de sucesso informando que o link foi enviado

Pós-condições
    - Um registro de solicitação de redefinição de senha é armazenado
    - Contador de solicitações do dia é incrementado
```

```md
TC2 - Tentativa de uso de link expirado
User Story: US1 - Redefinição de senha

Pré-condições
    - Usuário recebeu um link de redefinição
    - O link de redefinição excedeu o limite de 30 minutos após sua emissão

Entradas/Ações
    - Acessar o link expirado

Resultados Esperados
    - A aplicação exibe mensagem informando que o link expirou e que a redefinição deve ser solicitada novamente

Pós-condições
    - Nenhuma alteração é realizada na senha do usuário
```

```md
TC3 - Definição de nova senha fora dos requisitos mínimos
User Story: US1 - Redefinição de senha

Pré-condições
    - Usuário acessou um link válido de redefinição de senha
    - O link não está expirado

Entradas/Ações
    - Informar uma nova senha que não atende aos requisitos definidos na US2 — Criação de senha
    - Confirmar a redefinição

Resultados Esperados
    - A aplicação recusa a senha e exibe mensagem indicando que os requisitos de complexidade não foram atendidos

Pós-condições
    - A senha do usuário permanece inalterada
```

> Nota: A US2 — Criação de senha foi omitida por brevidade, para mantermos o foco no necessário.

```md
TC4 - Redefinição bem-sucedida com senha válida
User Story: US1 - Redefinição de senha

Pré-condições
    - Usuário acessou um link válido de redefinição de senha
    - A nova senha atende aos requisitos de complexidade

Entradas/Ações
    - Informar a nova senha válida
    - Confirmar a redefinição
    - Tentar acessar a aplicação com a nova senha

Resultados Esperados 
    - A redefinição é concluída com sucesso
    - Usuário consegue acessar a aplicação com a nova senha

Pós-condições
    - A senha antiga é substituída pela nova
    - O link é invalidado após o uso
```

Casos de teste ajudam a aumentar a qualidade das entregas, pois documentam de forma mais clara os comportamentos da aplicação, abrindo inclusive uma melhor possibilidade para construção de validações automatizadas.

Um bom caso de teste é **claro, objetivo e reproduzível**.

## Laboratório

Vamos exercitar agora a criação de alguns casos de teste para uma das user stories elicitadas no conteúdo anterior. Também cabe frisar que será o tipo de atividade que vamos elaborar somente nesse momento. A partir dos próximos dias (inclusive nas avaliações), vamos partir sempre de uma base de casos de teste já prontos.

Lembrando, a anatomia de um caso de teste segue o seguinte padrão:

```md
<Identificador - Descrição>
User Story: <US>

Pré-condições
    - <Pré-condição 1>
    - <...>

Entradas/Ações  
    - <Entrada/Ação 1>
    - <...>

Resultados Esperados
    - <Resultado esperado 1>
    - <...>

Pós-condições
    - <Pós-condição 1>
    - <...>
```

vamos exercitar casos de teste em cima da seguinte user story:

```gherkin
US5 - Consulta de idioma por código

Como um gerente de produtos digitais
Eu quero consultar um idioma pelo seu código
Para validar rapidamente operações com parceiros estrangeiros

Regras
    - A consulta pode ser realizada pelo código numérico ou pelo código textual ISO combinado
    - A consulta deve retornar exatamente 1 idioma caso cadastrado
    - A consulta deve retornar: código numérico, código textual ISO combinado, descrição e informações de auditoria (última alteração)
    - Caso não exista idioma correspondente, a aplicação deve informar inexistência

Critérios de Aceitação
    - Dado que informo um código numérico válido de um idioma existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo um código textual ISO combinado que resulta em um código numérico de um idioma existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo um código numérico inexistente, então a aplicação rejeita a consulta e informa que o idioma não foi encontrado
    - Dado que informo um código textual ISO combinado inválido ou que resulta em um código numérico inexistente, então a aplicação rejeita a consulta e informa que o idioma não foi encontrado
```

para essa US, podemos produzir os casos de teste:

### Casos de Teste

<!-- ATENÇÃO: Esses casos de teste são replicados várias vezes ao longo dos próximos dias e tópicos. Caso modifique algo aqui, certifique-se de efetuar o devido ajuste em todas as réplicas. -->

> Nota: Vamos começar de um número fictício de identificador dos casos de teste (TC12), supondo que já foram criados TCs anteriores para as USs 1, 2, 3 e 4.

```md
TC12 - Consulta de idioma por código numérico bem sucedida
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Já existe na base um idioma cujo código numérico corresponde ao código do idioma a ser consultado

Entradas/Ações
    - Informar um código numérico
    - Acionar a consulta

Resultados Esperados
    - A aplicação retorna 1 idioma
    - São exibidos: código numérico, código textual ISO combinado, descrição e informações de auditoria (última alteração)

Pós-condições
    -
```

```md
TC13 - Consulta de idioma por código numérico rejeitada
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Não existe na base um idioma cujo código numérico corresponde ao código do idioma a ser consultado

Entradas/Ações
    - Informar um código numérico
    - Acionar a consulta

Resultados Esperados
    - A aplicação rejeita a consulta e exibe mensagem informando que não existe um idioma com o código numérico

Pós-condições
    -
```

```md
TC14 - Consulta de idioma por código textual ISO combinado bem sucedida
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Já existe na base um idioma cujo código numérico corresponde ao código numérico resultante do código textual ISO combinado do idioma a ser consultado

Entradas/Ações
    - Informar um código textual ISO combinado válido (ex.: "en-US")
    - Acionar a consulta

Resultados Esperados
    - A aplicação retorna 1 idioma
    - São exibidos: código numérico, código textual ISO combinado, descrição e informações de auditoria (última alteração)

Pós-condições
    -
```

```md
TC15 - Consulta de idioma por código textual ISO combinado rejeitada
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Não existe na base um idioma cujo código numérico corresponde ao código numérico resultante do código textual ISO combinado do idioma a ser consultado

Entradas/Ações
    - Informar um código textual ISO combinado válido (ex.: "en-US")
    - Acionar a consulta

Resultados Esperados
    - A aplicação rejeita a consulta e exibe mensagem informando que não existe um idioma com o código textual ISO combinado

Pós-condições
    -
```

<!-- Registro completo de todos os TCs

```gherkin
US1 - Inclusão de novo idioma

Como um analista de operações globais
Eu quero incluir um novo idioma informando seu código textual ISO combinado e sua descrição
Para que o banco possa registrar oficialmente os idiomas suportados nas operações internacionais

Regras
    - O código textual ISO combinado é obrigatório
    - O código textual ISO combinado deve seguir o padrão: ISO 639-1 + "-" + ISO 3166-1 (2 letras para idioma e 2 letras para país)
    - O código textual informado deve ser convertido para um código numérico único e reversível usando a ferramenta FECONID
    - O código numérico resultante deve ser único na base
    - A descrição é obrigatória
    - A descrição deve conter apenas letras, números e acentuação

Critérios de Aceitação
    - Dado que informo um código textual ISO combinado válido e que resulta em um código numérico ainda não utilizado, e uma descrição válida, então a aplicação inclui o idioma com sucesso
    - Dado que informo um código textual ISO combinado inválido ou que resulta em um código numérico que já existe na base, então a aplicação rejeita a inclusão
    - Dado que a descrição não é informada ou é inválida, então a aplicação rejeita a inclusão
```

```md
TC1 - Inclusão de novo idioma bem sucedida
User Story: US1 - Inclusão de novo idioma

Pré-condições
    - Não existe na base um idioma cujo código numérico corresponde ao código do idioma a ser incluído

Entradas/Ações
    - Informar um código textual ISO combinado válido (ex.: "en-US")
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a inclusão

Resultados Esperados
    - A aplicação converte o código textual ISO combinado para código numérico através da FECONID
    - A aplicação inclui o novo idioma na base e exibe mensagem de sucesso

Pós-condições
    - O novo idioma passa a existir na base
```

```md
TC2 - Inclusão de idioma rejeitada devido a código textual ISO combinado não informado ou inválido
      
Pré-condições
    -

Entradas/Ações
    - Não informar um código textual ISO combinado ou informar um código textual ISO combinado inválido (ex.: "enUS", "en-U")
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a inclusão

Resultados Esperados
    - A aplicação rejeita a inclusão e exibe mensagem informando que o código textual ISO combinado é inválido

Pós-condições
    - Nenhum novo idioma é incluído
```

```md
TC3 - Inclusão de idioma rejeitada devido a código numérico já existente
User Story: US1 - Inclusão de novo idioma

Pré-condições
    - Já existe na base um idioma cujo código numérico corresponde ao código do idioma a ser incluído

Entradas/Ações
    - Informar um código textual ISO combinado válido (ex.: "en-US")
    - Informar uma descrição válida (apenas letras, números e acentuação)
    - Acionar a inclusão

Resultados Esperados
    - A aplicação converte o código textual ISO combinado para código numérico através da FECONID
    - A aplicação rejeita a inclusão e exibe mensagem informando que já existe um idioma com o código textual ISO combinado

Pós-condições
    - Nenhum novo idioma é incluído
```

```md
TC4 - Inclusão de idioma rejeitada devido a descrição não informada ou inválida
User Story: US1 - Inclusão de novo idioma

Pré-condições
    -

Entradas/Ações
    - Informar um código textual ISO combinado válido (ex.: "en-US")
    - Não informar uma descrição ou informar uma descrição inválida
    - Acionar a inclusão

Resultados Esperados
    - A aplicação rejeita a inclusão e exibe mensagem informando que a descrição é inválida

Pós-condições
    - Nenhum novo idioma é incluído
```

## US2 - Remoção de idioma - TA OK REVISADA

```md
TC5 - Remoção bem sucedida de idioma
User Story: US2 - Remoção de idioma

Pré-condições  
    - Já existe na base um idioma cujo código numérico corresponde ao código do idioma a ser removido

Entradas/Ações  
    - Informar um código numérico de idioma
    - Acionar a remoção

Resultados Esperados  
    - A aplicação remove o idioma da base
    - É exibida a mensagem de sucesso

Pós-condições  
    - O idioma deixa de existir na base
```

```md
TC6 - Remoção rejeitada de idioma devido a idioma inexistente
User Story: US2 - Remoção de idioma

Pré-condições  
    - Não existe na base um idioma cujo código numérico corresponde ao código do idioma a ser removido

Entradas/Ações  
    - Informar um código numérico de idioma
    - Acionar a remoção

Resultados Esperados  
    - É exibida a mensagem informando que o idioma não foi encontrado

Pós-condições  
    -
```

## US3 - Alteração de dados do idioma - TA OK REVISADA

```md
TC7 - Alteração bem sucedida de idioma
User Story: US3 - Alteração de dados do idioma

Pré-condições
    - Já existe na base um idioma cujo código numérico corresponde ao código do idioma a ser alterado

Entradas/Ações
    - Informar um código numérico de idioma
    - Informar uma nova descrição válida (apenas letras e acentuação)
    - Acionar a alteração

Resultados Esperados
    - A aplicação atualiza a descrição
    - A aplicação atualiza as informações de auditoria: último usuário e data/hora atuais
    - É exibida a mensagem de sucesso

Pós-condições
    - O idioma passa a ter a nova descrição e as novas informações de auditoria na base
```

```md
TC8 - Alteração rejeitada de idioma devido a descrição inválida
User Story: US3 - Alteração de dados do idioma

Pré-condições
    - Já existe na base um idioma cujo código numérico corresponde ao código do idioma a ser alterado

Entradas/Ações
    - Informar um código numérico de idioma
    - Não informar uma descrição ou informar uma descrição contendo um caractere especial (ex.: #)
    - Acionar a alteração

Resultados Esperados
    - A aplicação rejeita a alteração
    - É exibida a mensagem informando que a descrição é inválida

Pós-condições
    - O idioma mantém suas informações originais
```

```md
TC9 - Alteração rejeitada de idioma devido a idioma inexistente
User Story: US3 - Alteração de dados do idioma

Pré-condições
    - Não existe na base um idioma cujo código numérico corresponde ao código do idioma a ser alterado

Entradas/Ações
    - Informar um código numérico de idioma
    - Informar uma nova descrição válida (apenas letras e acentuação)
    - Acionar a alteração

Resultados Esperados
    - É exibida a mensagem informando que o idioma não foi encontrado

Pós-condições
    -
```

## US4 - Listagem de idiomas - TÁ OK REVISADA

```md
TC10 - Listagem de idiomas bem sucedida
User Story: US4 - Listagem de idiomas

Pré-condições  
    - Já existem na base idiomas cadastrados

Entradas/Ações  
    - Acionar a listagem

Resultados Esperados  
    - A aplicação lista todos os idiomas cadastrados
    - Para cada idioma, são exibidos: código textual ISO combinado e descrição

Pós-condições  
    -
```

```md
TC11 - Listagem de idiomas vazia
User Story: US4 - Listagem de idiomas

Pré-condições  
    - Não existem na base idiomas cadastrados

Entradas/Ações  
    - Acionar a listagem

Resultados Esperados  
    - É exibida a mensagem informando que não há idiomas cadastrados

Pós-condições  
    -
```

## US5 - Consulta de idioma por código - TA OK REVISADA

```md
TC12 - Consulta de idioma por código numérico bem sucedida
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Já existe na base um idioma cujo código numérico corresponde ao código do idioma a ser consultado

Entradas/Ações
    - Informar um código numérico
    - Acionar a consulta

Resultados Esperados
    - A aplicação retorna 1 idioma
    - São exibidos: código numérico, código textual ISO combinado, descrição e informações de auditoria (última alteração)

Pós-condições
    -
```

```md
TC13 - Consulta de idioma por código numérico rejeitada
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Não existe na base um idioma cujo código numérico corresponde ao código do idioma a ser consultado

Entradas/Ações
    - Informar um código numérico
    - Acionar a consulta

Resultados Esperados
    - A aplicação rejeita a consulta e exibe mensagem informando que não existe um idioma com o código numérico

Pós-condições
    -
```

```md
TC14 - Consulta de idioma por código textual ISO combinado bem sucedida
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Já existe na base um idioma cujo código numérico corresponde ao código numérico resultante do código textual ISO combinado do idioma a ser consultado

Entradas/Ações
    - Informar um código textual ISO combinado válido (ex.: "en-US")
    - Acionar a consulta

Resultados Esperados
    - A aplicação retorna 1 idioma
    - São exibidos: código numérico, código textual ISO combinado, descrição e informações de auditoria (última alteração)

Pós-condições
    -
```

```md
TC15 - Consulta de idioma por código textual ISO combinado rejeitada
User Story: US5 - Consulta de idioma por código

Pré-condições
    - Não existe na base um idioma cujo código numérico corresponde ao código numérico resultante do código textual ISO combinado do idioma a ser consultado

Entradas/Ações
    - Informar um código textual ISO combinado válido (ex.: "en-US")
    - Acionar a consulta

Resultados Esperados
    - A aplicação rejeita a consulta e exibe mensagem informando que não existe um idioma com o código textual ISO combinado

Pós-condições
    -
```

-->

## [Exercícios](02-exercicios.md)
