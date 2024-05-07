namespace NashBridge.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string Tagline { get; set; }
        public int Rating { get; set; }
        //public List<string> Skills { get; set; }
        public string Photo { get; set; }
    }
}
