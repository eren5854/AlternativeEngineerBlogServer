using AlternativeEngineerBlogServer.Domain.Blogs;
using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.GetAllBlog;
public sealed record GetAllBlogQuery() : IRequest<Result<List<GetAllBlogDto>>>;
