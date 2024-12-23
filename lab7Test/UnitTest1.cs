using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace lab7Test
{
  
    public class UnitTest1
    {
        [TestFixture]
        public class CultureRuTests
        {
            private IWebDriver driver;

            [SetUp]
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.culture.ru/");
            }

            // Проверка заголовка страницы
            [Test]
            public void Test_PageTitle()
            {
                string pageTitle = driver.Title;
                Assert.AreEqual("Культура.ру — портал культуры и искусства России", pageTitle);
            }

            // Проверка видимости объектов
            [Test]
            public void Test_VisibleElements()
            {
                var searchBar = driver.FindElement(By.Id("search-input"));
                var menuButton = driver.FindElement(By.Id("header-menu"));

                Assert.IsTrue(searchBar.Displayed, "Поисковая строка не видна.");
                Assert.IsTrue(menuButton.Displayed, "Меню не видимо.");
            }
              // Проверка перехода на новую страницу
            [Test]
            public void Test_LinkNavigation()
            {
                // Переход по ссылке
                var link = driver.FindElement(By.LinkText("Театры"));
                link.Click();
                string currentUrl = driver.Url;
                Assert.IsTrue(currentUrl.Contains("teatry"), "Переход по ссылке не удался.");
            }

            // Заполнение текстового поля
            [Test]
            public void Test_TextFieldInput()
            {
                var searchInput = driver.FindElement(By.Id("search-input"));
                searchInput.SendKeys("музыка");
                string inputValue = searchInput.GetAttribute("value");

                Assert.AreEqual("музыка", inputValue, "Текст в поле ввода не совпадает с ожидаемым.");
            }

            [Test]
            public void Test_ButtonClick()
            {
                var searchButton = driver.FindElement(By.Id("search-button"));
                searchButton.Click();
                Assert.IsTrue(driver.Url.Contains("search"), "После нажатия на кнопку не произошло ожидаемое действие.");
            }
        }
    }
}
