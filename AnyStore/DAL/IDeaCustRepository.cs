using AnyStore.BLL;
using System.Data;
using System.Data.SqlClient;


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
