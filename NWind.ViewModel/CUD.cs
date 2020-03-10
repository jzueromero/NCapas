﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NWind.ViewModel
{
    public class CUD : ViewModelBase
    {
        public CUD()
        {
            CreateProductoCommand = new CommandDelegate
                (
                    (o) => { return true; },
                    (o) => 
                        {
                            var NewProduct = new EntitiesStandart.Products
                            {
                                ProductName = ProductName_BF,
                                CategoryID = CategoryID_BF,
                                UnitsInStock = UnitsInStock_BF,
                                UnitPrice = UnitPrice_BF
                            };
                            var Proxy = new NWindProxyService.Proxy();
                            NewProduct = Proxy.CreateProduct(newProduct);
                            ProductID = NewProduct.ProductID;

                        }
                );
        }
    }
}