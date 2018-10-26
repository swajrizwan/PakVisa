using System.Collections.Generic;
using System.Threading.Tasks;
using PakVisa.Models;

namespace PakVisa.Repository
{
    public interface IPakVisaRepository
    {
        Task Add(object Entity);
        Userlogin AdminSignIn(string Username, string Password);
        List<Userlogin> AllAdmins();
        List<Userlogin> AllClients();
        List<Userlogin> AllVisitors();
        Userlogin ClientSignIn(string Username, string Password);
        List<City> GetCities();
        List<City> GetCityByCountryId(int id);
        City GetCityById(int id);
        List<Country> GetCountries();
        Country GetCountryById(int id);
        List<VisaType> GetVisaTypes();
        void Remove(object Entity);
        Task<bool> Save();
        void Update(object Entity);
        List<Franchise> GetAllFranchises();
    }
}