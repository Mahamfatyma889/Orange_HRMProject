//using OpenQA.Selenium;

//namespace Smokeautomation_Test
//{
//    public class LogoutHelper
//    {
//        private readonly seleniumHelper helper;

//        public LogoutHelper(IWebDriver driver)
//        {
//            helper = new seleniumHelper(driver);
//        }

//        public void Logout()
//        {
//            helper.click("//p[@class='oxd-userdropdown-name']");
//            helper.click("//a[text()='Logout']");
//        }
//    }
//}


using OpenQA.Selenium;

namespace Smokeautomation_Test
{
    public class LogoutHelper
    {
        private readonly seleniumHelper helper;

        public LogoutHelper(IWebDriver driver)
        {
            helper = new seleniumHelper(driver);
        }

        public void Logout()
        {
            helper.click("//p[@class='oxd-userdropdown-name']");
            helper.click("//a[text()='Logout']");
        }
    }
}
