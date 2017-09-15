using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportsStoreDomainLibrary.Entities;
using SportsStoreMVVMWpfApp.Products;
using Microsoft.Practices.Unity;

namespace SportsStoreMVVMWpfApp
{
    public class MainWindowViewModel: BindableBase
    {
        private ProductListViewModel _productListViewModel;
        private AddEditProductViewModel _addEditProductViewModel;
        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            NavigationCommand = new RelayCommand<string>(OnNavigate);

            //_productListViewModel = new ProductListViewModel();
            _productListViewModel = SportsStoreContainer.Container.Resolve<ProductListViewModel>();
            _productListViewModel.EditProductRequested += NavigateToEditProduct;
            _productListViewModel.AddNewProductRequested += NavigateToAddNewProduct;

            _addEditProductViewModel = SportsStoreContainer.Container.Resolve<AddEditProductViewModel>();
            _addEditProductViewModel.Done += NavigateToProduct;

            AddNewProductCommand = new RelayCommand(OnAddNewProduct);
        }

        private void NavigateToProduct()
        {
            CurrentViewModel = _productListViewModel;
        }

        private void OnAddNewProduct()
        {
            NavigateToAddNewProduct(new Product());
        }

        private void NavigateToAddNewProduct(Product product)
        {
            _addEditProductViewModel.EditFlag = false;
            _addEditProductViewModel.SetProduct(product);
            CurrentViewModel = _addEditProductViewModel;
        }

        private void NavigateToEditProduct(Product product)
        {
            _addEditProductViewModel.EditFlag = true;
            _addEditProductViewModel.SetProduct(product);
            CurrentViewModel = _addEditProductViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public RelayCommand<string> NavigationCommand { get; set; }
        public RelayCommand AddNewProductCommand { get; set; }
        private void OnNavigate(string destination)
        {
            switch (destination)
            {
                default:
                    CurrentViewModel = _productListViewModel;
                    break;
            }
        }

    }
}
