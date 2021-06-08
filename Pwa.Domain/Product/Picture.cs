using Pwa.Domain.Aggregates;
using Pwa.Domain.Base;
using System;

namespace Pwa.Domain.Product
{
    public class Picture : BaseDetail, IPictureAggregate
    {
        public string FileName { get; private set; }

        public int WebApplicationId { get; private set; }
        public WebApplication WebApplication { get; private set; }

        protected Picture()
        {

        }

        public Picture(string fileName, int webApplicationId)
        {
            FileName = fileName;
            WebApplicationId = webApplicationId;
            CreationDate = DateTime.Now;
        }
    }
}
