namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        [StringLength(50)]
        public string alias { get; set; }

        public int? categoryId { get; set; }

        [StringLength(500)]
        public string images { get; set; }

        public DateTime? createdDate { get; set; }

        public decimal? price { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        public bool? stastus { get; set; }
    }
}
