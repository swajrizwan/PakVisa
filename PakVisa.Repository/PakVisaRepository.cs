using Microsoft.EntityFrameworkCore;
using PakVisa.DataAccess;
using PakVisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakVisa.Repository
{
    public class PakVisaRepository : IPakVisaRepository
    {
        private readonly PakVisaDbContext _context;

        public PakVisaRepository(PakVisaDbContext context)
        {
            _context = context;
        }

        #region Generic Methods
        public async Task Add(object Entity)
        {
            await _context.AddAsync(Entity);
        }
        public void Update(object Entity)
        {
            _context.Update(Entity);
        }

        public void Remove(object Entity)
        {
            _context.Remove(Entity);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion

        #region User
        public List<Userlogin> AllAdmins()
        {
            return _context.Userlogins.Where(p => p.IsUserAdmin == true).ToList();
        }
        public List<Userlogin> AllClients()
        {
            return _context.Userlogins.Where(p => p.IsUserClient == true).ToList();
        }
        public List<Userlogin> AllVisitors()
        {
            return _context.Userlogins.Where(p => p.IsUserVisitor == true).ToList();
        }

        public Userlogin AdminSignIn(string Username, string Password)
        {
            return _context.Userlogins.FirstOrDefault(p => p.Username == Username && p.Password == Password && p.IsUserAdmin == true);
        }

        public Userlogin ClientSignIn(string Username, string Password)
        {
            return _context.Userlogins.FirstOrDefault(p => p.Username == Username && p.Password == Password && p.IsUserClient == true);
        }
        #endregion

        #region Franchises
        public List<Franchise> GetAllFranchises()
        {
            return _context.Franchises.ToList();
        }
        #endregion

        #region LookUps
        public List<Country> GetCountries()
        {
            return _context.Countries.OrderBy(p=>p.Description).ToList();
        }
        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(p => p.CountryId == id);
        }
        public List<City> GetCities()
        {
            return _context.Cities.OrderBy(p => p.Country.Description).ToList();
        }
        public City GetCityById(int id)
        {
            return _context.Cities.FirstOrDefault(p => p.CityId == id);
        }
        public List<City> GetCityByCountryId(int id)
        {
            return _context.Cities.Where(p => p.CountryId == id).ToList();
        }
        public List<VisaType> GetVisaTypes()
        {
            return _context.VisaTypes.OrderBy(p => p.Description).ToList();
        }
        #endregion

    }
}
