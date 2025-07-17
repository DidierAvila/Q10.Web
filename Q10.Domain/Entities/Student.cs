using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q10.Domain.Entities
{
    [Table(name: "Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "Varchar (100)")]
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public required string Name { get; set; }

        [Column(name: "Document", TypeName = "Varchar (20)")]
        [Required(ErrorMessage = "El documento es obligatorio")]
        public required string Document { get; set; }

        [Column(name: "Email", TypeName = "Varchar (100)")]
        [Required(ErrorMessage = "El Email es obligatorio")]
        public required string Email { get; set; }
    }
}
