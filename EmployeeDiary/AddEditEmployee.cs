using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDiary
{
    public partial class AddEditEmployee : Form
    {
        private Employee _employee = new Employee();
        public FileHelper _fileHelper = new FileHelper();
        public AddEditEmployee()
        {
            InitializeComponent();
        }

        //Do odświeżania danych zaraz po zamknięciu okienek

        private void btnCancelAddingOrEditiingEmployeeData_Click(object sender, EventArgs e)
        {
            Close();
            
            
        }

        private void btnSaveNewOrEditedEmployeeData_Click(object sender, EventArgs e)
        {
            var employeesListFromFile = _fileHelper.DeserializeJSONFromFile();
            AddNewEmployee(employeesListFromFile);
            Close();
        }

        private void AddNewEmployee(List<Employee> employees)
        {
            _employee.EmployeeId =  Int32.Parse(tbId.Text);
            _employee.FirstName = tbFirstName.Text;
            _employee.LastName = tbLastName.Text;
            _employee.Street = tbStreet.Text;
            _employee.PostalCode = tbPostalCode.Text;
            _employee.City = tbCity.Text;
            _employee.Position = tbPosition.Text;
            _employee.AgreementType = tbAgreementType.Text;
            _employee.HiringDate = dtpHiringDate.Value;
            _employee.Salary = Int32.Parse(tbSalary.Text);

            employees.Add(_employee);

            _fileHelper.SerializeJSONToFile(employees);


        }
    }
}
