namespace Freepress_Api.Model
{
    public class newsmodel
    {
        public int Id { get; set; } 
        public string title { get; set; }
        public string description { get; set; }
        public DateTime Date_of_posting { get; set; }
        public Author? Author { get; set; }
    }
}
