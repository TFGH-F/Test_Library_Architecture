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
    public class TC01CrearDepartamento
    {
        [TestMethod,]
        public void TC01Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                //Iniciar Página Principal
                Libreria test = new Libreria();
                //Resultado Esperado: Se abre la página de creación de departamentos
                test.AbrirPaginaPrincipal(wdriver);
                //Creación de departamento
                test.CrearDepartamento(wdriver, "01", "Ciencias");
                //Darle click a la opción View All Departments en el menú principal
                wdriver.FindElement(By.LinkText("Department")).Click();
                wdriver.FindElement(By.LinkText("View All Departments")).Click();
                //Verificación de datos
                wdriver.FindElement(By.LinkText("2")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector(".grid-row:nth-child(2) > .grid-cell:nth-child(1)")).Text, Is.EqualTo("01"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector(".grid-row:nth-child(2) > .grid-cell:nth-child(2)")).Text, Is.EqualTo("Ciencias"));
                wdriver.Close();
            } 
        }    
    }
}