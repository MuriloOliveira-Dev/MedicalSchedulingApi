# 🩺 Medical Scheduling API

API REST para **agendamento médico**, desenvolvida em **ASP.NET Core 8** aplicando **Clean Architecture** e **Domain-Driven Design (DDD)**.  
Projeto criado para **portfólio**, com endpoints documentados via **Swagger** e organização clara em camadas.

---
![Work in Progress](https://img.shields.io/badge/status-WIP-yellow)
---

## 🚀 Tecnologias
- ASP.NET Core 8 (Minimal API)  
- Swagger / OpenAPI  
- Clean Architecture + DDD  
- Entity Framework Core com PostgreSQL  
- DTOs para entrada de dados  
- C#  
---

## 🏗️ Estrutura do Projeto

O sistema segue uma arquitetura em **quatro camadas**, garantindo separação de responsabilidades e flexibilidade:

- **Api** → Endpoints REST (Minimal API, Swagger)  
- **Application** → Serviços, DTOs e lógica de negócio desacoplada da infraestrutura  
- **Domain** → Entidades centrais (`Patient`, `Doctor`) e regras essenciais do negócio  
- **Infrastructure** → Persistência de dados via **Entity Framework Core** (PostgreSQL) e repositórios

---

## ✨ Novidades / Refactor

- Endpoints de **Patient** e **Doctor** agora utilizam **DTOs** para entrada de dados.  
- O campo `Id` **não é mais enviado no body** de POST ou PUT; é gerado pelo sistema ou passado na URL.  
- Swagger atualizado para refletir apenas os campos editáveis nos bodies (`Name`, `Email`, `Specialty`).  
- PUT agora só recebe `Id` pela URL e os dados editáveis no body.

> ⚠️ Nota: Para atualização (PUT), o `Id` deve ser passado **na URL**, e o body só contém os campos `Name` e `Email` / `Specialty`.

---

## ⚡ Endpoints disponíveis (Doctor)
- `GET /Doctor` → Lista todos os médicos  
- `GET /Doctor/{id}` → Busca médico por ID  
- `POST /Doctor` → Cria um novo médico  
- `PUT /Doctor/{id}` → Atualiza dados de um médico  
- `DELETE /Doctor/{id}` → Remove médico  

## 📖 Exemplo de JSON (POST /Doctor)
```json
{
  "name": "Dra. Claudia Silva",
  "specialty": "Cardiologia"
}
````
---
## ⚡ Endpoints disponíveis (Patient)
- `GET /Patient` → Lista todos os pacientes  
- `GET /Patient/{id}` → Busca paciente por ID  
- `POST /Patient` → Cria um novo paciente  
- `PUT /Patient/{id}` → Atualiza dados de um paciente  
- `DELETE /Patient/{id}` → Remove paciente  

## 📖 Exemplo de JSON (POST /Doctor)
```json
{
  "name": "Murilo Oliveira",
  "email": "dev.murilooliveira@gmail.com",
  "birthdate": "1995-11-12"
}
````
---
##💡 Observações
- O campo BirthDate usa DateOnly no backend, garantindo que apenas a data seja armazenada.
- Swagger já está configurado para documentação e testes de endpoints.
- Projeto pronto para integração com PostgreSQL, mas ainda será expandido com novas entidades (ex.: consultas, agendamentos).
