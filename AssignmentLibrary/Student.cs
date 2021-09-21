using System;

namespace AssignmentLibrary
{
    public class Student
    {
        private int id {get; init;}
        private string GivenName {get; set;}
        private string Surname {get; set;}
        private Stats status {get => getStatus();}
        public  DateTime startDate {get; set;}
        private DateTime endDate {get; set;}
        private DateTime graduationDate {get; set;}

        public Student (int id, string GivenName, string Surname, DateTime startDate, DateTime endDate, DateTime graduationDate) {
            this.id = id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.startDate = startDate;
            this.endDate = endDate;
            this.graduationDate = graduationDate;
        }


        public Stats getStatus() {
            if (DateTime.Compare(endDate, graduationDate) < 0) 
            {
                return Stats.Dropout; 
            }
            else if (DateTime.Compare(graduationDate, DateTime.Now) < 0) 
            {
                return Stats.Graduated;
            }
            else if (DateTime.Compare(startDate, DateTime.Now) > 0 ) 
            {
                return Stats.New;
            }
            else 
            {
                return Stats.Active;
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1} {2}, Status: {3}, StartDate: {4}, EndDate: {5}, GraduationDate: {6}", id, GivenName,Surname,status,startDate.ToString("MM/dd/yyyy HH:mm:ss"),endDate.ToString("MM/dd/yyyy HH:mm:ss"),graduationDate.ToString("MM/dd/yyyy HH:mm:ss"));
        }
    }

    public record ImmutableStudent {
        public int id {get; init;}
        public string GivenName {get; init;}
        public string Surname {get; init;}
        public Stats status {get => getStatus();}
        public  DateTime StartDate {get; init;}
        public DateTime endDate {get; init;}
        public DateTime graduationDate {get; init;}


        public ImmutableStudent (int id, string GivenName, string Surname, DateTime startDate, DateTime endDate, DateTime graduationDate) {
            this.id = id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.StartDate = startDate;
            this.endDate = endDate;
            this.graduationDate = graduationDate;
        }

        public Stats getStatus() {
            if (DateTime.Compare(endDate, graduationDate) < 0) 
            {
                return Stats.Dropout; 
            }
            else if (DateTime.Compare(graduationDate, DateTime.Now) < 0) 
            {
                return Stats.Graduated;
            }
            else if (DateTime.Compare(StartDate, DateTime.Now) > 0 ) 
            {
                return Stats.New;
            }
            else 
            {
                return Stats.Active;
            }
        }
    }

    
    
    public enum Stats 
    {
        New, Active, Dropout, Graduated
    }
}
