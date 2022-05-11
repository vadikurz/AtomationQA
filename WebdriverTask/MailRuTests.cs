using NUnit.Framework;
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

            var actualLogin = mainMenuPage.SignIn().Login(UserData.Login, UserData.Password).UserLogin();

            Assert.AreEqual(UserData.Login, actualLogin);
        }
    }
}