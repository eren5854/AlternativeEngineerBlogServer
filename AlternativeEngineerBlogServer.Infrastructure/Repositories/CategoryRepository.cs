using AlternativeEngineerBlogServer.Domain.Categories;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
public sealed class CategoryRepository : Repository<Category, ApplicationDbContext>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
