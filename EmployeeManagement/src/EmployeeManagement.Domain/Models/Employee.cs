namespace EmployeeManagement.Domain.Models;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;
}