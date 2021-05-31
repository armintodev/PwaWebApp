using Pwa.Application.Contracts.Product.Category;
using Pwa.Domain.Product;
using System;
using System.Linq.Expressions;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class CategoryExpression
    {
        public static Expression<Func<Category, CategoryDto>> ToDto => _ => new CategoryDto
        {
            Id = _.Id,
            Title = _.Title,
        };

        //to create category , maybe i use to CreateCategoryDto rather than CategoryDto
        public static Expression<Func<CategoryDto, Category>> FromDto => _ => new Category(_.Title)
        {
            Id = _.Id
        };
    }
}
