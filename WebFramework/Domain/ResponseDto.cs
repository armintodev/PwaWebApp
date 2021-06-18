using System.Collections.Generic;

namespace WebFramework.Domain
{
    public class ResponseDto<TData> where TData : class
    {
        public List<TData> Items { get; set; }
        public Pager Pager { get; set; }
        public int Page { get; set; }
        public string Search { get; set; }
        public string SortOrder { get; set; }
    }
}
