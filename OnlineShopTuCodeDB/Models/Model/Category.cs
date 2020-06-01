using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Category
    {
        public int Id { set; get; }
       
        [DisplayName("Tên danh mục:")]//hien thi ten ngoai giao dien label
        [Required(ErrorMessage ="Ban chua nhap ten danh muc")]//bat buoc
        public string name { set; get; }

        [DisplayName("Tieu de SEO:")]
        public string alias { set; get; }

        [DisplayName("Thu muc cha")]
        [Range(0,Int32.MaxValue,ErrorMessage ="chi duoc nhap so")]
        public int? parentId { set; get; }

        [DisplayName("Ngay tao:")]
        public DateTime? createdDate { set; get; }

        [DisplayName("Trang thai:")]
        public bool? status { set; get; }
    }
}
