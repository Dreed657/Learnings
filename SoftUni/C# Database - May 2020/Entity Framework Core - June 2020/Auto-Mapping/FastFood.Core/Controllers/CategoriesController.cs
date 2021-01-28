using AutoMapper.QueryableExtensions;
using FastFood.Models;
using System.Linq;

namespace FastFood.Core.Controllers
{
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var cat = this.mapper.Map<Category>(model);

            this.context.Categories.Add(cat);
            this.context.SaveChanges();

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var categories = this.context.Categories
                .ProjectTo<CategoryAllViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return View(categories);
        }
    }
}
