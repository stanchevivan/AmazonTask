using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTests
{
    public class Book
    {
        public string Title;
        public IDictionary<string, string> PriceForFormat;
        public IList<string> Badges;
    }
}
