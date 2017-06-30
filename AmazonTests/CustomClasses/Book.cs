using System.Collections.Generic;

namespace AmazonTests
{
    public class Book
    {
        public string Title;
        public int Quantity;
        public IDictionary<string, string> FormatPrice = new Dictionary<string, string>();
        public IList<string> Badges = new List<string>();
    }
}
