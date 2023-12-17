
namespace blogCSharp.Models
{
    public class Post : Entity
    {
        public string Title { get; set; }

        public string Resume { get; set; }

        public string Content { get; set; }

        public DateTime DatePost { get; set; }

        public byte[] Image { get; set; }

        public Post(Guid id, string title, string resume, string content, byte[] image) : base(id)
        {
            Title = title;
            Resume = resume;
            Content = content;
            Image = image;
            DatePost = DateTime.Now;
        }
    }
}
