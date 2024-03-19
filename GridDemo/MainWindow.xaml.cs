using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace GridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Persoon> personList = new ObservableCollection<Persoon>();
        //List<Persoon> personList = new List<Persoon>();
        List<Land> landList = new List<Land>();
        public MainWindow()
        {
            InitializeComponent();
            cmbLand.ItemsSource = null;
            BindLanden();
            BindGrid();
        }
        
        
        private void BindGrid()
        {
            personList.Add(new Persoon("Rik", 25, "Man", "Belgie"));
            personList.Add(new Persoon("Zakaria", 20, "Man", "Duitsland"));
            personList.Add(new Persoon("Eveliene", 26, "Vrouw", "Duitsland"));
            personList.Add(new Persoon("Salvatore", 29, "Man", "Spanje"));
            personList.Add(new Persoon("Gabriela", 30, "Vrouw", "Frankrijk"));
            personList.Add(new Persoon("Hugo", 23, "Man", "Frankrijk"));
            personList.Add(new Persoon("Olesia", 24, "Vrouw", "Belgie"));
            personList.Add(new Persoon("Santiago", 32, "Man", "Duitsland"));
            personList.Add(new Persoon("Dritan", 31, "Man", "Belgie"));

            dataGrid.ItemsSource = personList;
        }
        private void BindLanden()
        {

            landList.Add(new Land("Select Country"));
            landList.Add(new Land("Belgie"));
            landList.Add(new Land("Duitsland"));
            landList.Add(new Land("Frankrijk"));
            landList.Add(new Land("Spanje"));
            cmbLand.ItemsSource = landList;
            cmbLand.SelectedIndex = 0;
        }

        
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbLand.SelectedIndex != 0)
            {
                string naam = txtNaam.Text;
                int leeftijd = int.Parse(txtLeeftijd.Text);
                string geslacht = txtGeslacht.Text;
                string? land;
                if (cmbLand.SelectedValue != null)
                {
                    land = cmbLand.SelectedValue.ToString();
                }
                else
                {
                    land = "";
                }
                Persoon persoon = new(naam, leeftijd, geslacht, land);
                personList.Add(persoon);
            }
            else
            {
                MessageBox.Show("Selecteer een land");
            }

        }
        public void Search(string searchFor)
        {
            var result = personList.Where(p => p.Land.Equals(searchFor)).ToList();
            dataGrid.ItemsSource = result;
        }

        private void cmbLand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? land;
            if (cmbLand.SelectedValue != null)
            {
                land = cmbLand.SelectedValue.ToString();
                Search(land);
            }
            else
            {
                land = "";
            }

        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement(sender as DataGrid, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row != null && row.Item is Persoon item)
            {
                txtNaam.Text = item.Naam;
                txtLeeftijd.Text = item.Leeftijd.ToString();
                txtGeslacht.Text = item.Geslacht;
                cmbLand.Text = item.Land;

            }
        }
        private void mnuOver_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the first version of the best program in the entire world");
        }
    }
}