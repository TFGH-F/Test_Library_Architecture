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
    public class TC04CrearProfesor
    {
        [TestMethod,]
        public void TC04Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                //Se crea un departamento
                test.CrearDepartamento(wdriver, "04", "Matematica");
                //Se ingresa al menu del profesor
                test.BuscarMenu(wdriver, "Teacher", "Save Teacher");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                //Se valida los campos Vacíos
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Name-error")).Text, Is.EqualTo("Please enter the Name"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Address-error")).Text, Is.EqualTo("Address is required!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Email-error")).Text, Is.EqualTo("Please email address is required"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Contact-error")).Text, Is.EqualTo("Please enter the contact"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("DesignationId-error")).Text, Is.EqualTo("Designation is required!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("DepartmentId-error")).Text, Is.EqualTo("Please select department"));
                //Se ingresan los datos en los campos de texto
                wdriver.FindElement(By.Id("Name")).Click();
                wdriver.FindElement(By.Id("Name")).SendKeys("Luisa Jimenez");
                wdriver.FindElement(By.Id("Address")).Click();
                wdriver.FindElement(By.Id("Address")).SendKeys("Heredia");
                wdriver.FindElement(By.Id("Email")).Click();
                wdriver.FindElement(By.Id("Email")).SendKeys("luisa20@gmail.com");
                wdriver.FindElement(By.Id("Contact")).Click();
                wdriver.FindElement(By.Id("Contact")).SendKeys("88888888");
                wdriver.FindElement(By.Id("DesignationId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DesignationId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Professor']")).Click();
                }
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DepartmentId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Matematica']")).Click();
                }
                //Se valida que el profesor se creara exitosamente
                wdriver.FindElement(By.Id("CreditTobeTaken")).Click();
                wdriver.FindElement(By.Id("CreditTobeTaken")).SendKeys("1");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("p:nth-child(4)")).Text, Is.EqualTo("Saved Sucessfully"));
                wdriver.Close();

            }
         }
    }
}