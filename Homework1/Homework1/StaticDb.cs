using Homework1.Models;

namespace Homework1
{
    public static class StaticDb
    {
        public static List<User> Usernames = new List<User>()
        {
            new User
            {   Id = 1,
                Name = "User1"

            },
            new User
            {
                Id = 2,
                Name = "User2"
            },
            new User
            {
                Id = 3,
                Name = "User3"
            }

        };
    }
}
