using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using BussinessLogic.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;

namespace ShopManageOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("getByUsId/{usId}")]
        public ActionResult<Address> Get(int usId)
        {
            try
            {
                List<Address> listProducts = _addressService.GetAddRessByUserId(usId);
                if (listProducts == null)
                {
                    return NotFound();
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getByAddressId/{addressId}")]
        public ActionResult<Address> Get(string addressId)
        {
            try
            {
                Address listProducts = _addressService.GetAddressByID(addressId);
                if (listProducts == null)
                {
                    return NotFound();
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getCity")]
        public ActionResult<City> Get()
        {
            try
            {
                List<City> listProducts = _addressService.GetAllCity();
                if (listProducts == null)
                {
                    return NotFound();
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getDistrict/{id}")]
        public ActionResult<District> GetDistrict(string id)
        {
            try
            {
                List<District> listProducts = _addressService.GetAddressByCity(id);
                if (listProducts == null)
                {
                    return NotFound();
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getWard/{id}")]
        public ActionResult<Ward> GetWard(string id)
        {
            try
            {
                List<Ward> listProducts = _addressService.GetWardByDistrictId(id);
                if (listProducts == null)
                {
                    return NotFound();
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddAddress")]
        public ActionResult<Ward> AddAddress(Address address)
        {
            try
            {
                _addressService.AddAddress(address);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("UpdateAddress/{id}/{city}/{district}/{ward}/{detail}")]
        public ActionResult<Ward> UpdateAddress(int id, string city, string district, string ward, string detail)
        {
            try
            {
                _addressService.UpdateAddress(id, city, district, ward, detail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
