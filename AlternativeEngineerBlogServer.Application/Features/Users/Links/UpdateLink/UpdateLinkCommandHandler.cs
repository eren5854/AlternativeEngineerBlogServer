using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Shared;
using AlternativeEngineerBlogServer.Domain.Users;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.UpdateLink;
internal sealed class UpdateLinkCommandHandler(
    ILinkRepository linkRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    UserManager<AppUser> userManager) : IRequestHandler<UpdateLinkCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.AppUserId.ToString());
        if (user == null)
        {
            return Result<string>.Failure("User not found");
        }
        Link link = await linkRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (link == null)
        {
            return Result<string>.Failure("Link not found");
        }

        mapper.Map(request, link);
        link.UpdatedBy = user.UserName;
        link.UpdatedDate = DateTime.Now;

        linkRepository.Update(link);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link update is successful");
    }
}
