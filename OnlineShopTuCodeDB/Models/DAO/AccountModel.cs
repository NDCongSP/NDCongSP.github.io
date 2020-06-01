using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModel
    {
        public AccountModel()
        {
            
        }
        public bool Login(string userName, string password)
        {
            object result = DataProvider.Instance.ExecuteScalar("spAccountLogin @userName , @password", new object[] { userName,password});
            if (result != null && (int)result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
