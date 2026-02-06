# Exercícios de Arquitetura 3 camadas

## 1. Correção de violação arquitetural na feature de idiomas

Neste exercício vamos variar um pouco: ao invés de trabalharmos com categorias, vamos trabalhar com idiomas.

Como pudemos concluir através do conteúdo, no nosso caso as camadas violam as regras quando:

1. A UI está utilizando os DAOs — que são um mecanismo fornecido pela DAL para que a BLL consiga operar com a DAL;
2. A UI ou a BLL estão implementando suas próprias versões de mecanismos de persistências de dados (suas próprias DAOs ou qualquer outra coisa semelhante que interaja diretamente com a base de dados) — tarefa de responsabilidade da DAL;
3. A UI ou a DAL estão usando a FECONID ou qualquer outra ferramenta de negócio — que é de uso exclusivo da BLL;
4. A UI ou a DAL estão implementando suas próprias ferramentas de negócio — tarefa de responsabilidade da BLL;
5. A BLL ou a DAL estão usando as rotas — que são referentes a aspectos de interação com o usuário — responsabilidade exclusiva da UI;
6. A BLL ou a DAL estão implementando algum tipo de mecanismo semelhante às rotas, para abrir interação direta com o usuário - tarefa de responsabilidade da UI.

No nosso boilerplate de **solução Cliente-Servidor** deste exercício (disponibilizado na pasta da aula), estamos com o projeto quebrado devido a violações nos itens **1 e 3**. Na rota de idiomas a UI está fazendo um trabalho que deveria ser de responsabilidade da BLL.
<!-- Boilerplate em [./_assets/16-exercicio1-boilerplate/] -->

> Nota: No boilerplate estamos introduzindo o conceito de serviços. Que na prática, são o mecanismo que a BLL utiliza para que a UI se comunique com ela. Na nossa solução Cliente-Servidor, **serviços** estão para a relação UI-BLL assim como **DAOs** estão para a relação BLL-DAL.

Refatore a feature de idiomas no projeto seguindo as implementações já feitas para as features de exemplos e categorias, de modo que as violações sejam corrigidas e as devidas responsabilidades sejam respeitadas.
