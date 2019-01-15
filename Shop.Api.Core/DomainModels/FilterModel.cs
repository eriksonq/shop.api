using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.Core.DomainModels
{
    public class FilterModel
    {
        public int? CategoryId;
        public List<ProductParamModel> Params = new List<ProductParamModel>();
    }
}
