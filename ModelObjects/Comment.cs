namespace APIRestful.Objetos
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Text { get; set; }
        public int BlogPostId { get; set; }


        public Comment() { }

        public Comment(string username, string text)
        {
            Username = username;
            Text = text;
        }
    }
}