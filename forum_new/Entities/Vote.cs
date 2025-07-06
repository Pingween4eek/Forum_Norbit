using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Xml.Linq;

namespace forum_new.Entities
{
    public class Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int VoteType { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.Now;
        
    }

    public class VoteDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int VoteType { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.Now;
    }
}
