<div align="center">
  <img alt="oxe-dsign" src="https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/2048px-Microsoft_.NET_logo.svg.png" width="100">
</div>
<div align="center">
  <h3 style="font-size: 22px"><b>Teste Wernher Von Braun</b></h3>
</div>

---
</br>

## 🖥️ Technologies
- Entity Framework 7
- Dotnet Core 7
- Swagger

## 🚀 Running

Para executar o projeto, é necessário:
- ter .NET sdk 7 instalado
- ter ASP.NET 7 instalado

Após instalado


```bash
dotnet run --project Web
```

Para testar o client de telnet para executar alguns comandos (Ex.: 'ls', 'mkdir', 'cd', etc.) e receber dados de dispositivos remotos, recomendo utilizar o mobaXterm para criar o servidor telnet temporário localmente simular conexão com dispositivo iot remoto, assim você poderá executar os comandos na sua propria máquina e ver os resultados;

link para download: https://mobaxterm.mobatek.net/download.html



Decisões:

- Por entender que não seria mandatório para este teste técnico e por questão de tempo, optei por simplificar a implementação de autenticação do usuário e não fazer a conversão de senha para hash (o que seria obrigatório em api real).
Também trabalhei como dados em memória, por meio de um provider, para trazer mais facilidade em rodar e testar a aplicação e não precisa criar e popular um banco de dados inteiro (usaria mongoDb aqui).

- Utilizei um template repository com clean archteture e solid pronto em dotnet para facilitar os setup básico do projeto.

Sugestões de melhoria e evoluções futuras na api:
- Utilizar sistema de autenticação com json web token junto com Oauth2 no lugar do basic authentication.
- Encriptar as senhas dos usuários
- Utilizar Websockets para atualizar em tempo real dos dados dos dispositivos iot no lugar de pool de requisições no front-end para atualizar os dados
- Utilizar clean archteture e solid para melhorar a manutenibilidade do código 
- Utilzar um banco de dados para salvar os dados dos dispositivos IoT cadastrados
- Substituir o uso de Telnet por um protocolo mais seguro e mais eficiente, como SSH ou MQTT
- A entidade commandDesription e command poderiam ser uma só

Método de otimização de requisições: 
- Uso de Tasks para trabalhar com assincronicidade. Outros métodos poderiam ser implementados, como uso de cache.

