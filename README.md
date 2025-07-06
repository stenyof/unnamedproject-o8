# 💰 MyFinance Web - Projeto ASP.NET Core MVC

Este projeto foi desenvolvido como parte da disciplina de Práticas de Desenvolvimento no curso de Pós-Graduação em Engenharia de Software da PUC Minas. Ele simula um sistema de controle financeiro pessoal com funcionalidades de cadastro, movimentações e relatórios.

---

## 📌 Descrição do Projeto

O **MyFinance Web** é uma aplicação ASP.NET Core MVC que permite ao usuário:

- Cadastrar planos de conta (despesas e receitas)
- Registrar transações financeiras
- Gerar relatórios com gráficos de totais por mês e por plano de conta

---

## 🧱 Arquitetura Utilizada

A estrutura segue o padrão **MVC (Model-View-Controller)**:

- **Models**: classes de domínio (`PlanoContaModel`, `TransacaoModel`)
- **Views**: páginas Razor (`Index.cshtml`, `Cadastro.cshtml`, etc.)
- **Controllers**: lógica de roteamento e orquestração entre Model e View

Além disso, utilizamos uma separação clara de responsabilidades:

- `Domain/` → modelos utilizados pela aplicação
- `Infrastructure/` → DbContext e entidades do EF Core
- `Services/` → regras de negócio e acesso ao banco

---

## 🛠️ Tecnologias Utilizadas

- [.NET 9.0 (Preview)](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- ASP.NET Core MVC
- Entity Framework Core (com SQL Server LocalDB)
- [Chart.js](https://www.chartjs.org/) para gráficos interativos
- Visual Studio / VS Code
- SQL Server Management Studio (SSMS)
- GitHub para versionamento

---

## ⚙️ Como configurar e executar

### Pré-requisitos

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- SQL Server Express (ou outro compatível)
- Visual Studio / Visual Studio Code
- Git

### Passos para execução

1. **Clone o repositório**

```bash
git clone https://github.com/stenyof/unnamedproject-o8.git
cd unnamedproject-o8/myfinance-web-netcore

Configure a base de dados

No SQL Server, crie um banco de dados chamado MyFinanceWeb. Depois, execute o script de criação das tabelas manualmente (caso o EF não tenha gerado via migrations).

Configure a connection string

No arquivo appsettings.json, ajuste a string de conexão conforme seu ambiente:

json
Copiar
Editar
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=MyFinanceWeb;Trusted_Connection=True;TrustServerCertificate=True;"
}
Rode o projeto

bash
Copiar
Editar
dotnet run
Acesse em: http://localhost:5112

📊 Funcionalidades Implementadas
 CRUD de Plano de Contas

 CRUD de Transações

 Relatórios com gráficos de:

Total por mês (barra)

Distribuição por plano de conta (pizza)

📁 Organização das Pastas
pgsql
Copiar
Editar
├── Controllers/
├── Domain/
├── Infrastructure/
│   └── Entities/
├── Services/
├── Views/
│   ├── PlanoConta/
│   ├── Transacao/
│   └── Relatorio/
├── wwwroot/
├── appsettings.json
├── MyFinanceDbContext.cs
📄 Licença
Este projeto é acadêmico e não possui fins comerciais. Utilização livre para fins educacionais.

👨‍💻 Autor
Stenyo Fonseca
Pós-graduação em Engenharia de Software - PUC Minas
GitHub: stenyof