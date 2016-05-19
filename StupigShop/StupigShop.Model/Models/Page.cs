using StupigShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupigShop.Model.Models
{
    [Table("Pages")]
    public class Page:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        public string Alias { set; get; }
        public string Content { get; set; }
     }
}
