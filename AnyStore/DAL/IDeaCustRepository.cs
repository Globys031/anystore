using AnyStore.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStore.DAL
{
    //public interface IDeaCustRepository : IDisposable
    public interface IDeaCustRepository
    {
        DataTable Select();
        bool Insert(DeaCustBLL dc);
        bool Update(DeaCustBLL dc);
        bool Delete(DeaCustBLL dc);
        DataTable Search(string keyword);
        DeaCustBLL SearchDealerCustomerForTransaction(string keyword);
        DeaCustBLL GetDeaCustIDFromName(string Name);
    }
}
