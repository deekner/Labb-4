using System.ComponentModel.DataAnnotations;

namespace Labb_4.Models
{
    public class Link
    {
        [Key]
        public int ID { get; set; }
        public string LinkName { get; set; }
        public string URL { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int HobbyID { get; set; }
        public Hobby Hobby { get; set; }
    }
}
