# Criação de uma API REST de Cadastro de Usuários.
***
Esta é uma aplicação simples que foi desenvolvida para avaliação técnica de um processo de seleção como desenvolvedor.NET.

### Requisitos

1) Utilizar Docker para aplicação (Web API) e Banco de Dados (SQLServer) executados em container.
2) Utilizar princípios SOLID e arquitetura limpa (Clean Architecture).
3) Utilizar o EF Core como ferramenta ORM para acesso e persistência de banco de dados.
4) Utilizar injeção de dependência e padrões de projeto.
5) Documentar Web Api através do Swagger.
6) Aplicar teste unitário na classe criada.

---
### Pré-Requisitos
1) Docker
---
### Passos
1. Criar uma pasta local C:\GrupoGBIControleUsuarios
2. Clonar o projeto https://github.com/MarcoAntonioVianaSouza/GrupoGBIControleUsuarios.git
3. cd GrupoGBIControleUsuarios
4. docker-compose build
5. docker-compose up
6. Acessar o URL http://localhost:8090/swagger/index.html
---
Obs: Projeto será alterado para banco Postgree (No momento ele utiliza o banco de dados SqlServer).

## Questões Técnicas

 - [Resposta Questões Técnicas](https://downgit.github.io/#/home?url=https://github.com/MarcoAntonioVianaSouza/GrupoGBIControleUsuarios/blob/master/RESPOSTA_QUESTOES_TECNICAS_MARCOVIANA.pdf)

## Vídeo da aplicação Visual Studio - Montagem do ambiente docker.
   Porque o Docker? 
   Pelo favor do docker permitir a criação de container, podemos empacotar a aplicação e todas as suas depednências e executar em qualquer ambiente.
   ---
   OBS: Por padrão o Swagger não aparece no ambiente produção. Habilitamos para aparecer em ambiente de produção apenas para testar as ações. (No vídeo gravado o Swagger não aparece, pois o ajuste foi feito posteriormente).
   
- [Vídeo com execução da Aplicação](https://downgit.github.io/#/home?url=https://github.com/MarcoAntonioVianaSouza/GrupoGBIControleUsuarios/blob/master/AplicacaoExecutandoLocalmente-AnalisandoErroDocker-2.zip)

