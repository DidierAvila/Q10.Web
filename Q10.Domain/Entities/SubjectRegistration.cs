using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q10.Domain.Entities
{
    [Table(name: "Subject_registration")]
    public class SubjectRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column(name: "SubjectId", TypeName = "int")]
        public int SubjectId { get; set; }

        [Column(name: "StudentId", TypeName = "int")]
        public int StudentId { get; set; }
    }
}
