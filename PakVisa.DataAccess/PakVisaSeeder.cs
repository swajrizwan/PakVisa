using PakVisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.DataAccess
{
    public class PakVisaSeeder
    {
        private PakVisaDbContext _context;

        public PakVisaSeeder(PakVisaDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            var admin = _context.Userlogins
                .FirstOrDefault(p => p.Username == "swajrizwan" && p.Password == "Zoloyolo123" && p.IsUserAdmin == true);
            if (admin == null)
            {
                var user = new Userlogin()
                {
                    Name = "Swaj Rizwan",
                    Username = "swajrizwan",
                    Password = "Zoloyolo123",
                    IsUserAdmin = true,
                    IsUserClient = false,
                    IsUserVisitor = false
                };
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }

        }
    }
}
