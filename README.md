#Como rodar a aplicação local:
1.	Abra a solução Cashflow.MicroService.sln no visual studio
2.	Rode o projeto Cashflow.Application.Webapi
3.  Se preferir testar pelo swagger, abra no navegador o endereço localhost:33001/swagger.

#Endpoints:

1) POST http://localhost:33001/api/FinancialTransaction

Contrato para transação de crédito:
{
  "description": "Transação de crédito exemplo",
  "value": 100,
  "financialTransactionType": 1
}

Contrato para transação de débito:
{
  "description": "Transação de débito exemplo",
  "value": 50,
  "financialTransactionType": 0
}

2) GET http://localhost:33001/api/FinancialTransaction/GetAllByDate?date=2022-12-13

Este endpoint retorna todas as transações do dia.

3) GET http://localhost:33001/api/FinancialTransaction/GetCashflowByDate?date=2022-12-13

Retorna o resumo do dia
