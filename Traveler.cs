using Buss.Enums;

namespace Buss
{
    public class Traveler
    {
        int travelerId = 0;
        private int _id;
        public Traveler(string firstName, string lastName )
        {
            FirstName = firstName;
            LastName=lastName;
           
            travelerId += 1;
            
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get;private set; }
        public string Password { get;private set; }
        public Gender Gender { get; set; }
        public Gender SetGender(int gender)
        {
            if (gender == 1)
            {
                Gender = Gender.male;
            }
            if (gender == 2)
            {
                Gender = Gender.female;
            }

            return Gender;
        }
        public void SetUserName(string userName)
        {
            if (userName.Length < 4)
            {
                throw new Exception("It cannot be less than 4 characters");
            }
            UserName = userName;
        }
        public void SetPassword(string password)
        {
            if (password.Length < 4)
            {
                throw new Exception("It cannot be less than 4 characters");
            }
            Password = password;
        }
    }
    public class InfoTraveler
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }


}
