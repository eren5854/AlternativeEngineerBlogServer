using AlternativeEngineerBlogServer.Domain.Abstractions;
using AlternativeEngineerBlogServer.Domain.Shared;

namespace AlternativeEngineerBlogServer.Domain.Categories;
public sealed class Category : Entity
{
    public Name Name { get; set; } = new(string.Empty);
    public Guid MainCategoryId { get; set; }
    public Category? MainCategory { get; set; }
}
