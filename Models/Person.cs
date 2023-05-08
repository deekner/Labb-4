using System.ComponentModel.DataAnnotations;

namespace Labb_4.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }


    }
}
