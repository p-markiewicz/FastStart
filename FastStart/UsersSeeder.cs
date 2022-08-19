using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastStart.Entities;

namespace FastStart.Migrations
{
    public class UsersSeeder
    {
        private readonly UsersDbContext _dbContext;

        public UsersSeeder(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Users> GetUsers()
        {
            var users = new List<Users>()
            {
                new Users()
                {
                    Imie = "Piotr",
                    Nazwisko = "Markiewicz",
                    eMail = "markiewiczpiotr85@gmail.com",
                    nrTel = 600100001,
                    nrFBO = 480900107375,
                    Roles = new List<Roles>()
                    { new Roles()
                        {
                            Nazwa = "Admin",
                            nrFBO = 480900107375,
                        },
                    }
                },
                new Users()
                {
                    Imie = "Aneta",
                    Nazwisko = "Markiewicz",
                    eMail = "anetaszmagla@gmail.com",
                    nrTel = 600100002,
                    nrFBO = 480900093437,
                    Roles = new List<Roles>()
                    { new Roles()
                        {
                            Nazwa = "Manager",
                            nrFBO = 480900093437,
                        },
                    }
                },
                new Users()
                {
                    Imie = "Anna",
                    Nazwisko = "Golebicka",
                    eMail = "a.golebicka@gmail.com",
                    nrTel = 600100003,
                    nrFBO = 480900093433,
                    Roles = new List<Roles>()
                    { new Roles()
                        {
                            Nazwa = "User",
                            nrFBO = 480900093433,
                        },
                    }
                },
            };
            return users;
        }
    }
}