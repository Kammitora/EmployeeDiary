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
        string _path = @"C:\Users\Kamil\Source\Repos\EmployeeDiary1\EmployeeList.txt";
        public void SerializeJSONToFile(List<Employee> employeeList)
        {
            var json = JsonSerializer.Serialize(employeeList);
            File.WriteAllText(_path, json);
        }

        public List<Employee> DeserializeJSONFromFile()
        {
            if (!File.Exists(_path))
            {
                return new List<Employee>();
            }
            var employeeList = new List<Employee>();
            var json = File.ReadAllText(_path);
            employeeList = JsonSerializer.Deserialize<List<Employee>>(json);
            return employeeList.OrderBy(x => x.EmployeeId).ToList();
        }
    }
}
