# Stock Quote

Aplicação para monitoração de ações via linha de terminal

## Configuração

Para a aplicação funcionar corretamente, você precisa criar uma arquivo chamado `AppConfig.json` dentro do projeto StockQuote com as seguintes configurações:

```
{
  "apiKey": "6U6BFVbZ7EcDsfrSykgacJ",
  "mailFrom": "stockquote.dev@gmail.com",
  "mailTo": "stockquote.dev@gmail.com",
  "smtpPort": 587,
  "smtpHost": "smtp.gmail.com",
  "smtpPassword": "ayfkoazscykpobqb"
}
```

#### Observações
Para receber o email no seu email pessoal/profissional, você precisa colocar ele no campo `mailTo`.


## Como usar

Agora que você configurou tudo corretamente, clone o repositório e abra um terminal na pasta criada. Após isso, use o seguinte comando
```bash
cd StockQuote
```
Agora, basta rodar um comando no seguinte formato:
```bash
dotnet run NOME_DA_ACAO PRECO_DE_COMPRA PRECO_DE_VENDA
```
Exemplo:
```bash
dotnet run VALE3 40.00 55.75
```