using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SportsStoreMVVMWpfApp.Products
{
    public class SimpleEditableProduct: ValidatableBindableBase
    {
        private int _productId;
        private string _productName;
        private string _description;
        private decimal _price;
        private string _category;
        public int ProductId { get => _productId; set => SetProperty(ref _productId,value); }
        [Required(ErrorMessage = "Enter a Product Name")]
        public string ProductName { get => _productName; set => SetProperty(ref _productName, value); }
        [Required(ErrorMessage = "Enter a description")]
        public string Description { get => _description; set => SetProperty(ref _description,value); }
        [Required(ErrorMessage = "Enter a positive price")]
        public decimal Price { get => _price; set => SetProperty(ref _price, value); }
        [Required(ErrorMessage = "Enter a category")]
        public string Category { get => _category; set => SetProperty(ref _category, value); }
    }
}
