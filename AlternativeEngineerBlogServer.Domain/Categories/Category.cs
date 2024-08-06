using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Shared;

namespace AlternativeEngineerBlogServer.Domain.Categories;
public sealed class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid? MainCategoryId { get; set; }
    public Category? MainCategory { get; set; }
}
