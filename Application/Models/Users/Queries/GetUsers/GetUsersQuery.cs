namespace Application.Models.Users.Queries.GetUsers;

//[Authorize]
//public record GetUsersQuery : IRequest<IEnumerable<UserInfoDTO>>;

//public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserInfoDTO>>
//{
//    private readonly IUnitOfWork _unitOfWork;
//    public GetUsersQueryHandler(IUnitOfWork unitOfWork)
//    {
//        this._unitOfWork = unitOfWork;
//    }

//    public async Task<IEnumerable<UserInfoDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
//    {
//        var userRepository = this._unitOfWork.AsyncRepository<ApplicationUser>();
//        var users = await userRepository.ListAsync();
//        var userDTOs = users.Select(_ => new UserInfoDTO
//        {
//            UserName = _.UserName,
//            FirstName = _.FirstName,
//            LastName = _.LastName,
//            Address = _.Address,
//            BirthDate = _.BirthDate,
//            DepartmentId = _.DepartmentId,
//            Id = _.Id
//        });

//        return userDTOs;
//    }
//}
