using AutoMapper;
using BussinessLogic.DTO;
using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class AddressService
    {
        private readonly AddressDAO _addressDAO;
        public AddressService(AddressDAO addressDAO)
        {
            _addressDAO = addressDAO;
        }

        public List<Address> GetAddRessByUserId(int usId)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var dataAdd = context.Addresses.Where(x => x.UserId == usId).ToList();
                foreach (var d in dataAdd)
                {
                    d.Detail = d.Detail + ", " + GetAddressDetail(d.Matp, d.Maqh, d.Mapx);
                }
                return dataAdd;
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

        public void AddAddress(Address address)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                context.Addresses.Add(address);
                context.SaveChanges();
            }
        }

        public void UpdateAddress(int addressId, string city, string distric, string ward, string detail)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var address = context.Addresses.FirstOrDefault(x => x.AddressID.Equals(addressId));
                if (address != null)
                {
                    address.Matp = city;
                    address.Mapx = distric;
                    address.Maqh = ward;
                    address.Detail = detail;
                }
                context.SaveChanges();
            }
        }

        public string GetAddressDetail(string cityId, string districtId, string wardId)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var cityD = context.Cities.FirstOrDefault(x => x.Matp.Equals(cityId));
                var districtD = context.Districts.FirstOrDefault(x => x.Maqh.Equals(districtId));
                var wardD = context.Wards.FirstOrDefault(x => x.Xaid.Equals(wardId));
                return $" {wardD.Name}, {districtD.Name}, {cityD.Name}";
            }
        }

        public void UpdateAddress(Address address)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var dta = context.Addresses.FirstOrDefault(x => x.AddressID == address.AddressID);
                if (dta != null)
                {
                    dta.Mapx = address.Mapx;
                    dta.Matp = address.Matp;
                    dta.Maqh = address.Maqh;
                    dta.Detail = address.Detail;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
