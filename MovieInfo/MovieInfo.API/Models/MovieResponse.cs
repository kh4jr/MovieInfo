namespace MovieInfo.API.Models
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
        public string Synopsis { get; set; }
    }
}
