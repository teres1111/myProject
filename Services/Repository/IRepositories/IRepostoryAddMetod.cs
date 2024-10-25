using Entity.DTO.CommonDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services.Repository.IRepositories
{
    public interface IRepostoryAddMetod: IRepository<transaction>
    {
        Task<List<transaction>> GetByType(IncomeExpen type);
        Task<List<TransactionDTO>> GetTransactionsByMonth(int month, int year);
    }
}
