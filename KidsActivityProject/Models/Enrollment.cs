namespace MiniProjectWebService.Models
{
    public enum SubDue { yes, no }
    public class Enrollment
    {
        //auto properties
        public int EnrollmentId { get; set; }
        public int ChildId { get; set; }
        public int ActivityId { get; set; }
        public SubDue PaymentDue { get; set; }


        //Navigation properties
        //An enrollment has 1 child and 1 activity
        public virtual Activity Activity { get; set; }
        public virtual Child Child { get; set; }
    }
}