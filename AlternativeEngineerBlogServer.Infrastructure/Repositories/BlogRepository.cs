using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Infrastructure.Context;
using ED.GenericRepository;

namespace AlternativeEngineerBlogServer.Infrastructure.Repositories;
public sealed class BlogRepository : Repository<Blog, ApplicationDbContext>, IBlogRepository
{
    public BlogRepository(ApplicationDbContext context) : base(context)
    {
    }
}
