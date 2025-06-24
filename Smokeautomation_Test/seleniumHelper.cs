
////using OpenQA.Selenium;
////using OpenQA.Selenium.Support.UI;
////using SeleniumExtras.WaitHelpers;
////using System;

////namespace Smokeautomation_Test
////{
////    public class seleniumHelper
////    {
////        private readonly IWebDriver driver;

////        public seleniumHelper(IWebDriver driver)
////        {
////            this.driver = driver;
////        }

////        public void sendKeys(string data, string locator)
////        {
////            IWebElement? element = findElement(locator);
////            if (element != null)
////            {
////                element.Clear();
////                element.SendKeys(data);
////            }
////            else
////            {
////                Console.WriteLine("Element not found for sendKeys: " + locator);
////            }
////        }

////        public void click(string locator)
////        {
////            IWebElement? element = findElement(locator);
////            if (element != null)
////            {
////                element.Click();
////            }
////            else
////            {
////                Console.WriteLine("Element not found for click: " + locator);
////            }
////        }

////        private IWebElement? findElement(string locator, int timeout = 20)
////        {
////            try
////            {
////                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
////                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine("Error locating element: " + locator + "\n" + ex.Message);
////                return null;
////            }
////        }

////        public bool Checkpages()
////        {
////            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
////            try
////            {
////                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
////                return wait.Until(driver => js.ExecuteScript("return document.readyState").ToString() == "complete");
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine("Page not fully loaded: " + ex.Message);
////                return false;
////            }
////        }

////        public void HandleAlert(bool accept = true)
////        {
////            try
////            {
////                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
////                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

////                Console.WriteLine("Alert Text: " + alert.Text);

////                if (accept)
////                {
////                    alert.Accept();
////                }
////                else
////                {
////                    alert.Dismiss();
////                }
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine("No alert found or error handling alert: " + ex.Message);
////            }
////        }
////    }
////}

//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using System;

//namespace Smokeautomation_Test
//{
//    public class seleniumHelper
//    {
//        private readonly IWebDriver driver;
//        private readonly WebDriverWait wait;

//        public seleniumHelper(IWebDriver driver)
//        {
//            this.driver = driver;
//            // Initialize a wait with a default timeout of 20 seconds
//            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
//        }

//        public void sendKeys(string data, string locator)
//        {
//            var element = findElement(locator);
//            if (element != null)
//            {
//                element.Clear();
//                element.SendKeys(data);
//            }
//            else
//            {
//                Console.WriteLine("Element not found for sendKeys: " + locator);
//            }
//        }

//        public void click(string locator)
//        {
//            var element = findElement(locator);
//            if (element != null)
//            {
//                try
//                {
//                    // Wait until element is clickable
//                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
//                    element.Click();
//                }
//                catch (Exception)
//                {
//                    // If normal click fails, try JavaScript click
//                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
//                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
//                }
//            }
//            else
//            {
//                Console.WriteLine("Element not found for click: " + locator);
//            }
//        }

//        private IWebElement? findElement(string locator, int timeoutSeconds = 20)
//        {
//            try
//            {
//                var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
//                return localWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
//            }
//            catch (WebDriverTimeoutException)
//            {
//                Console.WriteLine("Timeout: Element not found - " + locator);
//                return null;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error locating element: " + locator + "\n" + ex.Message);
//                return null;
//            }
//        }
//        public IWebElement? FindElement(string locator, int timeoutSeconds = 20)
//        {
//            try
//            {
//                var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
//                return localWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
//            }
//            catch (WebDriverTimeoutException)
//            {
//                Console.WriteLine("Timeout: Element not found - " + locator);
//                return null;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error locating element: " + locator + "\n" + ex.Message);
//                return null;
//            }
//        }
//        public bool Checkpages()
//        {
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            try
//            {
//                return wait.Until(driver => js.ExecuteScript("return document.readyState").ToString() == "complete");
//            }
//            catch (WebDriverTimeoutException)
//            {
//                Console.WriteLine("Page did not load within expected time.");
//                return false;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error checking page load: " + ex.Message);
//                return false;
//            }
//        }

//        public void HandleAlert(bool accept = true)
//        {
//            try
//            {
//                WebDriverWait alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//                IAlert alert = alertWait.Until(ExpectedConditions.AlertIsPresent());
//                Console.WriteLine("Alert Text: " + alert.Text);

//                if (accept)
//                {
//                    alert.Accept();
//                }
//                else
//                {
//                    alert.Dismiss();
//                }
//            }
//            catch (WebDriverTimeoutException)
//            {
//                Console.WriteLine("No alert present.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error handling alert: " + ex.Message);
//            }
//        }

//        public void WaitForElement(string locator, int timeoutSeconds = 20)
//        {
//            try
//            {
//                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
//                customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
//            }
//            catch (WebDriverTimeoutException)
//            {
//                Console.WriteLine("Timeout waiting for element: " + locator);
//            }
//        }

//        public void ScrollIntoView(string locator)
//        {
//            var element = findElement(locator);
//            if (element != null)
//            {
//                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
//            }
//        }
//    }
//}




using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Smokeautomation_Test
{
    public class seleniumHelper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public seleniumHelper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public void sendKeys(string data, string locator)
        {
            var element = findElement(locator);
            if (element != null)
            {
                element.Clear();
                element.SendKeys(data);
            }
            else
            {
                Console.WriteLine("Element not found for sendKeys: " + locator);
            }
        }

        public void click(string locator)
        {
            var element = findElement(locator);
            if (element != null)
            {
                try
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
                    element.Click();
                }
                catch (Exception)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                }
            }
            else
            {
                Console.WriteLine("Element not found for click: " + locator);
            }
        }

        private IWebElement? findElement(string locator, int timeoutSeconds = 20)
        {
            try
            {
                var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return localWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: Element not found - " + locator);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error locating element: " + locator + "\n" + ex.Message);
                return null;
            }
        }

        public IWebElement? FindElement(string locator, int timeoutSeconds = 20)
        {
            try
            {
                var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                return localWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: Element not found - " + locator);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error locating element: " + locator + "\n" + ex.Message);
                return null;
            }
        }

        public bool Checkpages()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            try
            {
                return wait.Until(driver => js.ExecuteScript("return document.readyState").ToString() == "complete");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Page did not load within expected time.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking page load: " + ex.Message);
                return false;
            }
        }

        public void HandleAlert(bool accept = true)
        {
            try
            {
                WebDriverWait alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IAlert alert = alertWait.Until(ExpectedConditions.AlertIsPresent());
                Console.WriteLine("Alert Text: " + alert.Text);

                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("No alert present.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling alert: " + ex.Message);
            }
        }

        public void WaitForElement(string locator, int timeoutSeconds = 20)
        {
            try
            {
                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout waiting for element: " + locator);
            }
        }

        public void ScrollIntoView(string locator)
        {
            var element = findElement(locator);
            if (element != null)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
        }
    }
}

