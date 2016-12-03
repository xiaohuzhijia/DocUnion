using  System;

namespace DocUnion.Services.SQLite
{
    public class UserDb
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Sex { get; set; }
        public int TelNumber { get; set; }
        public string Hospital { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public int YearsOfMedicalWork { get; set; }
        public string AreasOfExpertise { get; set; }
        public string FieldsOfInterest { get; set; }
        public string Password { get; set; }
        public string HeadImage { get; set; }
        public string MaxCard { get; set; }
        public string Email { get; set; }

        public UserDb()
        {

        }

    }
}