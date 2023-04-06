namespace SimpleWebAPI.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedAt { get; set; }

        public User(
            int id,
            string firstName,
            string lastName,
            DateTime modifiedAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ModifiedAt = modifiedAt;
        }
    }
}