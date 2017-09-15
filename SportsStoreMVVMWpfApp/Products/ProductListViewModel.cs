using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;
using SportsStoreDomainLibrary.Concrete;
using System.Collections.ObjectModel;

namespace SportsStoreMVVMWpfApp.Products
{
    public class ProductListViewModel: BindableBase
    {
        private IProductRepository _productRepository;
        private ObservableCollection<Product> _products;
        private string _displayMessage;
        private bool _messageFlag;

        public ProductListViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            EditProductCommand = new RelayCommand<Product>(OnEdit);
            DeleteProductCommand = new RelayCommand<Product>(OnDelete);
            DismissMessageCommand = new RelayCommand(OnDismiss);
            AddNewProductCommand = new RelayCommand(OnAddNewProduct);
        }


        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public async void LoadProducts()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            Products = new ObservableCollection<Product>(await _productRepository.GetProductsAsync());
        }


        public string DisplayMessage { get => _displayMessage; set => SetProperty(ref _displayMessage, value); }
        public bool MessageFlag { get => _messageFlag; set => SetProperty(ref _messageFlag, value); }

        public RelayCommand DismissMessageCommand { get; set; }

        private void OnDismiss() { MessageFlag = false; }

        public RelayCommand AddNewProductCommand { get; set; }
        public event Action<Product> AddNewProductRequested = delegate { };
        private void OnAddNewProduct()
        {
            AddNewProductRequested(new Product());
        }

        public RelayCommand<Product> EditProductCommand { get; set; }
        public event Action<Product> EditProductRequested = delegate { };
        private void OnEdit(Product product)
        {
            EditProductRequested(product);
        }

        public RelayCommand<Product> DeleteProductCommand { get; set; }
        private async void OnDelete(Product product)
        {
            //await _productRepository.DeleteProductAsync(product.ProductId);
            MessageFlag = true;
            if (MessageFlag)
            {
                DisplayMessage = string.Format("Product: {0}, with the Id: {1}, Deleted Successfully", product.ProductName, product.ProductId);
                //LoadProducts(); 
            }
        }
    }
}
