namespace UniversityManagementSystem
{
    public class Course
    {
        int courseID;
        string courseName;
        string creditHour;
        string dateOfCreation;
        string Date;
        string time;
        int departmentID;

        public Course(int courseID, string courseName, string creditHour, string dateOfCreation, string date, string time, int departmentID)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            this.creditHour = creditHour;
            this.dateOfCreation = dateOfCreation;
            Date1 = date;
            this.Time = time;
            this.departmentID = departmentID;
        }

        public int CourseID
        {
            get
            {
                return courseID;
            }

            set
            {
                courseID = value;
            }
        }

        public string CourseName
        {
            get
            {
                return courseName;
            }

            set
            {
                courseName = value;
            }
        }

        public string CreditHour
        {
            get
            {
                return creditHour;
            }

            set
            {
                creditHour = value;
            }
        }

        public string DateOfCreation
        {
            get
            {
                return dateOfCreation;
            }

            set
            {
                dateOfCreation = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return departmentID;
            }

            set
            {
                departmentID = value;
            }
        }

        public string Date1
        {
            get
            {
                return Date;
            }

            set
            {
                Date = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }
    }
}