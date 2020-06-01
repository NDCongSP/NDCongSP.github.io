namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        [StringLength(50)]
        public string alias { get; set; }

        public int? parentId { get; set; }

        public DateTime? createdDate { get; set; }

        public bool? status { get; set; }
    }
}
