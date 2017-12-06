using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebRest
{
    public partial class NorthwindEntities : DbContext
    {
        public NorthwindEntities(bool lazy)
            : base("name=NorthwindEntities")
        {
            if (lazy)
            {
                Configuration.LazyLoadingEnabled = true;
                Configuration.ProxyCreationEnabled = false;
            }
        }
    }
}