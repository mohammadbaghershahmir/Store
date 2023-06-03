using EndPointStore.Areas.Admin.Models.ViewModelCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Products.Category.Commands.GetParentCategory;
using Store.Application.Services.Products.Category.Queries.AddNewCategory;
using Store.Application.Services.Users.Command.DeleteUser;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;
        public CategoriesController(IProductFacad productFacad )
        {
            _productFacad =productFacad;   
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listView =await _productFacad.GetParentCategory.Execute();
            List<ParentCategoryDto> list = new List<ParentCategoryDto>();
            list.Add(new ParentCategoryDto()
            {
                Id = null,
                ParentId = null,
                Name = "هیچکدام",
            }
          );
            list.AddRange(listView);
            ViewModelCategories viewModelCategories = new ViewModelCategories()
            {
                AddCategoryView=new AddCategoryViewDto(),
                ParentCategory= listView
            };
          
            ViewBag.Category = new SelectList(list, "Id", "Name");
            return View(viewModelCategories);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AddCategoryViewDto addCategory)
        {
            var result = await _productFacad.AddCategoryService.Execute(
                new RequestCatgoryDto
                {
                   
                    OrginalName = addCategory.Name,
                    ParentId = addCategory.ParentId,
                    Name = addCategory.Name,
                    CssClass = addCategory.CssClass,
                    Icon = addCategory.Icon,
                    Description = addCategory.Description,
                    IsActive = addCategory.IsActive,
                    Slug = addCategory.Slug,
                    Sort = addCategory.Sort,
                    Id= addCategory.Id,
                }
                );
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string categoryId)
        {
            return Json(await _productFacad.GetDeleteCategory.Execute(categoryId));
        }
    }
}

