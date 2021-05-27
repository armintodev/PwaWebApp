using System;

namespace Pwa.Domain.Base
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
    public interface IEntity : IEntity<int>
    {
    }

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
