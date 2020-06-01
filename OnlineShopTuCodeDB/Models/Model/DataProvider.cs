using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DataProvider
    {
        private string connectionStr = @"Data Source=FVN-PC-IT-07\SQLLOCAL;Database=OnlineShop;UID=sa;Password=12345678; Min Pool Size=0;Max Pool Size=1000;Pooling=true; Connect Timeout=65535;";
        private static DataProvider _instance;
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataProvider();
                }
                return _instance;
            }
            private set => _instance = value;
        }
        public DataProvider()
        {

        }
        /// <summary>
        /// Method chạy lệnh sql co trả về bảng dữ liệu.
        /// </summary>
        /// <param name="query">câu truy vấn, có thể là lrrnhj query binh thường hoặc store procedure.</param>
        /// <param name="parameter">Object chứa các giá trị của parametter truyền vào, dùng cho query dùng store procedure, nếu sql bình thường thì để trống properties này.
        /// Lưu ý: khi truyền store procedure thì các para phải cách cách dấu ',' 1 khoảng trắng.
        /// Ex: @abc , @def.</param>
        /// <returns>Trả về bảng dữ liệu kiểu DataTable.</returns>
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            //dùng cú pháp using để nó tạo ra đối tượng này, nếu có đang chạy mà bị lỗi gì thì nó cũng sẽ hủy đối tượng
            //ở đây là đối tượng connection
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                //gan data cho cac parametter
                if (parameter != null)
                {
                    string[] listParametter = query.Split(' ');// tách chuỗi câu query để lấy ra các parametter để truyền dât vào
                    int i = 0;
                    //chạy vòng lặp để lấy ra para truyền data vào
                    //các parametter của Store Procedure bắt đầu bằng '@'
                    foreach (var item in listParametter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
                connection.Dispose();
            }
            return data;
        }

        /// <summary>
        /// Method query ko trả về bảng dữ liệu, chỉ trả về trạng thái thành công hay thất bại.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parametter"></param>
        /// <returns>Khác 0 là thành công, ngược lại thất bại.</returns>
        public int ExecuteNonQuery(string query, object[] parametter = null)
        {
            int res = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parametter != null)
                    {
                        string[] listParametter = query.Split(' ');
                        int i = 0;
                        foreach (var item in listParametter)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parametter[i]);
                                i++;
                            }
                        }
                    }
                    res = command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch { }
            return res;
        }

        /// <summary>
        /// đếm số dòng trong bảng.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parametter"></param>
        /// <returns>tra ve object.</returns>
        public object ExecuteScalar(string query, object[] parametter = null)
        {
            object res = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parametter != null)
                {
                    string[] listParametter = query.Split(' ');
                    int i = 0;
                    foreach (var item in listParametter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parametter[i]);
                            i++;
                        }
                    }
                }
                res = command.ExecuteScalar();
                connection.Close();
                connection.Dispose();
            }
            return res;
        }
    }
}
