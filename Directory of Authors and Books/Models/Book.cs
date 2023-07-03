namespace Directory_of_Authors_and_Books.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int YearOfIssue { get; set; }
    }
}
