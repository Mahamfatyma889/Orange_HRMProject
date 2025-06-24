//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace Smokeautomation_Test
//{
//    public static class Driver
//    {
//        private static IWebDriver? driver;

//        public static IWebDriver GetDriver()
//        {
//            if (driver == null)
//            {
//                driver = new ChromeDriver();
//            }
//            return driver;
//        }

//        public static void QuitDriver()
//        {
//            driver?.Quit();
//            driver = null;
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Smokeautomation_Test
{
    public static class Driver
    {
        private static IWebDriver? driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}