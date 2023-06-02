using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopNovel.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Products = new HashSet<Product>();
        }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
