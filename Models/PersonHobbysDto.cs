namespace Labb_4.Models
{
    public class PersonHobbysDto
    {
        //Added PersonHobbyDto to connect person with Hobby
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public Hobby hobbys { get; set; }
    }
}
