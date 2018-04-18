using System.ComponentModel.DataAnnotations;

namespace PMS1Api.Models.ApiModels
{
    public class DrugCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    public class DrugUpdateRequest
    {
        [Required]
        public int DrugId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    public class DrugGetResponse
    {
        public int DrugId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
