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
        }

        public void LoadDataToGrid()
        {
            employeeList = _fileHelper.DeserializeJSONFromFile();
            dgvEmployeeData.DataSource = employeeList;
            cmbAllEmployedUnemployed.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditEmployee = new AddEditEmployee();
            addEditEmployee.Text = "Dodaj";
            addEditEmployee.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvEmployeeData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz rekord z pracownikiem, jeśli chcesz go edytować.");
                return;
            }

            var selectedEmployeeForEditID = dgvEmployeeData.SelectedRows[0].Cells[0].Value;
            var addEditEmployee = new AddEditEmployee((int)selectedEmployeeForEditID);
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
                MessageBox.Show($"Gratulacje! W łatwy sposób {selectedEmployee.Cells[1].Value} {selectedEmployee.Cells[2].Value} został pozbawiony pracy."); // zostawiłem tak nie bez powodu.
                                                                                                                                                             // Dlaczego wartości w klamrach tutaj dają null exception? kiedy wpiszę całą ścieżkę bez
                                                                                                                                                             // pośrednictwa zmiennej to zadziała. dlatego też dołożyłem selectedEmployeeID,
                                                                                                                                                             // żeby mi metoda do zwalniania zadziałała
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

        private void cmbAllEmployedUnemployed_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filteredEmployees = new List<Employee>();
            if (cmbAllEmployedUnemployed.SelectedIndex == 0)
            {
                LoadDataToGrid();
            }
            else if (cmbAllEmployedUnemployed.SelectedIndex == 1)
            {
                filteredEmployees = _fileHelper.DeserializeJSONFromFile().Where(x => x.IsFired == false).ToList();
                dgvEmployeeData.DataSource = filteredEmployees;

            }
            else if (cmbAllEmployedUnemployed.SelectedIndex == 2)
            {
                filteredEmployees = _fileHelper.DeserializeJSONFromFile().Where(x => x.IsFired == true).ToList();
                dgvEmployeeData.DataSource = filteredEmployees;
            }
        }
    }
}
