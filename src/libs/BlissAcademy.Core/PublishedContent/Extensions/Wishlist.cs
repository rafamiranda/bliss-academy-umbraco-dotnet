using BlissAcademy.Core.PublishedContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlissAcademy.Core.PublishedContent
{
    public partial class Wishlist
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}

