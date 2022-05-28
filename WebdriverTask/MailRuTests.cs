using NUnit.Framework;
using WebdriverTask.Exceptions;
using WebdriverTask.PageObjects;

namespace WebdriverTask
{
    [TestFixture]
    public class Tests : MailRuBaseTest
    {
        [Test]
        public void SignInPositiveTest()
        {
            var mainMenuPage = new MainMenuPage(webDriver);

            var actualLogin = mainMenuPage.SignIn().Login(UserCredentials.FirstLogin, UserCredentials.Password).UserLogin();

            Assert.AreEqual(UserCredentials.FirstLogin, actualLogin);
        }
        
        [TestCase("abcabdcabc")]
        [TestCase("abcabdcabc@mail")]
        [TestCase("")]
        [TestCase(" ")]
        public void SiqnInInvalidLoginNegativeTest(string login)
        {
            var mainMenuPage = new MainMenuPage(webDriver);

            Assert.Throws<InvalidUserLoginException>(() => mainMenuPage.SignIn().Login(login, UserCredentials.Password));
        }
        
        [TestCase("aaa")]
        [TestCase("")]
        [TestCase(" ")]
        public void SignInInvalidPasswordNegativeTest(string password)
        {
            var mainMenuPage = new MainMenuPage(webDriver);
            
            Assert.Throws<InvalidUserPasswordException>(() => mainMenuPage.SignIn().Login(UserCredentials.FirstLogin, password));
        }
    }
}