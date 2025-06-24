
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System;

//namespace Smokeautomation_Test
//{
//    public class OrangeHRMLoginTest
//    {
//        private IWebDriver driver;
//        private seleniumHelper helper;
//        private WebDriverWait wait;
//        //private IWebDriver? driver; // Make nullable
//        //private seleniumHelper? helper; // Make nullable

//        [SetUp]
//        public void Setup()
//        {
//            driver = Driver.GetDriver();
//            helper = new seleniumHelper(driver);
//        }
//        //login and logout test
//        [Test]
//        public void LoginTest()
//        {
//            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

//            helper.Checkpages();
//            helper.sendKeys("Admin", "//input[@name='username']");
//            helper.sendKeys("admin123", "//input[@name='password']");
//            helper.click("//button[@type='submit']");

//            System.Threading.Thread.Sleep(2000);

//            // Handle any alert after login
//            helper.HandleAlert();

//            if (driver.Url.Contains("dashboard") || driver.PageSource.Contains("Dashboard"))
//            {
//                Console.WriteLine(" Login successful.");
//            }
//            else
//            {
//                Console.WriteLine(" Login failed.");
//            }

//            try
//            {
//                var logout = new LogoutHelper(driver);
//                logout.Logout();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Logout skipped or failed: " + ex.Message);
//            }
//        }
//        //search 
//        [Test]
//        public void SearchLeaveTest()

//        {
//            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
//            // Create helper instance
//            seleniumHelper helper = new seleniumHelper(driver);
//            helper.Checkpages();
//            helper.sendKeys("Admin", "//input[@name='username']");
//            helper.sendKeys("admin123", "//input[@name='password']");
//            helper.click("//button[@type='submit']");
//            // Navigate to the application
//            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");

//            //// Create helper instance
//            //seleniumHelper helper = new seleniumHelper(driver);

//            //// Ensure the page is loaded
//            //helper.Checkpages();

//            //// Enter search term in the search bar
//            //helper.sendKeys("Leave", "//input[@placeholder='Search']");

//            //// Press Enter or Click the search icon
//            //helper.click("//button[contains(@class, 'search-button')]");

//            //// Wait for the Leave page to load
//            //helper.Checkpages();
//            // Type "Leave" into the search box
//            helper.sendKeys("Leave", "//input[@placeholder='Search']");

//            // Click on the search button
//            helper.click("//button[contains(@class, 'search-button')]");

//            // Wait for the page to load
//            helper.Checkpages();

//            // Click on the "Leave" button/tab in the menu
//            helper.click("//a[contains(text(), 'Leave')]"); // Adjust XPath as needed

//            // Verify URL and page content without assertions
//            if (driver.Url.Contains("/leave") && driver.PageSource.Contains("Leave"))
//            {
//                Console.WriteLine("Search test case passed: Successfully navigated to the Leave page.");
//            }
//            else
//            {
//                Console.WriteLine(" Search test case failed: Did not navigate to the Leave page.");
//                Console.WriteLine("Current URL: " + driver.Url);
//            }
//        }




//        //pim(addemployee)


//        [Test]
//        public void AddEmployeeTest()
//        {
//            if (driver == null || helper == null)
//            {
//                Assert.Fail("Driver or helper is not initialized");
//                return;
//            }

//            // Login first
//            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
//            helper.Checkpages();
//            helper.sendKeys("Admin", "//input[@name='username']");
//            helper.sendKeys("admin123", "//input[@name='password']");
//            helper.click("//button[@type='submit']");
//            helper.Checkpages();

//            // Navigate to PIM > Add Employee
//            helper.click("//span[text()='PIM']");
//            helper.click("//a[text()='Add Employee']");
//            helper.Checkpages();

//            // Fill employee details from the image
//            helper.sendKeys("Maham", "//input[@name='firstName']");
//            helper.sendKeys("khan", "//input[@name='middleName']");
//            helper.sendKeys("Fatima", "//input[@name='lastName']");
//            helper.sendKeys("8679", "//div[contains(@class,'employee-id')]//input");

//            // Save the employee
//            helper.click("//button[@type='submit']");
//            helper.Checkpages();

//            // Verify success
//            if (driver.Url.Contains("pim/viewPersonalDetails") ||
//                driver.PageSource.Contains("Successfully Saved") ||
//                driver.PageSource.Contains("Personal Details"))
//            {
//                Console.WriteLine(" Employee added successfully.");
//            }
//            else
//            {
//                Console.WriteLine("Failed to add employee.");
//            }

//            // Verify the employee details
//            try
//            {
//                var fullNameElement = helper.FindElement("//div[@class='orangehrm-edit-employee-name']/h6");
//                if (fullNameElement != null)
//                {
//                    string fullName = fullNameElement.Text;
//                    if (fullName.Contains("Maham Fatima"))
//                    {
//                        Console.WriteLine("Employee name verified: " + fullName);
//                    }
//                    else
//                    {
//                        Console.WriteLine(" Employee name verification failed.");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Employee verification skipped: " + ex.Message);
//            }
//        }

//        //LoginAndSelectDropdownTest
//        [Test]
//        public void LoginAndSelectDropdownTest()
//        {
//            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

//            // Login steps
//            helper.Checkpages();
//            helper.sendKeys("Admin", "//input[@name='username']");
//            helper.sendKeys("admin123", "//input[@name='password']");
//            helper.click("//button[@type='submit']");

//            // Wait for Dashboard to load
//            wait.Until(driver => driver.Url.Contains("dashboard") || driver.PageSource.Contains("Dashboard"));

//            // Navigate to Employee List (PIM)
//            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList");

//            // Wait for Employment Status dropdown to be visible
//            IWebElement dropdownTrigger = wait.Until(driver =>
//                driver.FindElement(By.XPath("(//div[@class='oxd-select-text-input'])[1]")));
//            dropdownTrigger.Click();

//            // Wait for the dropdown option and click it
//            IWebElement fullTimeOption = wait.Until(driver =>
//                driver.FindElement(By.XPath("//div[@role='option' and text()='Full-Time Contract']")));
//            fullTimeOption.Click();

//            Console.WriteLine("Dropdown option 'Full-Time Contract' selected successfully.");
//        }


//        [TearDown]
//        public void TearDown()
//        {
//            Driver.QuitDriver();
//        }
//    }
//}


// OrangeHRMLoginTest.cs
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Smokeautomation_Test
{
    public class OrangeHRMLoginTest
    {
        private IWebDriver driver;
        private seleniumHelper helper;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = Driver.GetDriver();
            helper = new seleniumHelper(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            helper.Checkpages();
            helper.sendKeys("Admin", "//input[@name='username']");
            helper.sendKeys("admin123", "//input[@name='password']");
            helper.click("//button[@type='submit']");

            helper.HandleAlert();

            if (driver.Url.Contains("dashboard") || driver.PageSource.Contains("Dashboard"))
            {
                Console.WriteLine(" Login successful.");
            }
            else
            {
                Console.WriteLine(" Login failed.");
            }

            try
            {
                var logout = new LogoutHelper(driver);
                logout.Logout();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logout skipped or failed: " + ex.Message);
            }
        }

        [Test]
        public void SearchLeaveTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            helper.Checkpages();
            helper.sendKeys("Admin", "//input[@name='username']");
            helper.sendKeys("admin123", "//input[@name='password']");
            helper.click("//button[@type='submit']");

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");

            helper.sendKeys("Leave", "//input[@placeholder='Search']");
            helper.click("//button[contains(@class, 'search-button')]");
            helper.Checkpages();
            helper.click("//a[contains(text(), 'Leave')]");

            if (driver.Url.Contains("/leave") && driver.PageSource.Contains("Leave"))
            {
                Console.WriteLine("Search test case passed: Successfully navigated to the Leave page.");
            }
            else
            {
                Console.WriteLine(" Search test case failed: Did not navigate to the Leave page.");
                Console.WriteLine("Current URL: " + driver.Url);
            }
        }

        [Test]
        public void AddEmployeeTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            helper.Checkpages();
            helper.sendKeys("Admin", "//input[@name='username']");
            helper.sendKeys("admin123", "//input[@name='password']");
            helper.click("//button[@type='submit']");
            helper.Checkpages();

            helper.click("//span[text()='PIM']");
            helper.click("//a[text()='Add Employee']");
            helper.Checkpages();

            helper.sendKeys("Maham", "//input[@name='firstName']");
            helper.sendKeys("khan", "//input[@name='middleName']");
            helper.sendKeys("Fatima", "//input[@name='lastName']");
            helper.sendKeys("8679", "//div[contains(@class,'employee-id')]//input");
            helper.click("//button[@type='submit']");
            helper.Checkpages();

            if (driver.Url.Contains("pim/viewPersonalDetails") ||
                driver.PageSource.Contains("Successfully Saved") ||
                driver.PageSource.Contains("Personal Details"))
            {
                Console.WriteLine(" Employee added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add employee.");
            }

            try
            {
                var fullNameElement = helper.FindElement("//div[@class='orangehrm-edit-employee-name']/h6");
                if (fullNameElement != null)
                {
                    string fullName = fullNameElement.Text;
                    if (fullName.Contains("Maham Fatima"))
                    {
                        Console.WriteLine("Employee name verified: " + fullName);
                    }
                    else
                    {
                        Console.WriteLine(" Employee name verification failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Employee verification skipped: " + ex.Message);
            }
        }

        [Test]
        public void LoginAndSelectDropdownTest()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            helper.Checkpages();
            helper.sendKeys("Admin", "//input[@name='username']");
            helper.sendKeys("admin123", "//input[@name='password']");
            helper.click("//button[@type='submit']");

            wait.Until(driver => driver.Url.Contains("dashboard") || driver.PageSource.Contains("Dashboard"));

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList");

            IWebElement dropdownTrigger = wait.Until(driver =>
                driver.FindElement(By.XPath("(//div[@class='oxd-select-text-input'])[1]")));
            dropdownTrigger.Click();

            IWebElement fullTimeOption = wait.Until(driver =>
                driver.FindElement(By.XPath("//div[@role='option' and text()='Full-Time Contract']")));
            fullTimeOption.Click();

            Console.WriteLine("Dropdown option 'Full-Time Contract' selected successfully.");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
        }
    }
}
