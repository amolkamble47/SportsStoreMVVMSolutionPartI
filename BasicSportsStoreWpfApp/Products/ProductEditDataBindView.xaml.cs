using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Concrete;
using SportsStoreDomainLibrary.Entities;

namespace BasicSportsStoreWpfApp.Products
{
    /// <summary>
    /// Interaction logic for ProductEditDataBindView.xaml
    /// </summary>
    public partial class ProductEditDataBindView : UserControl
    {
        IProductRepository _productRepository;
        Product _product;
        public ProductEditDataBindView()
        {
            InitializeComponent();
            _productRepository = new EfProductRepository();
        }

        public int ProductId
        {
            get { return (int)GetValue(ProductIdProperty); }
            set { SetValue(ProductIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductIdProperty =
            DependencyProperty.Register("ProductId", typeof(int), typeof(ProductEditDataBindView), new PropertyMetadata(0));

        public async void OnLoaded(object sender, RoutedEventArgs e)
        {
            _product = await _productRepository.GetProductAsync(ProductId);
            if (_product!=null)
            {
                this.DataContext = _product;
            }
        }

        public async void OnSave(object sender, RoutedEventArgs e)
        {
            var result = await _productRepository.UpdateProductAsync(_product);
            if (result != null)
            {
                MessageBox.Show("Product Updated");
            }
        }


    }
}
