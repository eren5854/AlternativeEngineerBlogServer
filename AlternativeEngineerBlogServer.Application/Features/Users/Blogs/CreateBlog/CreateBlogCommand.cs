﻿using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Blogs.CreateBlog;
public sealed record CreateBlogCommand(
    string Title,
    string SubTitle,
    IFormFile? MainImage,
    string Content,
    Guid AppUserId,
    Guid CategoryId) : IRequest<Result<string>>;
