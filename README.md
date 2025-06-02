
# 🌎 Eventus API - Global Solution FIAP

## 💡 Sobre o Projeto

O **Eventus** é uma solução inovadora para monitoramento e resposta a eventos extremos, como enchentes, ondas de calor e desastres naturais. A plataforma integra um backend robusto em C#/.NET com banco Oracle, permitindo cadastro de usuários, relatos, abrigos e alertas, tudo em tempo real e integrado ao aplicativo mobile.

---

## 🛠️ Tecnologias Utilizadas

- C# (.NET 8, ASP.NET Core Web API)
- Entity Framework Core + Oracle
- Swagger (documentação automática)
- Razor Pages com TagHelpers
- Banco de dados Oracle

---

## 🖼️ Diagrama de Classes
> ![Diagrama de Classes UML](https://media.discordapp.net/attachments/954097907806642297/1378845402631114893/diagrama_c.drawio.png?ex=683e1559&is=683cc3d9&hm=6921b95084e3284b3563a5e6be8e335b673454c5907efa53a7b6d9d337bfff13&=&format=webp&quality=lossless&width=690&height=760)

---

## 🚀 Como Rodar o Projeto

### 1. Clone o repositório
```
git clone https://github.com/akemilol/Eventus.API-Csharp.git
```

### 2. Configure a conexão com o Oracle
No arquivo `appsettings.json`, ajuste a `DefaultConnection`:
```
"ConnectionStrings": {
  "DefaultConnection": "coloque seu acesso ao oracle sql developer"
}
```

### 3. Execute as migrations para criar as tabelas:
```
dotnet ef database update
```

### 4. Rode a aplicação:
```
dotnet run
```

### 5. Acesse o Swagger (documentação e teste da API):
- [http://localhost:5000/swagger](http://localhost:5000/swagger)  
- ou na porta informada no terminal.

### 6. Acesse a Razor Page de Usuários:
- [http://localhost:5000/Usuarios](http://localhost:5000/Usuarios)

---

## 📱 Projeto do Aplicativo Mobile (Frontend)

- **Repositório:**  
  [https://github.com/akemilol/Eventus-Mobile](https://github.com/akemilol/Eventus-Mobile.git)

---

## 🎬 Vídeo Demonstrativo

> [Mostrando o Funcionamento da aplicação](https://youtu.be/oiTAOJGtXGs) 

---

## 🚀 Vídeo Pitch

> [video (máx. 3 minutos)]  

---

## 💻 Exemplos de JSON para Teste (Swagger)

**POST /api/Usuarios**
```json
{
  "nome": "Maria Teste",
  "email": "maria@email.com",
  "senha": "senha123",
  "cpf": "12345678911",
  "cep": "01001000",
  "dataNascimento": "1990-01-01T00:00:00"
}
```

**POST /api/Relatos**
```json
{
  "usuarioId": 1,
  "descricao": "Alagamento na Av. Brasil",
  "localizacao": "Av. Brasil, 1000",
  "dataEvento": "2025-06-01T14:00:00"
}
```

**POST /api/Abrigos**
```json
{
  "nomeAbrigo": "Abrigo Central",
  "enderecoAbrigo": "Rua das Flores, 123",
  "cepAbrigo": "04005000",
  "cidadeAbrigo": "São Paulo",
  "ufAbrigo": "SP",
  "latitudeAbrig": -23.563,
  "longitudeAbrig": -46.654
}
```

---

## 📑 Prints e Evidências
> Imagem 1, mostra o banco de dados funcionando com o swagger.
> ![Exemplo Swagger](https://media.discordapp.net/attachments/1277037400996053085/1378851410212294767/image.png?ex=683e1af2&is=683cc972&hm=69ecda06761f5a3f3d4ff7f70776b07aaa879e3f84e6fb8fb0634564d2d5f1ad&=&format=webp&quality=lossless&width=1032&height=293)
> Imagem 2, mostra o razor funcionando com os dados do banco.
> ![Exemplo Razor Page](https://media.discordapp.net/attachments/1277037400996053085/1378851285192806492/image.png?ex=683e1ad4&is=683cc954&hm=4e2133a7bbaf2ba5582cadc0e38992606e2235ea83f68f9aad751cf444a7672e&=&format=webp&quality=lossless&width=1032&height=458)

---
## 👩‍💻 Integrantes: 
- 💁‍♀️Valéria Conceição Dos Santos - RM: 557177
- 💁‍♀️Mirela Pinheiro Silva Rodrigues - RM: 558191
