namespace OMDB_API
{
    public class Request
    {
        public string MovieTitle { get; set; }
        public int MovieYear { get; set; }
        public MoviePlot MoviePlot { get; set; }
    }
    public enum MoviePlot { Short, Full}

}

