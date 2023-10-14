namespace SRAF
{
    public enum Skills : int
    {
        Design = 1 ,
        Coding,
        Testing,
        Other
    }
    internal record Employee(string name,int workingHours, HashSet<string> skills,int availability);
    
}
