namespace Movies.DTOs
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public int year { get; set; }

        public double rate { get; set; }

        public string storeline { get; set; }

        public IFormFile postar { get; set; }

        public byte GenreId { get; set; }
    }
}
