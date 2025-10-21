# SwaggerSchoolAPI

## Integrantes
- Aksel Viktor Caminha Rae - RM99011
- Ian Xavier Kuraoka – RM98860
- Arthur Petrin – RM98735
- Miguel Ruan de Souza – RM551239

## Descrição
API RESTful em ASP.NET Core 8 com Entity Framework Core (SQLite) e Swagger. 
Inclui CRUD completo para Aluno, Professor, Disciplina e Matrícula, pesquisas com LINQ, e integração com API pública do IBGE.

## Como executar (local)
1. Instale .NET 8 SDK.
2. No diretório do projeto:
   ```bash
   dotnet restore
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   dotnet run
   ```
3. Acesse o Swagger:
   - http://localhost:5200/swagger ou https://localhost:7200/swagger

## Endpoints principais
- `GET /api/alunos` — lista alunos.
- `GET /api/alunos/search?nome=ana` — pesquisa com LINQ.
- `GET /api/alunos/ranking-matriculas` — LINQ com agrupamento e ordenação.
- `GET /api/professores`, `GET /api/disciplinas`, `GET /api/matriculas` — CRUDs.
- `GET /api/integracoes/ibge/estados` — integração com API externa (IBGE).

## Estrutura do projeto
- Controllers, Models, Data (DbContext), Services, Repositories e Diagrams (Mermaid).

## Publicação (Cloud)
- 
