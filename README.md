# 🩺 Medical Scheduling API

API REST para **agendamento médico**, desenvolvida em **ASP.NET Core 8** aplicando **Clean Architecture** e **Domain-Driven Design (DDD)**.  
Projeto criado para **portfólio**, com endpoints documentados via **Swagger** e organização clara em camadas.

---

## 🚀 Tecnologias
- ASP.NET Core 8 (Minimal API)  
- Swagger / OpenAPI  
- Clean Architecture + DDD  
- In-memory repository (dados armazenados em listas)  
- C#  

---

## 🏗️ Estrutura do Projeto

O sistema segue uma arquitetura em **quatro camadas**, garantindo separação de responsabilidades e flexibilidade:

- **Api** → Endpoints REST (Minimal API, Swagger)  
- **Application** → Serviços, DTOs e lógica de negócio desacoplada da infraestrutura  
- **Domain** → Entidades centrais (`Patient`, `Doctor`) e regras essenciais do negócio  
- **Infrastructure** → Repositórios em memória (futuro suporte a banco de dados via EF Core)  

---

- ## ⚡ Endpoints disponíveis (Doctor)
- `GET /Doctor` → Lista todos os doutores
- `GET /Doctor/{id}` → Busca doutor por ID
- `POST /Doctor` → Cria um novo doutor
- `PUT /Doctor/{id}` → Atualiza dados de um doutor
- `DELETE /Doctor/{id}` → Remove doutor

## 📖 Exemplo de JSON (POST /Doutor)
```json
{
  "name": "Dra. Claudia Silva",
  "Specialty": "Cardiologia"
}
````
- ## ⚡ Endpoints disponíveis (Patient)
- `GET /Patient` → Lista todos os pacientes
- `GET /Patient/{id}` → Busca paciente por ID
- `POST /Patient` → Cria um novo paciente
- `PUT /Patient/{id}` → Atualiza dados de um paciente
- `DELETE /Patient/{id}` → Remove paciente

## 📖 Exemplo de JSON (POST /Patient)
```json
{
  "name": "João da Silva",
  "email": "joao@gmail.com"
}
