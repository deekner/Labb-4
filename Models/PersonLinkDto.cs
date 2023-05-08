namespace Labb_4.Models
{
    public class PersonLinkDto
    {
        //Added PersonLinkDto to connect person with Links
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public Link links { get; set; }
    }
}
