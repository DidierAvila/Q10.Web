using Q10.Domain.Entities;

namespace Test.Students
{
    public class StudentValidator
    {
        public bool Validate(Student student, out List<string> errors)
        {
            errors = new List<string>();
            if (string.IsNullOrWhiteSpace(student.Name))
                errors.Add("El nombre es obligatorio");
            if (string.IsNullOrWhiteSpace(student.Document))
                errors.Add("El documento es obligatorio");
            if (string.IsNullOrWhiteSpace(student.Email))
                errors.Add("El Email es obligatorio");
            return errors.Count == 0;
        }
    }

    public class StudentValidatorTests
    {
        [Fact]
        public void Validate_ReturnsTrue_WhenAllFieldsAreValid()
        {
            var student = new Student { Name = "Juan", Document = "12345", Email = "juan@email.com" };
            var validator = new StudentValidator();
            var result = validator.Validate(student, out var errors);
            Assert.True(result);
            Assert.Empty(errors);
        }

        [Fact]
        public void Validate_ReturnsFalse_WhenNameIsMissing()
        {
            var student = new Student { Name = "", Document = "12345", Email = "juan@email.com" };
            var validator = new StudentValidator();
            var result = validator.Validate(student, out var errors);
            Assert.False(result);
            Assert.Contains("El nombre es obligatorio", errors);
        }

        [Fact]
        public void Validate_ReturnsFalse_WhenDocumentIsMissing()
        {
            var student = new Student { Name = "Juan", Document = null, Email = "juan@email.com" };
            var validator = new StudentValidator();
            var result = validator.Validate(student, out var errors);
            Assert.False(result);
            Assert.Contains("El documento es obligatorio", errors);
        }

        [Fact]
        public void Validate_ReturnsFalse_WhenEmailIsMissing()
        {
            var student = new Student { Name = "Juan", Document = "12345", Email = "" };
            var validator = new StudentValidator();
            var result = validator.Validate(student, out var errors);
            Assert.False(result);
            Assert.Contains("El Email es obligatorio", errors);
        }

        [Fact]
        public void Validate_ReturnsFalse_WhenMultipleFieldsAreMissing()
        {
            var student = new Student { Name = null, Document = null, Email = null };
            var validator = new StudentValidator();
            var result = validator.Validate(student, out var errors);
            Assert.False(result);
            Assert.Contains("El nombre es obligatorio", errors);
            Assert.Contains("El documento es obligatorio", errors);
            Assert.Contains("El Email es obligatorio", errors);
            Assert.Equal(3, errors.Count);
        }
    }
}
