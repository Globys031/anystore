using AnyStore.BLL;
using AnyStore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is a fake repository we'll be using for unit tests.
namespace AnyStore.TDD
{
    public class InMemoryDeaCustRepository : IDeaCustRepository
    {
        public bool Delete(DeaCustBLL dc)
        {
            throw new NotImplementedException();
        }

        public DeaCustBLL GetDeaCustIDFromName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DeaCustBLL dc)
        {
            if (dc.type != "" && dc.name != "" && dc.email != "" && dc.contact != "" && dc.address != "" && dc.added_date != null && dc.added_by != 0)
            {
                return true; // success
            }
            return false; // failure
        }

        public DataTable Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public DeaCustBLL SearchDealerCustomerForTransaction(string keyword)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            return new DataTable();
        }

        public bool Update(DeaCustBLL dc)
        {
            throw new NotImplementedException();
        }
    }
}
