using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {
        OnlineShopDbContext db;
        public CategoryModel()
        {
            db = new OnlineShopDbContext();
        }

        public List<Category> ListAll(bool status)
        {
            //tao bien object de truyen doi so vao stored procedure
            var sqlParas = new SqlParameter[]
            {
                new SqlParameter("@status",status)
            };
            var result = db.Database.SqlQuery<Category>("spCategoryWhere @status",sqlParas).ToList();
            return result;
        }

        public Category GetbyStatus(bool status)
        {
            return db.Categories.FirstOrDefault(x => x.status == status);
            
        }
    }
}
