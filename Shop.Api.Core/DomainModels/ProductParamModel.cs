using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.Core.DomainModels
{
    public class ProductParamModel
    {
        public int? Id;
        public string Value;
        public int CategoryParamId;
        public string CategoryParamName;
        public int ProductId;
    }
}
