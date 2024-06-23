using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(12)]
        public string UserPhone { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserPoint { get; set; }
        public int UserRole { get; set; }
    }
}
