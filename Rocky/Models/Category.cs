using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng không bỏ trống name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng không bỏ trống DisplayOrder"),Range(1, int.MaxValue, ErrorMessage = "Nhập số lớn hơn 0!")]
        public int? DisplayOrder { get; set; }

    }
}
