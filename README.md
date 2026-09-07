# 🛒 Sistema de Loja em C# + SQL Server

Um projeto desenvolvido em **C# com integração ao SQL Server**, criado para praticar conceitos de programação, banco de dados e integração entre aplicação e armazenamento de informações.

O sistema simula o gerenciamento de uma loja, permitindo cadastrar produtos, consultar informações, realizar compras e controlar o estoque.

## 🚀 Funcionalidades

* 📦 Cadastro de produtos
* 🔎 Consulta de produtos
* 🛒 Realização de compras
* 📊 Verificação de estoque
* 🔄 Atualização automática da quantidade disponível
* 💾 Integração entre C# e SQL Server
* 🔐 Utilização de comandos SQL parametrizados

## 🛠️ Tecnologias

* **C#**
* **.NET**
* **SQL Server**
* **Microsoft.Data.SqlClient**

## 🗄️ Banco de Dados

O projeto utiliza o banco de dados:

`Loja`

Com a tabela:

`Produto`

Estrutura da tabela:

```text
Produto
├── ID
├── Nome
├── Quantidade
└── Valor
```

Os dados inseridos pelo programa em C# são enviados diretamente para o SQL Server.

## ⚙️ Como funciona

Ao iniciar o sistema, o usuário encontra um menu com as opções:

```text
1 - Mostrar produtos
2 - Comprar produto
3 - Verificar estoque
4 - Adicionar produto
5 - Sair
```

O C# realiza as operações e se comunica com o banco de dados por meio do `Microsoft.Data.SqlClient`.

## ▶️ Como executar

### Pré-requisitos

* .NET SDK
* SQL Server Express
* SQL Server Management Studio (SSMS)

### 1. Baixe o projeto

Clone o repositório ou faça o download dos arquivos pelo GitHub.

### 2. Configure o banco

Abra o arquivo:

`LojaProdutos.sql`

Execute o script no SQL Server Management Studio para criar o banco e a tabela.

### 3. Execute o projeto

Dentro da pasta do projeto:

```bash
dotnet restore
dotnet run
```

### 💡 Objetivo

Este projeto foi desenvolvido como prática de **C# integrado a banco de dados**, buscando compreender na prática como uma aplicação pode inserir, consultar e alterar informações armazenadas no SQL Server.

## 👨‍💻 Autor

**Kelvin Gonçalves**

Projeto desenvolvido para aprimorar conhecimentos em **C#, SQL Server e desenvolvimento de aplicações conectadas a banco de dados**.
