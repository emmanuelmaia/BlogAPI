namespace APIRestful.Objetos
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? Title {  get; set; }
        public string? Content { get; set; }
        public string? Author { get;set; }
        public bool IsUnlisted { get; set; }
        public List<Comment> Comments { get; set; } = new();

        public BlogPost() { }

        public BlogPost(string title)
        {
            Title = title;
        }

        public BlogPost(string title, string content) 
        {
            Title = title;
            Content = content;
        }
    }
}
