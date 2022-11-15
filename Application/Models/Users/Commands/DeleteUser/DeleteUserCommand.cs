using MediatR;

namespace Application.Models.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    //private readonly IUnitOfWork _unitOfWork;

    //public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    //{
    //    _unitOfWork = unitOfWork;
    //}

    //public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    //{
    //    var userRepository = _unitOfWork.AsyncRepository<ApplicationUser>();

    //    var entity = await userRepository.GetAsync(x => x.Id == request.Id, cancellationToken);

    //    if (entity == null)
    //    {
    //        throw new NotFoundException(nameof(ApplicationUser), request.Id);
    //    }

    //    await userRepository.DeleteAsync(entity);

    //    entity.AddDomainEvent(new UserDeletedEvent(entity));

    //    await _unitOfWork.SaveChangesAsync(cancellationToken);

    //    return Unit.Value;
    //}
    public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}