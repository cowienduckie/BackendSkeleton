using API.DTOs.Users;
using API.Services.Users;
using Application.Models.Users.Commands.CreateUser;
using Application.Models.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ApiControllerBase
{
    private readonly UserService _service;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger,
        UserService service)
    {
        this._logger = logger;
        this._service = service;
    }

    //[HttpGet]
    //public async Task<IActionResult> Get([FromQuery] GetUserRequest request)
    //{
    //    var users = await _service.SearchAsync(request);

    //    return Ok(users);
    //}

    [HttpGet]
    public async Task<IEnumerable<UserInfoDTO>> Get()
    {
        //return await Mediator.Send(new GetUsersQuery());
        throw new NotImplementedException();
    }

    //[HttpPost]
    //public async Task<IActionResult> Add([FromBody] AddUserRequest request)
    //{
    //    var user = await _service.AddNewAsync(request);

    //    return Ok(user);
    //}

    [HttpPost]
    public async Task<ActionResult<AddUserResponse>> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }


    [HttpPost("payslips")]
    public async Task<IActionResult> AddPayslip([FromBody] AddPayslipRequest request)
    {
        var user = await _service.AddUserPayslipAsync(request);

        return Ok(user);
    }
}