using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Xml.Linq;

namespace forum_new.Entities
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int AuthorId { get; set; }
        public int Rating { get; set; }
        public int SubforumId { get; set; }
    }

    public class PostDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int AuthorId { get; set; }
        public int Rating { get; set; }
        public int SubforumId { get; set; }
    }
}
