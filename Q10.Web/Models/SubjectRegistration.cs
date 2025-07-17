namespace Q10.Web.Models
{
    public class SubjectRegistration
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int StudentId { get; set; }
    }
}
