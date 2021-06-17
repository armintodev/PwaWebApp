using Pwa.Query.Contracts.WebApp;
using System.Collections.Generic;

namespace Pwa.Query.Contracts.Category
{
    public class CategoryQueryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
        public List<WebAppQueryModel> WebApps { get; set; }
    }
}
