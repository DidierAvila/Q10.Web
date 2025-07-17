namespace Q10.Domain.Dtos
{
    public class SubjectRegistrationDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int Credit { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
