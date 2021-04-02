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

        private int _employeeId;
        private bool _isNewUser;

        public AddEditEmployee(int id = 0)
        {
            InitializeComponent();
            _employeeId = id;
            GetEmployeeData();
            tbFirstName.Select();
        }

        private void GetEmployeeData()
        {
            if (_employeeId != 0)
            {
                _employee = _fileHelper.DeserializeJSONFromFile().FirstOrDefault(x => x.EmployeeId == _employeeId);
                _isNewUser = false;
            }

            else
            {
                var employeeListTmp = new List<Employee>();
                employeeListTmp = _fileHelper.DeserializeJSONFromFile();
                if (employeeListTmp.Count == 0)
                {
                    _employeeId = 1;
                }
                else
                {
                    _employeeId = employeeListTmp[employeeListTmp.Count - 1].EmployeeId + 1;

                }
                _isNewUser = true;
                tbId.Text = _employeeId.ToString();
            }


            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
            if (!_isNewUser)
            {
                tbId.Text = _employee.EmployeeId.ToString();
            }
            tbFirstName.Text = _employee.FirstName;
            tbLastName.Text = _employee.LastName;
            tbStreet.Text = _employee.Street;
            tbPostalCode.Text = _employee.PostalCode;
            tbCity.Text = _employee.City;
            tbPosition.Text = _employee.Position;
            tbAgreementType.Text = _employee.AgreementType;
            tbSalary.Text = _employee.Salary.ToString();
        }

        private void btnCancelAddingOrEditiingEmployeeData_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveNewOrEditedEmployeeData_Click(object sender, EventArgs e)
        {
            var employeesListFromFile = _fileHelper.DeserializeJSONFromFile();

            if (!_isNewUser)
            {
                employeesListFromFile.RemoveAll(x => x.EmployeeId == _employeeId);
            }

            try
            {
                AddNewEmployee(employeesListFromFile);
            Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Uzupełnij Wszystkie kolumny za pomocą poprawnych wartości!");
            }
        }

        private void AddNewEmployee(List<Employee> employees)
        {
            _employee.EmployeeId = Int32.Parse(tbId.Text);
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
