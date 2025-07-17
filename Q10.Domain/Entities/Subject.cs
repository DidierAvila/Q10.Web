using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q10.Domain.Entities
{
    [Table(name: "Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "Id")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "Varchar (100)")]
        public string Name { get; set; }

        [Column(name: "Code", TypeName = "Varchar (15)")]
        public string Code { get; set; }

        [Column(name: "Credit", TypeName = "int")]
        public int Credit { get; set; }
    }
}
