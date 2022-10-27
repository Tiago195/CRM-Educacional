# CRM Manager

Este projeto foi feito para auxiliar o usuario a ter controle de uma central de cursos.

## Funcionalidades
### As principais funcionalides desta aplicação são:
 - Cadastrar lead (candidato) com validação de CPF
 - Cadastrar novos cursos
 - Cadastrar uma nova inscrição, a inscrição é comporta por um candidato e um curso, um candidato pode ter mais de uma inscrição.

## Tecnologias utilizadas
 - .NET
 - C#
 - ASP.NET Core
 - Entity Framework Core (EF)
 - SQL Server
 - xUnit
 - FluentAssertions
 - Moq
 - Docker
 
## Dependencias
Para iniciar o projeto você vai precisar ter dotnet e ef instalados na maquina com a versão 6
 
## Como inicializar o projeto

Clone o projeto
```bash
git clone git@github.com:Tiago195/CRM-Educacional.git
```

Inicialize o banco de dados atraves do comando
```docker
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password12" \
   -p 1433:1433 --name sql1 --hostname sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest
```
Subir o banco
```bash
dotnet ef database update --project CRM-Educacional
```

Para inicializar a aplicação
```bash
dotnet run --project CRM-Educacional
```
