using Q10.Domain.Dtos;

namespace Q10.Web.Models
{
    public class SubjectRegistrationIndexViewModel
    {
        public IEnumerable<SubjectRegistrationDto>? SubjectRegistrations { get; set; }
        public IEnumerable<Student>? Students { get; set; }
    }
} 