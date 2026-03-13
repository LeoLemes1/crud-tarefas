# Tarefas CRUD

API REST para gerenciamento de tarefas em .NET 10, com arquitetura DDD em camadas.

**Stack:** ASP.NET Core, Entity Framework Core, PostgreSQL.

**Estrutura:** quatro projetos — *Api* (controllers e endpoints), *Application* (handlers e DTOs), *Domain* (entidades e interfaces) e *Infrastructure* (repositórios, DbContext e EF).

**Endpoints:** `GET/POST/PUT/DELETE` em `/api/tarefas` para listar, criar, atualizar e excluir tarefas.

**SOLID:** O projeto aplica S (handlers e repositório com responsabilidade única), D (dependência de `IRepositorioTarefa` e DI), I (`IRepositorioTarefa` enxuta) e L (implementações substituíveis). O princípio O não é explorado explicitamente.
