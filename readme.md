Aqui está um README.md completo e bem estruturado para o seu projeto SIGPA_Backend, baseado nas informações fornecidas:

***

# SIGPA Backend

API REST desenvolvida em .NET 9.0 seguindo **Clean Architecture**. Sistema modular com separação clara de responsabilidades entre Domain, Application, Infrastructure e API.

## 🏗️ Arquitetura

```
SIGPA_Backend/
├── API/                 # Controllers e configuração
├── Application/         # UseCases, DTOs e interfaces
├── Domain/              # Entidades, interfaces de repositório e regras de negócio
├── Infrastructure/      # Repositories, DbContext, Services concretos
├── docker-compose.yml   # Backend + PostgreSQL
└── Program.cs           # Injeção de dependências
```

## 🚀 Setup Inicial

1. **Criar projeto base**
   ```bash
   dotnet new webapi -n SIGPA_Backend
   cd SIGPA_Backend
   ```

2. **Criar estrutura de pastas**
   ```
   API/
   Domain/
   Application/
   Infrastructure/
   ```

3. **Restaurar dependências**
   ```bash
   dotnet restore
   ```

## 📁 Estrutura por Camada

### Domain
- Entidades: `Usuario`, `Papel`
- Interfaces de repositório: `IUsuarioRepository`
- Enums, regras de negócio e validações
- **Importante**: Não conhece Infrastructure

### Application
- **DTOs**: Entradas/saídas dos UseCases
- **Interfaces de serviço**: `ISenhaHasher`
- **UseCases**: Cada um em sua pasta
  ```
  Application/UseCases/CriarUsuario/
  ├── ICriarUsuarioUseCase.cs
  └── CriarUsuarioUseCase.cs
  ```
- Orquestra lógica de negócio via interfaces

### Infrastructure
- **Data/AppDbContext.cs**: Conexão PostgreSQL
- **Mappings**: EF Core para entidades
- **Repositories**: Implementam interfaces do Domain
- **Services concretos**: `SenhaHasher`
- **DependencyInjection.cs** (opcional): Centraliza registros DI

### API
- **Controllers**: Recebem requests → chamam UseCases → retornam responses
- **Program.cs**: Configuração completa de DI

## 🗄️ Banco de Dados

### Docker Compose
```yaml
services:
  backend:
    build: .
    ports:
      - "5000:80"
    depends_on:
      - postgres
  
  postgres:
    image: postgres:15
    environment:
      POSTGRES_DB: sigpa
      POSTGRES_USER: sigpa
      POSTGRES_PASSWORD: sigpa123
    ports:
      - "5432:5432"
```

### Migrações EF Core
```bash
# Criar migração
dotnet ef migrations add NomeDaMigracao

# Aplicar migração
dotnet ef database update
```

## 🔧 Configuração de Dependências

No `Program.cs`, registrar:

```csharp
// Application
builder.Services.AddScoped<ICriarUsuarioUseCase, CriarUsuarioUseCase>();

// Infrastructure
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISenhaHasher, SenhaHasher>();
builder.Services.AddDbContext<AppDbContext>(options => ...);
```

## 🎯 Princípios da Clean Architecture

- ✅ **Application** e **Domain** não conhecem **Infrastructure**
- ✅ **API** conecta tudo via Dependency Injection
- ✅ **UseCases** = centro da lógica de negócio
- ✅ **Controllers** = apenas orquestração HTTP
- ✅ **Hash de senha**: Interface em Application, impl. em Infrastructure

## 🏃‍♂️ Executar Projeto

```bash
# Desenvolvimento
dotnet run

# Docker
docker-compose up --build

# Migrações + Run
dotnet ef database update && dotnet run
```

## 📋 Pacotes Necessários

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.0" />
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.0" />
```

***

**Pronto para produção!** 🚀

Gostaria de adicionar alguma seção específica como exemplos de endpoints, testes unitários ou instruções de deploy?