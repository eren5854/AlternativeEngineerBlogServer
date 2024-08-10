using AlternativeEngineerBlogServer.Domain.Repositories;
using AlternativeEngineerBlogServer.Domain.Shared;
using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;

namespace AlternativeEngineerBlogServer.Application.Features.Users.Links.CreateLink;
internal sealed class CreateLinkCommandHandler(
    ILinkRepository linkRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateLinkCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        Link link = mapper.Map<Link>(request);
        link.CreatedBy = "User";
        link.CreatedDate = DateTime.Now;

        await linkRepository.AddAsync(link, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Create is successful");
    }
}
