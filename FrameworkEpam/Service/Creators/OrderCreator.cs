using FrameworkEpam.Model;
using FrameworkEpam.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkEpam.Service.Creators
{
    public static class OrderCreator
    {
        public static OrderData CreateValidMarketStopOrder() => ConfigurationManager.Configuration.MarketStopOrder;
        public static OrderData CreateValidMarketOrder() => ConfigurationManager.Configuration.MarketOrder;
        public static OrderData CreateValidLimitOrder() => ConfigurationManager.Configuration.LimitOrder;
    }
}
