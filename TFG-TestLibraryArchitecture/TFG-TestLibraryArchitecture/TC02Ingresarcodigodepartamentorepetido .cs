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
    public class TC02IngresarCodRepetido
    {
        [TestMethod,]
        public void TC02Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                // Abrimos la página web de inicio se sesión
                //Crear Departamento
                test.CrearDepartamento(wdriver, "02", "Astronomia");
                test.BuscarMenu(wdriver, "Department", "Save Department");
                wdriver.FindElement(By.Id("Code")).Click();
                //Validar departamento repetido
                wdriver.FindElement(By.Id("Code")).SendKeys("02");
                wdriver.FindElement(By.Id("Name")).Click();
                wdriver.FindElement(By.Id("Name")).SendKeys("Estudios");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("form > p")).Text, Is.EqualTo("Department Code Already Exists. Department Codebe be unique"));
                //Darle click a la opción View All Departments en el menú principal
                test.BuscarMenu(wdriver, "Department", "View All Departments");
                //Validar que el departamento creado  se encuentre dentro de View All Departments en el menú principal
                wdriver.FindElement(By.LinkText("2")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector(".grid-row:nth-child(3) > .grid-cell:nth-child(1)")).Text, Is.EqualTo("02"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector(".grid-row:nth-child(3) > .grid-cell:nth-child(2)")).Text, Is.EqualTo("Astronomia"));
                wdriver.Close();
            }
        }
    }
}