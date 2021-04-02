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
    public partial class MainWindow : Form
    {
        public List<Employee> employeeList = new List<Employee>();
        private FileHelper _fileHelper = new FileHelper();
        public MainWindow()
        {
            InitializeComponent();
            LoadDataToGrid();
            RenameColumns();

            Employee myEmployee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Kamil",
                LastName = "Kowalski",
                Street = "Żeromskiego 16/20 m. 31",
                PostalCode = "01-831",
                City = "Warszawa",
                Position = "Junior DevOps Engineer",
                Salary = 4500,
                AgreementType = "Umowa o pracę, czas nieokreślony",
                HiringDate = DateTime.Today,
                IsFired = false
            };

        }

        public void LoadDataToGrid()
        {
            employeeList = _fileHelper.DeserializeJSONFromFile();
            dgvEmployeeData.DataSource = employeeList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditEmployee = new AddEditEmployee();
            addEditEmployee.Text = "Dodaj";
            addEditEmployee.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var addEditEmployee = new AddEditEmployee();
            addEditEmployee.Text = "Edytuj";
            addEditEmployee.ShowDialog();
        }

        private void RenameColumns()
        {
            var count = 0;
            var columnNames = new List<string>
            {
                "Id","Imię","Nazwisko","Ulica","Kod Pocztowy","Miasto","Stanowisko","Wynagrodzenie","Rodzaj umowy","Data zatrudnienia","Zwolniony","Data zwolnienia",
            };
            foreach (var item in columnNames)
            {
                dgvEmployeeData.Columns[count].HeaderText = item;
                count++;
            }

        }

        private void btnFire_Click(object sender, EventArgs e)
        {

            if (dgvEmployeeData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz pracownika, którego chcesz zwolnić.", "Zwolnij - Błąd");
                return;
            }

            var selectedEmployeeID = dgvEmployeeData.SelectedRows[0].Cells[0].RowIndex;
            var selectedEmployee = dgvEmployeeData.SelectedRows[0];
            var result = MessageBox.Show("Czy na pewno chcesz ustawić status \"zwolniony\" dla tego pracownika? Tej zmiany nie będzie można cofnąć.",
                "Zwolnij", System.Windows.Forms.MessageBoxButtons.YesNo);


            if (result == DialogResult.Yes)
            {
                FireAnEmployee(selectedEmployeeID);
                MessageBox.Show($"Gratulacje! W łatwy sposób {selectedEmployee.Cells[1].Value} {selectedEmployee.Cells[2].Value} został pozbawiony pracy."); // zostawiłem tak nie bez powodu. Dlaczego wartości w klamrach tutaj dają null exception?
                LoadDataToGrid();
            }
        }

        private void FireAnEmployee(int id)
        {
            employeeList[id].IsFired = true;
            employeeList[id].FiringDate = DateTime.Today;
            _fileHelper.SerializeJSONToFile(employeeList);

        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }
    }
}
