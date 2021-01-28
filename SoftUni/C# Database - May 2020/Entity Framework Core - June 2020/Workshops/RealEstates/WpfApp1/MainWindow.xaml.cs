using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Data;
using Services;
using Services.Contracts;
using Services.DataTransferObject;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPropertiesService _propertiesService;
        private IBuildingTypeService _buildingTypeService;
        private IPropertyTypeService _propertyTypeService;
        private IDistrictsService _districtsService;

        public MainWindow()
        {
            InitializeComponent();
            var db = new RealEstateDbContext();
            this._propertiesService = new PropertiesService(db);
            this._buildingTypeService = new BuildingTypeService(db);
            this._propertyTypeService = new PropertyTypeService(db);
            this._districtsService = new DistrictsService(db);

            LoadForms();
        }

        private async Task LoadForms()
        {
            BuildingTypeComboBox.ItemsSource = await this._buildingTypeService.GetAllNames();
            PropertyTypeComboBox.ItemsSource = await this._propertyTypeService.GetAllNames();
            DistrictComboBox.ItemsSource = await this._districtsService.GetAllNames();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            var propertyModel = new PropertyCreateDto()
            {
                Size = int.Parse(SizeBox.Text),
                Year = int.Parse(YearBox.Text),
                Price = int.Parse(PriceBox.Text),
                BuildingType = BuildingTypeComboBox.Text,
                PropertyType = PropertyTypeComboBox.Text,
                District = DistrictComboBox.Text,
                Url = "https://www.imot.bg/pcgi/imot.cgi?act=5&adv=1h155448398782425&slink=5p50ib&f1=1",
            };

            this._propertiesService.CreateOne(propertyModel);
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = false;
        }
    }
}
