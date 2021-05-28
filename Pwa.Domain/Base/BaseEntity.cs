using System;

namespace Pwa.Domain.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }
    public abstract class BaseDetail
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }

}
