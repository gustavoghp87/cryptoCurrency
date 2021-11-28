using CryptoCurrency.Controllers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using Services.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Controllers
{
    [ApiController]
    [Route("api/")]
    [EnableCors("MyCors")]
    [Produces("application/json")]
    public class TransactionController : ControllerBase, ITransactionController
    {
        private static ITransactionService _transactionService;
        private static ISignTransactionService _signTransactionService;
        public TransactionController(ITransactionService transactionService, SignTransactionService signTransactionService)
        {
            _transactionService = transactionService;
            _signTransactionService = signTransactionService;
        }

        [HttpGet("transaction")]
        public IActionResult GetAll()
        {
            List<Transaction> lstTransactions = _transactionService.GetAll();
            return Ok(lstTransactions);
        }

        [HttpPost("transaction")]
        public async Task<IActionResult> AddTransaction(Transaction transactionRequest)
        {
            bool response = await _transactionService.Add(transactionRequest);
            if (!response) return BadRequest();
            return Ok(transactionRequest);
        }

        [HttpPost("transaction/signature")]
        public IActionResult Sign(Transaction transactionRequest, string privateKey)
        {
            if (privateKey == null | privateKey == "") return BadRequest();
            _signTransactionService.Initialize(transactionRequest, privateKey);
            transactionRequest.Signature = _signTransactionService.GetSignature();
            return Ok(transactionRequest);
        }
    }
}