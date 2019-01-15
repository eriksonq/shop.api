using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.Core.DomainModels
{
    public class ProductModel
    {
        public int? Id;
        public string Title;
        public string Description;
        public decimal Price;
        public int CategoryId;
        public string CategoryName;
        public List<ProductParamModel> Parameters;
    }
}
