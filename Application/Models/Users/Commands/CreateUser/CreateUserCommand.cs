using Infrastructure.Persistence.Interfaces;
using MediatR;

namespace Application.Models.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<AddUserResponse>
{
    public Guid DepartmentId { get; init; }
    public string UserName { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AddUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<AddUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //using var transaction = _unitOfWork.GetDatabaseTransaction();

        try
        {
            // You can you some mapping tools as such as AutoMapper
            //var user = new ApplicationUser(request.UserName,
            //request.FirstName,
            //request.LastName,
            //request.DepartmentId);

            //var userRepository = _unitOfWork.AsyncRepository<ApplicationUser>();
            //user.AddDomainEvent(new UserCreatedEvent(user));

            //await userRepository.AddAsync(user);
            //await _unitOfWork.SaveChangesAsync();

            //await transaction.CommitAsync();


            var response = new AddUserResponse
            {
                //Id = user.Id,
                //UserName = user.UserName
            };

            return response;

        }
        catch
        {
            //await transaction.RollbackAsync();

            return null;
        }

    }
}