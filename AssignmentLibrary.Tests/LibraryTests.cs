using System;
using Xunit;

namespace AssignmentLibrary.Tests
{
    public class StudentTests
    {
        [Fact]
        public void StudentStatusSomething()
        {
            Student st = new Student(01, "Gustav","Müller", DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(3), DateTime.Now.AddMonths(2));
            Assert.Equal(Stats.Active, st.getStatus());
        }

        [Fact]
        public void CompareTwoImmutableStudents()
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
            Assert.Equal("ImmutableStudent { id = 1, GivenName = Gustav, Surname = Müller, status = Active, StartDate = 01/01/0001 00:00:00, endDate = 31/12/9999 23:59:59, graduationDate = 31/12/9999 23:59:59 }", st.ToString());
            
        }
    }
}
