using System.ComponentModel.DataAnnotations.Schema;

namespace JamesTranproject.Models
{
    public class imgNew
    {
        [NotMapped]
        public IFormFile? imageNew { get; set; }
    }
}
