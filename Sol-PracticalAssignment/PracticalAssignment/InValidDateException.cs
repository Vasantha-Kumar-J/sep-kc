namespace PracticalAssignment
{
    public class InValidDateException : Exception
    {
        public InValidDateException(Exception error) : base("Date formate was Invalid.", error) 
        { }
    }
}