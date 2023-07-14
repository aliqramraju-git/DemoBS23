using AutoMapper;

namespace Domain;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class EmployeeVM
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class EmployeeMapperConfiguration : Profile
{
    public EmployeeMapperConfiguration()
    {
        CreateMap<Employee, EmployeeVM>();
        CreateMap<EmployeeVM, Employee>();
    }
}
