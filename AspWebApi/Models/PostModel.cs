
using System.ComponentModel.DataAnnotations;

namespace AspWebApi.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Enter Description")]
        public string Descriptions { get; set; } 
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
