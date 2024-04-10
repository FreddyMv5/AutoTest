using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using System.Drawing.Imaging;


namespace AutoTest
{
    class Program
    {
        static void Main(string[] args)
        {

            // Obtener la ruta del directorio del proyecto
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Carpeta para almacenar las capturas de pantalla
            string screenshotsDirectory = Path.Combine(projectDirectory, "screenshots");
            Directory.CreateDirectory(screenshotsDirectory);



            //Driver del buscador
            IWebDriver driver = new ChromeDriver();

            //Url para la pagina que buscara automatico
            driver.Navigate().GoToUrl("https://www.corotos.com.do/");
            //Hacer que la web se maximize
            driver.Manage().Window.Maximize();

            //TomarScreenshot
            TakeScreenshot(driver, screenshotsDirectory, "screenshot_after_click");

            //Buscar elementos
            IWebElement input = driver.FindElement(By.Id("search"));

            //Enviar indicacion
            input.SendKeys("Toyota Corolla 2020");
            TakeScreenshot(driver, screenshotsDirectory, "screenshot_after_click");
            //Accion para que haga "ENTER"
            Actions actions = new Actions(driver);
            actions.SendKeys(input, Keys.Enter).Perform();

            TakeScreenshot(driver, screenshotsDirectory, "screenshot_after_click");


            //Filtrar busqueda
            IWebElement filter = driver.FindElement(By.Id("sort-select"));
            filter.Click();

            TakeScreenshot(driver, screenshotsDirectory, "screenshot_after_click");

            IWebElement filter2 = driver.FindElement(By.XPath("//*[@id=\"sort-select\"]/option[4]"));
            filter2.Click();

            TakeScreenshot(driver, screenshotsDirectory, "screenshot_after_click");



        }
        static void TakeScreenshot(IWebDriver driver, string directory, string filenamePrefix)
        {
            // Obtener la fecha y hora actual
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");

            // Construir el nombre de archivo único
            string filename = $"{filenamePrefix}_{timestamp}.png";

            // Tomar la captura de pantalla y guardarla en el directorio especificado
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath = Path.Combine(directory, filename);
            screenshot.SaveAsFile(screenshotPath);
        }

    }
}