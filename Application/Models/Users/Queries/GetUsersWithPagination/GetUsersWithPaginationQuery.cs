namespace Application.Models.Users.Queries.GetUsersWithPagination;

//public record GetUsersWithPaginationQuery : IRequest<PaginatedList<UserBriefDto>>
//{
//    public Guid DepartmentId { get; init; }
//    public int PageNumber { get; init; } = 1;
//    public int PageSize { get; init; } = 10;
//}

//public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserBriefDto>>
//{
//    private readonly IUnitOfWork _unitOfWork;
//    private readonly IMapper _mapper;

//    public GetUsersWithPaginationQueryHandler(
//        IUnitOfWork unitOfWork,
//        IMapper mapper)
//    {
//        _unitOfWork = unitOfWork;
//        _mapper = mapper;
//    }

//    public async Task<PaginatedList<UserBriefDto>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
//    {
//        var userRepository = this._unitOfWork.AsyncRepository<ApplicationUser>();
//        var users = await userRepository.ListAsync(x => x.DepartmentId == request.DepartmentId);

//        return await users.OrderBy(x => x.FirstName).AsQueryable()
//                    .ProjectTo<UserBriefDto>(_mapper.ConfigurationProvider)
//                    .PaginatedListAsync(request.PageNumber, request.PageSize);
//    }
//}
