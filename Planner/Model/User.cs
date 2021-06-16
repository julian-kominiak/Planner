using System;

namespace Planner.Model
{
    public class User
    {
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }

        private bool Equals(User other)
        {
            return Login == other.Login && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Login, Password);
        }
    }
}