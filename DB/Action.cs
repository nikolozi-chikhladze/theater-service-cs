namespace DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Action")]
    public partial class Action
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string spectacle_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string hall_name { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int seats_count { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string booked_seats { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string available_seats { get; set; }
    }
}
