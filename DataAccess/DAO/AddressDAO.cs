using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AddressDAO
    {
        public List<Address> GetAddRessByUserId(int usId)
        {
            using(DataAccessContext context = new DataAccessContext())
            {
                return context.Addresses.Where(x => x.UserId.Equals(usId.ToString())).ToList();
            }
        }

        public Address GetAddressByID(string id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Addresses.FirstOrDefault(x => x.AddressID.Equals(id));
            }
        }

        public List<City> GetAllCity()
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Cities.ToList();
            }
        }

        public List<District> GetAddressByCity(string cityId)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Districts.Where(x => x.Matp.Equals(cityId)).ToList();
            }
        }

        public List<Ward> GetWardByDistrictId(string disId)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Wards.Where(x => x.Maqh.Equals(disId)).ToList();
            }
        }
    }
}
