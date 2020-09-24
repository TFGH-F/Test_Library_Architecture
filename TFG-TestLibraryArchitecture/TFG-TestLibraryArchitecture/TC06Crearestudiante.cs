using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using LibreriaMaestra;
using NUnit;
using NUnit.Framework;

namespace PruebaSelenium
{
    [TestClass]
    public class TC06CrearEstudiante
    {
        [TestMethod,]
        public void TC06Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                //Se crea departamento
                test.CrearDepartamento(wdriver, "05", "Ingieneria");
                //Se registra un estudiante
                test.BuscarMenu(wdriver, "Student", "Register Student");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                //Se valida los campos vacíos
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Name-error")).Text, Is.EqualTo("Please enter the student Name"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Email-error")).Text, Is.EqualTo("Please email address is required"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Contact-error")).Text, Is.EqualTo("Please enter the student contact"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Address-error")).Text, Is.EqualTo("Address is required!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("DepartmentId-error")).Text, Is.EqualTo("Please select department"));
               //Se registra los datos en los campos de texto
                wdriver.FindElement(By.Id("Name")).Click();
                wdriver.FindElement(By.Id("Name")).SendKeys("Fabian Gutierrez");
                wdriver.FindElement(By.Id("Email")).Click();
                wdriver.FindElement(By.Id("Email")).SendKeys("fabianjim20@gmail.com");
                wdriver.FindElement(By.Id("Contact")).Click();
                wdriver.FindElement(By.Id("Contact")).SendKeys("88888888");
                wdriver.FindElement(By.Id("RegDate")).Click();
                wdriver.FindElement(By.Id("RegDate")).SendKeys("12/8/1997");
                wdriver.FindElement(By.LinkText("1")).Click();
                wdriver.FindElement(By.Id("Address")).Click();
                wdriver.FindElement(By.Id("Address")).SendKeys("Heredia");
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DepartmentId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Ingieneria']")).Click();
                }
                //Se valida que se registro el estudiante exitosamente
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector(".body-content:nth-child(5)")).Text, Is.EqualTo("Saved Successfully!\r\nRegistration No:05-2020-001\r\nName:Fabian Gutierrez\r\nEmail:fabianjim20@gmail.com\r\nContact Number:88888888"));
                wdriver.Close();
            }
        }
    }
}