﻿namespace NashBridge.Model
{
    public class RegisterRequestDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeId { get; set; }
        public string[] Skills { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
