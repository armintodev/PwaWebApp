using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Product.Category;
using Pwa.Domain.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _category;
        public CategoryApplication(ICategoryRepository category)
        {
            _category = category;
        }

        public async Task<OperationResult> Create(CreateCategoryDto dto)
        {
            if (await _category.IsExistsAsync(_ => _.Title == dto.Title))
                return new OperationResult(false, "دسته بندی با این عنوان وجود دارد");

            Category category = new(dto.Title);
            await _category.AddAsync(category, CancellationToken.None);
            return new OperationResult();
        }

        public async Task<OperationResult> Delete(int id)
        {
            var category = await _category.GetByIdAsync(CancellationToken.None, id);

            await _category.DeleteAsync(category, CancellationToken.None);
            return new OperationResult(message: "دسته بندی با موفقیت حذف شد");
        }

        public async Task<OperationResult<CategoryDto>> Detail(int id)
        {
            var category = await _category.GetByIdAsync(CancellationToken.None, id);
            if (category is null)
            {
                CategoryDto nullCategoryDto = new();
                return new OperationResult<CategoryDto>(nullCategoryDto, false, "دسته بندی ای با این مشخصات وجود ندارد");
            }
            CategoryDto data = new()
            {
                Id = category.Id,
                Title = category.Title,
                CreationDate = category.CreationDate.ToFarsiFull(),
                LastEditDate = category.LastEditDate.ToFarsiFull(),
            };
            return new OperationResult<CategoryDto>(data);
        }

        public async Task<OperationResult> Edit(EditCategoryDto dto)
        {
            var category = await _category.GetByIdAsync(CancellationToken.None, dto.Id);

            if (await _category.IsExistsAsync(_ => (_.Title == dto.Title) && _.Id != dto.Id))
            {
                return new OperationResult(false, "دسته بندی با این عنوان وجود دارد");
            }

            category.Edit(dto.Title);
            await _category.SaveChangesAsync();
            return new OperationResult(true, "عملیات ویرایش با موفقیت انجام شد");
        }

        public async Task<OperationResult<EditCategoryDto>> Get(int id)
        {
            var category = await _category.GetByIdAsync(CancellationToken.None, id);
            if (category is null)
            {
                EditCategoryDto nullEditCategoryDto = new();
                return new OperationResult<EditCategoryDto>(nullEditCategoryDto, false, "دسته بندی با این مشخصات وجود ندارد");
            }
            EditCategoryDto data = new()
            {
                Id = category.Id,
                Title = category.Title
            };
            return new OperationResult<EditCategoryDto>(data, true, "");
        }

        public async Task<List<CategoryDto>> List()
        {
            var categories = _category.TableNoTracking.Select(_ => new CategoryDto
            {
                Id = _.Id,
                Title = _.Title
            });
            return await categories.ToListAsync();
        }
    }
}
