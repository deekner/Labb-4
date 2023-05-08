using System.ComponentModel.DataAnnotations;

namespace Labb_4.Models
{
    public class Hobby
    {
        [Key]
        public int ID { get; set; }
        public string HobbyName { get; set; }
        public string Description { get; set; }

    }
}
