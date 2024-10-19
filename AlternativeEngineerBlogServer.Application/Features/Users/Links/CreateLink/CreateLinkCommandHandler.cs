using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Shared;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.CreateLink;
internal sealed class CreateLinkCommandHandler(
    ILinkRepository linkRepository,
    IUnitOfWork unitOfWork,
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<CreateLinkCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.AppUserId.ToString());

        Link link = mapper.Map<Link>(request);
        link.CreatedBy = user!.UserName!;
        link.CreatedDate = DateTime.Now;

        await linkRepository.AddAsync(link, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Create is successful");
    }
}
