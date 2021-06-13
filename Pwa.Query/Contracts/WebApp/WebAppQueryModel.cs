using Pwa.Query.Contracts.Comment;
using System.Collections.Generic;

namespace Pwa.Query.Contracts.WebApp
{
    public class WebAppQueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
        public bool IsGame { get; set; }
        public int Visit { get; set; }
        public int Installed { get; set; }
        public string Category { get; set; }
        public string Picture { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
        public List<PictureQueryModel> Pictures { get; set; }
    }
}
