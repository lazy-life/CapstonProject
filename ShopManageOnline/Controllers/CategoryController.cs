using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using BussinessLogic.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace ShopManageOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetCategories")]
        public ActionResult<CategoryDTO> Get()
        {
            try
            {
                List<CategoryDTO> listCategories = _categoryService.GetCategory();
                if (listCategories == null)
                {
                    return NotFound();
                }
                return Ok(listCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCategory")]
        public ActionResult<Category> Post(Category cate)
        {
            try
            {
                _categoryService.SaveCategory(cate);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
