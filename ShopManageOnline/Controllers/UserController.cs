using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using Microsoft.AspNetCore.Mvc;

namespace ShopManageOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetUsers")]
        public ActionResult<UserDTO> Get()
        {
            try
            {
                List<UserDTO> listUsers = _userService.GetUsers();
                if(listUsers == null)
                {
                    return NotFound();
                }
                return Ok(listUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
