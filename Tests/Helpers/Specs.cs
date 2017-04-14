using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Tests.Helpers
{
    public static class Specs
    {
        public static IWebDriver Driver;
        
        public static bool Above(this IWebElement item1, IWebElement item2)
        {
            int y1 = item1.Location.Y;
            int y2 = item2.Location.Y;
            return y1 < y2;
        }

        public static bool Below(this IWebElement item1, IWebElement item2)
        {
            return Above(item2, item1);
        }

        public static bool CenteredVerticallyScreen(this IWebElement item)
        {
            int screenHeight = Driver.Manage().Window.Size.Height;
            int itemHeight = item.Size.Height;
            int itemTopY = item.Location.Y;
            int itemBottomY = itemTopY + itemHeight;
            return (itemBottomY - itemTopY)/2 == screenHeight/2;
        }

        public static bool CenteredHorizontallyScreen(this IWebElement item)
        {
            int screenWidth = Driver.Manage().Window.Size.Width;
            int itemWidth = item.Size.Width;
            int itemLeftX = item.Location.X;
            int itemRightX = itemLeftX + itemWidth;
            return (itemRightX - itemLeftX)/2 == screenWidth/2;
        }

        public static bool CenteredAllScreen(this IWebElement item)
        {
            return CenteredVerticallyScreen(item) && CenteredHorizontallyScreen(item);
        }

        public static bool LeftOf(this IWebElement item1, IWebElement item2)
        {
            return item1.Location.X < item2.Location.X;
        }

        public static bool RightOf(this IWebElement item1, IWebElement item2)
        {
            return item2.LeftOf(item1);
        }
    }
}
