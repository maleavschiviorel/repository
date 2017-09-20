using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dto
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        
        public long Price { get; set; }

        public string Description { get; set; }
        public long Ranking { get; set; }
    }
}