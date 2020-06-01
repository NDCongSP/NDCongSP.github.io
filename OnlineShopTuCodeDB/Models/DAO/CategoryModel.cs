using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {

        public List<Category> GetListAll()
        {
            List<Category> res = new List<Category>();

            var data = DataProvider.Instance.ExecuteQuery("sp_Category_ListAll");
            if (data.Rows.Count>0)
            {
                Category c;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    c = new Category();
                    c.Id = (int)data.Rows[i][0];
                    c.name = (string)data.Rows[i][1];
                    c.createdDate = (DateTime)data.Rows[i][4];
                    c.status = (bool)data.Rows[i][5
                        ];
                    res.Add(c);
                }
            }
            return res;
        }
        public List<Category> GetListAllWhere(bool where)
        {
            List<Category> res = new List<Category>();
            var data = DataProvider.Instance.ExecuteQuery("spCategoryWhere @status", new object[] { where });
            if (data.Rows.Count > 0)
            {
                Category addData;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    addData = new Category();
                    addData.Id = (int)data.Rows[i][0];
                    addData.name = (string)data.Rows[i][1];
                    //addData.alias = (string)data.Rows[i][2];
                    //Int32.TryParse(data.Rows[i][3].ToString(),out addData.parentId);
                    addData.createdDate = (DateTime)data.Rows[i][4];
                    addData.status = (bool)data.Rows[i][5];

                    res.Add(addData);
                }
            }
            return res;
        }

        public int InsertDataCategory(string column,string value)
        {
            return DataProvider.Instance.ExecuteNonQuery($"Insert into Category ({column}) values ({value})");
        }
    }
}
