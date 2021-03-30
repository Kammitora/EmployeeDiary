using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace EmployeeDiary
{
    public class FileHelper
    {
        public void SerializeJSONToFile(List<Employee> employeeList)
        {
            var json = JsonSerializer.Serialize(employeeList);
            File.WriteAllText(@"C:\Users\Kamil\Source\Repos\EmployeeDiary\jebac.txt", json);
        }

        public List<Employee> DeserializeJSONFromFile()
        {
            var employeeList = new List<Employee>();
            var json = File.ReadAllText(@"C:\Users\Kamil\Source\Repos\EmployeeDiary\jebac.txt");
            employeeList = JsonSerializer.Deserialize<List<Employee>>(json);
            return employeeList;
        }
    }
}
