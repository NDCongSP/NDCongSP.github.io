using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class AccountModel
    {
        private OnlineShopDbContext db;

        public AccountModel()
        {
            db = new OnlineShopDbContext();
        }
        public bool Login(string userName, string password)
        {
            var result = db.Accounts.Count(x => x.userName == userName && x.password == password);
            if (result > 0)
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
