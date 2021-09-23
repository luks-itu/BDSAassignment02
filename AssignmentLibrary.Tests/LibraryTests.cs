using System;
using Xunit;

namespace AssignmentLibrary.Tests
{
    public class StudentTests
    {

        //tests for conventional student class

        [Theory]
        //active
        [InlineData(-1,3,2)]
        //dropout
        [InlineData(-2,-1,1)]
        //graduated,funky (end date after graduated)
        [InlineData(-3,-2,-1)]
        //graduated, normal
        [InlineData(-1,2,2)]
        //new
        [InlineData(1,5,5)]
        public void StudentReturnsCorrectStatus(int start, int end, int graduate)
        {
            Student student = new Student(01, "Gustav","Müller", DateTime.Now.AddMonths(start), DateTime.Now.AddMonths(end), DateTime.Now.AddMonths(graduate));
            Stats expected;
            
            if (end < graduate)
            {
                expected = Stats.Dropout;
            }
            else if (graduate < 0)
            {
                expected =  Stats.Graduated;
            }
            else if (start > 0)
            {
                expected = Stats.New;
            }
            else
            {
                expected = Stats.Active;
            }

            Assert.Equal(expected, student.getStatus());
        }

        [Fact]
        public void StudentToStringReturnsOverridenMethod()
        {
            Student student = new Student(01, "Gustav","Müller", DateTime.MinValue, DateTime.MaxValue, DateTime.MaxValue);
            var expected = "Id: 1, Name: Gustav Müller, Status: Active, StartDate: 01/01/0001 00:00:00, EndDate: 12/31/9999 23:59:59, GraduationDate: 12/31/9999 23:59:59";
            Assert.Equal(expected,student.ToString());

        }


        //tests for immutable student record

        [Fact]
        public void ImmutableStudentsWithIdenticalValuesAreEquivalents()
        {
            ImmutableStudent st1 = new ImmutableStudent(01, "Gustav","Müller", DateTime.MinValue, DateTime.MaxValue, DateTime.MaxValue);
            ImmutableStudent st2 = new ImmutableStudent(01, "Gustav","Müller", DateTime.MinValue, DateTime.MaxValue, DateTime.MaxValue);
            var validation = (st1 == st2);
            Assert.True(validation);
        }
        
        [Fact]
        public void TestToString()
        {
            ImmutableStudent st = new ImmutableStudent(01, "Gustav","Müller", DateTime.MinValue, DateTime.MaxValue, DateTime.MaxValue);
            var expected = "ImmutableStudent { id = 1, GivenName = Gustav, Surname = Müller, status = Active, StartDate = 01/01/0001 00:00:00, endDate = 12/31/9999 23:59:59, graduationDate = 12/31/9999 23:59:59 }";
            Assert.Equal(expected, st.ToString());
            
        }
    }
}
