using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Api.Infrastructure.Models
{
    public class ProductParam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(CategoryParam))]
        [Required]
        public int CategoryParamId { get; set; }
        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }
        public string Value { get; set; }

        public virtual CategoryParam CategoryParam { get; set; }
        public virtual Product Product { get; set; }
    }
}
