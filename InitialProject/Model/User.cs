using InitialProject.Enumerations;
using InitialProject.Serializer;
using System;
using System.IO.Packaging;

namespace InitialProject.Model
{
    public class User : ISerializable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }

        public User() { }

        public User(string firstName, string lastName, string username, string password, UserType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Type = type;
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), FirstName, LastName, Username, Password, Type.ToString() };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            /*FirstName = values[1];
            LastName = values[2];*/
            Username = values[1];
            Password = values[2];
            //type
        }
    }
}
