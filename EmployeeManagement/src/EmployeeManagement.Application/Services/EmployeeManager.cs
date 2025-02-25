using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Application.Services;

public static class EmployeeManager
{
    private static readonly SortedDictionary<int, Employee> Employees = new();

    public static Employee? Get(int id)
        => Employees.GetValueOrDefault(id);

    public static void Create(Employee employee)
        => Employees.Add(employee.Id, employee);

    public static void Update(Employee employee)
    {
        if (Employees.ContainsKey(employee.Id))
        {
            Employees[employee.Id] = employee;
        }
    }

    public static void ChangeName(Employee employee)
    {
        if (Employees.TryGetValue(employee.Id, out var employeeToUpdate))
        {
            employeeToUpdate.Name = employee.Name;
        }
    }

    public static void Delete(int id)
    {
        Employees.Remove(id);
    }
}