using Infrastructure.Persistence.Interfaces;
using MediatR;

namespace Application.Models.Users.Commands.UpdateUser;

public record UpdateUserCommand : IRequest
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        //var userRepository = _unitOfWork.AsyncRepository<ApplicationUser>();

        //var entity = await userRepository.GetAsync(x => x.Id == request.Id, cancellationToken);

        //if (entity == null)
        //{
        //    throw new NotFoundException(nameof(ApplicationUser), request.Id);
        //}

        //entity.FirstName = request.FirstName;
        //entity.LastName = request.LastName;

        //await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}