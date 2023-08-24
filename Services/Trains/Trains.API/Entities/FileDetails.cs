using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trains.API.Entities
{
    [Table("FileDetails")]
    public class FileDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string FileName { set; get; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FileType { set; get; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] FileData { set; get; }
    }
}
