# 🧠 CareNest — Gerenciador de Prontuários Médicos e Consultas Psicológicas (WIP)

**CareNest** é uma aplicação web desenvolvida para simplificar e organizar o dia a dia de psicólogos e profissionais da saúde, permitindo o gerenciamento eficiente e seguro de prontuários, agendamentos e sessões terapêuticas.

---

## 🎯 Objetivo do Projeto

O objetivo principal é oferecer um sistema intuitivo, seguro e bem estruturado para administrar:
- **Cadastro de pacientes**
- **Perfis de psicólogos**
- **Agendamentos de sessões**
- **Prontuários médicos e psicológicos**
- **Contatos de emergência**

A aplicação segue os princípios da **Arquitetura DDD (Domain-Driven Design)**, garantindo escalabilidade, testabilidade e separação clara de responsabilidades.

---

## 🧩 Funcionalidades

### 👥 Gestão de Pacientes e Psicólogos
- Cadastro e gerenciamento de **pacientes** e **psicólogos**
- Registro de dados com **contatos de emergência** e **histórico de endereços**
- Validação de documentos (**CPF/CNPJ**)

### 📅 Agendamentos e Sessões
- Criação e edição de **agendas**
- Registro de **sessões terapêuticas**, com observações e status
- Associação de sessões aos respectivos psicólogos e pacientes

### 📝 Prontuários Médicos e Psicológicos
- Histórico completo de **prontuários**
- Anotações, prescrições e anexos por sessão
- Armazenamento seguro de arquivos (opcional)

### 🔐 Autenticação e Perfis de Acesso
- Login seguro para psicólogos e equipe
- Controle de acesso baseado em papéis (Admin, Psicólogo, Assistente)

### 📦 Destaques da Arquitetura
- Estrutura baseada em **Domain-Driven Design (DDD)**
- Separação clara entre as camadas: **Domínio**, **Aplicação**, **Infraestrutura** e **API**
- Utiliza:
  - **Brighter** para mensageria interna (CQRS)
  - **Mapster** como alternativa leve ao AutoMapper
  - **ValueOf** para validação forte de objetos de valor

---

## 🚧 Tecnologias Utilizadas

- **.NET 9 Web API**
- **C#**
- **Mapster** (alternativa ao AutoMapper)
- **Brighter** (alternativa ao MediatR)
- **ValueOf** (validação de objetos de valor)
- Opcionais:
A implementar...

---

## 📂 Estrutura do Projeto (DDD)

