namespace KidsActivityProject.Models
{
    public enum SubDue { yes, no }
    public class Enrollment
    {
        //auto properties
        public int EnrollmentID { get; set; }
        public int KidID { get; set; }
        public int ActivityID { get; set; }
        public SubDue PaymentDue { get; set; }


        //Navigation properties
        //An enrollment has 1 child and 1 activity
        public virtual Activity Activity { get; set; }
        public virtual Kid Kid { get; set; }
    }
}