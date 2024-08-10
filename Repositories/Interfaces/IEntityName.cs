namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IEntityName
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int employeeId);

        Task<Employee> UpdateEmployee(int id, Employee employee);

        Task DeleteEmployee(int id);

    }
}
