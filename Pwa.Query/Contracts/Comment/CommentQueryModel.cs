namespace Pwa.Query.Contracts.Comment
{
    public class CommentQueryModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Like { get; set; }
        public string UserName { get; set; }
        public string UserIcon { get; set; }
        public string CreationDate { get; set; }
    }
}
