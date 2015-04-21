using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMongoDB01.Models
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(string id);
        //Employee Add(Employee employee);
        //bool Update(string objectId, Employee employee);
        //bool Delete(string objectId);
    }
}
