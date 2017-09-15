using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;
using SportsStoreDomainLibrary.Concrete;
using System.Windows.Input;
using System.Windows;

namespace BasicSportsStoreWpfApp.Products
{
    public class ProductEditSimpleMVVMViewModel : INotifyPropertyChanged
    {
        private IProductRepository _productRepository;
        private Product _product;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand SaveCommand { get; set; }

        public ProductEditSimpleMVVMViewModel()
        {
            _productRepository = new EfProductRepository();
            SaveCommand = new RelayCommand(OnSave);
        }

        public int ProductId { get; set; }
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Product"));
            }
        }

        public async void LoadProduct()
        {
            Product = await _productRepository.GetProductAsync(ProductId);
        }

        private async void OnSave()
        {
            Product = await _productRepository.UpdateProductAsync(Product);
            MessageBox.Show("Product Updated");// Not to be done from here will later use Notification
        }
    }
}
