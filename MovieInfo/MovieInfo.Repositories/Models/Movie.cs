using System;
using System.Collections.Generic;
using System.Text;

namespace MovieInfo.Repositories.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
        public string Synopsis { get; set; }
    }
}
