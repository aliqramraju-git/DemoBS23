using AutoMapper;

namespace Domain;

public class Detail
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public DateTime CreatedTime { get; set; }
}

public class DetailVM
{
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
}

public class DetailMapperConfiguration : Profile
{
    public DetailMapperConfiguration()
    {
        CreateMap<Detail, DetailVM>();
        CreateMap<DetailVM, Detail>();
    }
}
