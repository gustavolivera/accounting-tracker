# 📄 Gestão de Documentos Contábeis

Esta API foi desenvolvida com o objetivo de auxiliar profissionais do setor contábil no controle e acompanhamento de **documentos e extratos contábeis** que as empresas devem enviar aos escritórios de contabilidade.

## 🧾 Funcionalidade Principal

- Gerenciamento de **empresas** clientes do escritório contábil
- Controle de **documentos** obrigatórios a serem entregues mensalmente
- Verificação de envio de **extratos contábeis**
- Consulta e cadastro de **situações mensais** por empresa
- Envio de **Email** com a solicitação de extratos

## 🚀 Tecnologias Utilizadas

- **.NET 9** (ASP.NET Core Web API)
- **Entity Framework Core**
- **PostgreSQL**
- **Scalar** (documentação da API)

## 📦 Estrutura do Projeto

- `Domain` - Entidades do negócio
- `Application` - Interfaces e serviços da aplicação
- `Infrastructure` - Implementações, DbContext e acesso a dados
- `API` - Controllers e exposição dos endpoints

## 🔐 Segurança

- Endpoints protegidos com autenticação (em desenvolvimento)
