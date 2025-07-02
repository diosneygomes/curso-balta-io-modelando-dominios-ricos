using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValuesObjects;

namespace PaymentContext.Tests.Queries
{
    public class StudentQueriesTests
    {
        private List<Student> _student;

        public StudentQueriesTests()
        {
            _student = new List<Student>();

            for (int i = 0; i < 10; i++) 
            {
                var student = new Student(
                        new Name("Aluno", i.ToString()),
                        new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                        new Email(i.ToString() + "@balta.io"));

                _student.Add(student);
            }
        }


        [Fact]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            
            var student = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.Null(student);
        }

        [Fact]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");

            var student = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.NotNull(student);
        }

    }
}
