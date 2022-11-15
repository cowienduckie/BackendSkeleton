namespace Application.Models.Users.Queries.GetUsers;

public class UserInfoDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public Guid? DepartmentId { get; set; }
}