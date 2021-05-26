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
    public class BaseDetail
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditDate { get; private set; }
    }

}
