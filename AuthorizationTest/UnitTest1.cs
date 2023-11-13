using OpenQA.Selenium;

namespace AuthorizationTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By signInButton = By.XPath("//button[text()= 'Login']");
        private readonly By loginInputButton = By.XPath("//input[@id = 'userName']");
        private readonly By passwordInputButton = By.XPath("//input[@id= 'password']");
        private readonly By buttonLoginInputButton = By.XPath("//button[@id= 'login']");
        private readonly By userLogin = By.XPath("//label[@id = 'userName-value']");

        private readonly string _login = "mkavunov991@gmail.com";
        private readonly string _password = "vP7$3sK#3";
        [SetUp] // �������� ����� ������
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(); //�������������
            driver.Navigate().GoToUrl("https://demoqa.com/books"); //������ ����� �������
            driver.Manage().Window.Maximize();
        }

        [Test] // ��� ���� ���������������
        public void Test1()
        {
            var sigIn = driver.FindElement(signInButton);
            sigIn.Click();
           
            var login = driver.FindElement(loginInputButton);
            login.SendKeys(_login);

            Thread.Sleep(400);
            var password = driver.FindElement(passwordInputButton);
            password.SendKeys(_password);

            var loginButton = driver.FindElement(buttonLoginInputButton);
            loginButton.Click();
            
            Thread.Sleep(1000);
            var actualLogin = driver.FindElement(userLogin).Text;
            
            Thread.Sleep(400);
            Assert.AreEqual( _login, actualLogin, "eror");// �������� , ��������� .

           
        }

        [TearDown] //�������� ����� �����
        public void TearDown()
        { 
        
        }
    }

}