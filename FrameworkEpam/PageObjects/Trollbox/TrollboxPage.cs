using FrameworkEpam.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkEpam.PageObjects.Trollbox
{
    public class TrollboxPage : BasePageObject
    {
        public IWebElement PopUpChat => WaitUtil.WaitForElement(UIMap.Get("Trollbox"));
        public IWebElement ChatInput => WaitUtil.WaitForElement(UIMap.Get("ChatInput"));
        public ICollection<IWebElement> MyMessages => WaitUtil.WaitForElements(UIMap.Get("ChatMyMessage"), 1);

        public TrollboxPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
