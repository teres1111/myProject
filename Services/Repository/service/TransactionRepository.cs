using Entity.Context;
using Entity.DTO.CommonDto;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Services.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services.Repository.service
{
    public class TransactionRepository : IRepostoryAddMetod
    {
        private readonly EntityConnect _context;
        public TransactionRepository(EntityConnect context)
        {
            _context = context;
        }

       

        public async Task<transaction> GetById(int id)
        {

            return await _context.Transactions.FindAsync(id);
        }

        public async Task<List<transaction>> GetByType(IncomeExpen Type)
        {
            if (Type == IncomeExpen.all)
            {
                return _context.Transactions.ToList();
            }

            return await _context.Transactions
                .Where(t=>t.type == Type.ToString()).ToListAsync();
        }


        public async Task AddAsync(transaction model)
        {
            await _context.Transactions.AddAsync(model);
            await SaveChange();
        }

        public async Task DeleteAsync(int id)
        {
            var models = await GetById(id);
            if (models != null)

            {
                _context.Transactions.Remove(models);

                await SaveChange();
            }
            else
            {
                throw new ArgumentException("Income not found");
            }
        }


        public async Task UpdateAsync(transaction model)
        {
            var models = await GetById(model.Id);
            if (models != null)

            {
                _context.Transactions.Update(model);

                await SaveChange();
            }
            else
            {
                throw new ArgumentException("Income not found");
            }
        }
        

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<TransactionDTO>> GetTransactionsByMonth(int month, int year) // ежемесячная статистика доходов и расходов
        {
            var model = await _context.Transactions.Where(x => x.Date.Month == month && x.Date.Year == year).ToListAsync();

            return model.Select(x=> new TransactionDTO
            {
                Date = x.Date,
                Transaktion_Type = x.type.ToString(), // Предполагается, что Type - это enum
                Class = x.Category,
                Summa = x.Amount,
                message = x.Comment
            }).ToList();

            
        }



        public Task<List<transaction>> GetAll() // вместо данного метода Get All используется метод GetByType
        {
            throw new NotImplementedException();
        }

       
    }
}
