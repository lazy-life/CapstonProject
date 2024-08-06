using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly CategoryDAO _categoryDAO;
        public CategoryService(IMapper mapper, CategoryDAO categoryDAO)
        {
            _mapper = mapper;
            _categoryDAO = categoryDAO;
        }

        public List<CategoryDTO> GetCategory()
        {
            return _mapper.Map<List<CategoryDTO>>(_categoryDAO.GetCategories());
        }

        public void SaveCategory(Category categoryDTO)
        {
            _categoryDAO.AddCategory(categoryDTO);
        }
    }
}
