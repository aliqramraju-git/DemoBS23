using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ProjectVM
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ProjectMapperConfiguration : Profile
{
    public ProjectMapperConfiguration()
    {
        CreateMap<Project, ProjectVM>();
        CreateMap<ProjectVM, Project>();
    }
}
