using FluentValidation.TestHelper;
using Q10.Domain.Entities;
using Q10.Domain.Validator;

namespace Test.Subjects
{
    public class SubjectValidatorTests
    {
        private readonly SubjectValidator _validator = new SubjectValidator();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var subject = new Subject { Name = "", Code = "MAT01", Credit = 3 };
            var result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("El nombre es obligatorio");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Too_Long()
        {
            var subject = new Subject { Name = new string('A', 101), Code = "MAT01", Credit = 3 };
            var result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("El nombre no puede superar los 100 caracteres");
        }

        [Fact]
        public void Should_Have_Error_When_Code_Is_Empty()
        {
            var subject = new Subject { Name = "Matemáticas", Code = "", Credit = 3 };
            var result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.Code)
                .WithErrorMessage("El código es obligatorio");
        }

        [Fact]
        public void Should_Have_Error_When_Code_Too_Long()
        {
            var subject = new Subject { Name = "Matemáticas", Code = new string('B', 16), Credit = 3 };
            var result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.Code)
                .WithErrorMessage("El código no puede superar los 15 caracteres");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(11)]
        public void Should_Have_Error_When_Credit_Out_Of_Range(int credit)
        {
            var subject = new Subject { Name = "Matemáticas", Code = "MAT01", Credit = credit };
            var result = _validator.TestValidate(subject);
            result.ShouldHaveValidationErrorFor(x => x.Credit)
                .WithErrorMessage("El crédito debe estar entre 1 y 10");
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var subject = new Subject { Name = "Matemáticas", Code = "MAT01", Credit = 4 };
            var result = _validator.TestValidate(subject);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
