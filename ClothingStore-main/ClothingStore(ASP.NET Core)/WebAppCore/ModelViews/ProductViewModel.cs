using System;
using WebAppCore.Models;

namespace WebAppCore.ModelViews
{
	public class ProductViewModel
	{
		public Category category { get; set; }
		public List<Product> lsTinDangs { get; set; }
	}
}

