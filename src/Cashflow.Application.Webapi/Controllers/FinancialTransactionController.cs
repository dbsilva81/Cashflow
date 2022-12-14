using Cashflow.Crosscutting.DataTransferObjects;
using Cashflow.Services.Contracts;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cashflow.Application.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly IFinancialTransactionService _financialTransactionService;

        public FinancialTransactionController(IFinancialTransactionService financialTransactionService)
        {
            _financialTransactionService = financialTransactionService;
        }

        [HttpGet]
        [Route("GetCashflowByDate")]
        public CashflowDTO GetCashflow([FromQuery] DateTime date)
        {
            return _financialTransactionService.GetCashflow(date);
        }

        [HttpGet]
        [Route("GetAllByDate")]
        public IEnumerable<FinancialTransactionDTO> GetAllByDate([FromQuery] DateTime date)
        {
            return _financialTransactionService.GetAllByDate(date.Date);
        }

        [HttpPost]
        public async Task<ValidationResult> Post([FromBody] FinancialTransactionDTO dto)
        {
            return await _financialTransactionService.Add(dto);
        }
    }
}
