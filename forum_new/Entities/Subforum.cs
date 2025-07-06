using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Xml.Linq;

namespace forum_new.Entities
{
    public class Subforum
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }

    public class SubforumDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
