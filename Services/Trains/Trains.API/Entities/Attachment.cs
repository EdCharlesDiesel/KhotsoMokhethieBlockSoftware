using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trains.API.Entities
{
    public class Attachment
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FileName { set; get; }
        [Column(TypeName = "nvarchar(50)")]
        public string Description { set; get; }
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] attachment { set; get; }
    }
}
