namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int year { get; set; }

        public double rate { get; set; }
        
        public string storeline { get; set; }

        public byte[] postar { get; set; }

        public byte GenreId { get; set; }

        public Genre genre  { get; set;}
    }
}
