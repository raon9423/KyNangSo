using System;
using WebAppCore.Models;

namespace WebAppCore.ModelViews
{
	public class HomeViewModel
	{
		//public List<Product> Products { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<Product> AllProducts { get; set; }
    }
}

