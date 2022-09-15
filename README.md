## Projeto Época especial Lp2
# Madelinette 

## Autoria:
Francisco Costa(21903228)

### Informação do Trabalho:
#### Francisco Costa
  - 100% do projeto

### Repositório Git
https://github.com/francismsc/EpocaEspecialLp2

##
No desenvolvimento deste projeto tentei fazer uso do design MVC, mantendo
as classes separadas conforme as funções de interface, organização de dados e interação.

Foram tambem utilizados os design patterns:
 -Double Buffer para manter o jogador de ver a cena a ser criada á sua frente,mantendo uma barreira de processamento entre sí e o programa
 -Game Loop necessária para criar uma experiência de jogo continua sem pausas
 -Update method usado em combinação com o Game Loop para atualizar os "GameObjects"
 da cena
 -Componnent pattern, para dividir melhor as funções entre cada classe tornando cada "Gameobject" em algo mais independente e isoloado
  -Observer pattern para evocar os eventos nas classes "Model"
Para criar o mapa de jogo utilizei um Objecto **Map** que contém uma lista de **Point** esta por sua vez contém dados sobre cada Ponto um **Vertex** com informação a ser mostrada no ecrã, e uma Lista de **Point** dentro de cada **Point**, criando assim uma estrutura em grafos dentro de **Point**. Isto permitiu tornar a pesquisa pelas possíveis jogadas mais fácil

### Diagrama UML Simples
![Diagrama UML](Uml.png)

## Referências
- [1] Arquitetura. https://github.com/VideojogosLusofona/MVCExample
- [2] Double Buffer, GameObject, Component, Arquitetura. https://github.com/VideojogosLusofona/lp2_2021_aulas/tree/main/Aula12/Exercicio4