using GIBS.Modules.GIBSMLSImageCleaner.Data;
using DotNetNuke.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIBS.Modules.GIBSMLSImageCleaner.Components
{
    public class MLSNumbersController 
    {
        // GET api/<controller>


        public static List<MLSNumbersInfo> GetListingNumbers()

        {   //todo: look at caching

            return CBO.FillCollection<MLSNumbersInfo>(DataProvider.Instance().GetListingNumbers());

        }



    }
}