using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.Core.DomainModels
{
    public class CategoryModel
    {
        public int Id;
        public string Title;
        public List<CategoryParamModel> Parameters;
    }
}
