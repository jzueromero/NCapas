using System;
using System.Collections.Generic;
using System.Text;
using EntitiesStandart;

namespace NWind.ViewModel
{
    public class Product : ViewModelBase
    {
        public Product()
        {
            InitializeViewModel();
        }

        void InitializeViewModel()
        {
            Productos = new List<EntitiesStandart.Products>();
            SearchProductosCommand = new CommandDelegate
                (
                (o) => { return true; },
                (o) =>
                    {
                        var Proxy = new NWindProxyService.Proxy();
                        Productos = Proxy.FilterProductByCategoryID(1);
                    }
                );
            SearchProductosByIDCommand = new CommandDelegate
                (
                    (o) => { return true; },
                    (o) =>
                        {
                            if (ProductoSelected.ProductID != 0)
                            {
                                var Proxy = new NWindProxyService.Proxy();
                                var p = Proxy.RetrieveProductById
                                (ProductoSelected.ProductID);
                                ProductName = p.ProductName;
                                ProductID = p.ProductID;
                                UnitsInStock = p.UnitsInStock;
                                UnitPrice = p.UnitPrice;
                            }
                        }
                );
        }

        #region properties
        private int CategoryID_BF;

        public int Category
        {
            get { return CategoryID_BF; }
            set { CategoryID_BF = value;
                OnPropertyChanged();
            }
        }

        private List<EntitiesStandart.Products> Products_BF;

        public List<EntitiesStandart.Products> Productos
        {
            get { return Products_BF; }
            set { Products_BF = value;
                OnPropertyChanged();
            }
        }

        private EntitiesStandart.Products ProductsSelected_BF;

        public EntitiesStandart.Products ProductoSelected
        {
            get { return ProductsSelected_BF; }
            set {
                ProductsSelected_BF = value;
                OnPropertyChanged();
            }
        }

        private string ProductName_BF;

        public string ProductName
        {
            get { return ProductName_BF; }
            set { ProductName_BF = value; OnPropertyChanged(); }
        }

        private int ProductID_BF;

        public int ProductID
        {
            get { return ProductID_BF; }
            set { ProductID_BF = value; OnPropertyChanged(); }
        }

        private decimal UnitsInStock_BF;

        public decimal UnitsInStock
        {
            get { return UnitsInStock_BF; }
            set { UnitsInStock_BF = value; OnPropertyChanged(); }
        }

        private decimal UnitPrice_BF;

        public decimal UnitPrice
        {
            get { return UnitPrice_BF; }
            set { UnitPrice_BF = value; OnPropertyChanged(); }
        }

        public CommandDelegate SearchProductosCommand { get; set; }
        public CommandDelegate SearchProductosByIDCommand { get; set; }
        #endregion
    }
}
