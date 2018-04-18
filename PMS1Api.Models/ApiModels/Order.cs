using System;
using System.ComponentModel.DataAnnotations;

namespace PMS1Api.Models.ApiModels
{
    public class OrderCreateRequest
    {
        [Required]
        public int DrugId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public Guid Userid { get; set; }      // TODO
        
        public DateTimeOffset? OrderDate { get; set; }
    }

    public class OrderUpdateRequest
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int DrugId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public Guid Userid { get; set; }      // TODO
        
        public DateTimeOffset? OrderDate { get; set; }
    }

    public class OrderGetResponse
    {
        public int OrderId { get; set; }
        public int DrugId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //public Guid Userid { get; set; }      // TODO
        public DateTimeOffset? OrderDate { get; set; }
    }
}
