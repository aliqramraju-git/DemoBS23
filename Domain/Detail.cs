﻿namespace Domain;

public class Detail
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public DateTime CreatedTime { get; set; }
}
