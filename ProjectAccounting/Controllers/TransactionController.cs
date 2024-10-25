using Entity.DTO.CommonDto;
using Entity.DTO.CreateDTO;
using Entity.DTO.Get;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Services.Repository.IRepositories;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;




namespace ProjectAccounting.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly IRepostoryAddMetod _repostory;

        public TransactionController(IRepostoryAddMetod repostory)
        {
            _repostory = repostory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdTransaktion(int id)
        {
            var model = await _repostory.GetById(id);
            if (model is null)
            {
                return BadRequest("по данному ид нет никаких данных");
            }

            var modelDTO = new TransactionDTO
            {
                Tranzaktion_Id = model.Id,
                Date = model.Date,
                Transaktion_Type = model.type,
                Class = model.Category,
                Summa = model.Amount,
                message = model.Comment
            };
            return Ok(modelDTO);
        }

        [HttpGet("bytype/{type}")]
        public async Task<ActionResult> GetTypeTransaktion(IncomeExpen type)
        {
            var model = await _repostory.GetByType(type);

            if (model is null)
            {
                return BadRequest("not information");
            }

            var modelDTO = model.Select(t => new TransactionDTO
            {
                Tranzaktion_Id = t.Id,
                Date = t.Date,
                Transaktion_Type = t.type,
                Class = t.Category,
                Summa = t.Amount,
                message = t.Comment
            }).ToList();
            return Ok(modelDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaktion([FromBody] CreateTransaction transactionDTO,[FromQuery] IncomeExpen TypeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (TypeModel == IncomeExpen.income || TypeModel == IncomeExpen.outcome)
            {
                var model = new transaction
                {
                    type = TypeModel == IncomeExpen.income ? IncomeExpen.income.ToString() : IncomeExpen.outcome.ToString(),
                    Category = transactionDTO.Class,
                    Date = transactionDTO.Date,
                    Amount = transactionDTO.Summa,
                    Comment = transactionDTO.message
                };
                await _repostory.AddAsync(model);


                var TransaktionResponseDTO = new TransactionDTO
                {
                    Tranzaktion_Id = model.Id,
                    Date = model.Date,
                    Transaktion_Type = model.type,
                    Class = model.Category,
                    Summa = model.Amount,
                    message = model.Comment

                };


                return CreatedAtAction(nameof(GetByIdTransaktion), new { id = model.Id }, TransaktionResponseDTO);
            }
            else
            {
                return BadRequest("пожалуста выберете или доход/расход == income/outcome");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransaktion(int id, [FromBody] CreateTransaction transactionDTO, IncomeExpen TypeModel)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (TypeModel == IncomeExpen.income || TypeModel == IncomeExpen.outcome)
            {
                var model = await _repostory.GetById(id);
                if (model is null)
                    return NotFound($"По данному ID {id} нет информации");

                model.type = TypeModel == IncomeExpen.income ? IncomeExpen.income.ToString() : IncomeExpen.outcome.ToString();
                model.Category = transactionDTO.Class;
                model.Date = transactionDTO.Date;
                model.Amount = transactionDTO.Summa;
                model.Comment = transactionDTO.message;


                await _repostory.UpdateAsync(model);



                var updatedTransactionResponse = new TransactionDTO
                {
                    Tranzaktion_Id = model.Id,
                    Date = model.Date,
                    Transaktion_Type = model.type,
                    Class = model.Category,
                    Summa = model.Amount,
                    message = model.Comment
                };


                return Ok(updatedTransactionResponse);
            }
            else
            {
                return BadRequest("пожалуста выберете или доход/расход == income/outcome ");
            }
               
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaktion (int id)
        {
            try
            {
                await _repostory.DeleteAsync(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }





        [HttpGet("transactions/{month}/{year}")]
        public async Task<ActionResult<List<TransactionDTO>>> GetTransactionsByMonth(int month, int year) // анализ
        {
            var transactions = await _repostory.GetTransactionsByMonth(month, year);
        if (transactions == null || !transactions.Any())
            {
                return NotFound("по этим данным не было транзакций");
            }
            return Ok(transactions);
        }
    }


 









}
