using NUnit.Framework;
using WebdriverTask.Exceptions;
using WebdriverTask.MailRuPageObjects;
using WebdriverTask.YandexMailPageObjects;

namespace WebdriverTask
{
    [TestFixture]
    public class MailServicesTests : MailServicesBaseTest
    {
        private const string MessageWithName = "Alex Alex";

        [Test]
        public void SignInPositiveTest()
        {
            var mainMenuPage = new MailRuMainMenuPage(webDriver);

            var actualLogin = mainMenuPage.SignIn().Login(UserCredentials.MailRuLogin, UserCredentials.Password).GetUserLogin();

            Assert.AreEqual(UserCredentials.MailRuLogin, actualLogin);
        }
        
        [TestCase("abcabdcabc")]
        [TestCase("abcabdcabc@mail")]
        [TestCase("")]
        [TestCase(" ")]
        public void SignInInvalidLoginNegativeTest(string login)
        {
            var mainMenuPage = new MailRuMainMenuPage(webDriver);

            Assert.Throws<InvalidUserLoginException>(() => mainMenuPage.SignIn().Login(login, UserCredentials.Password));
        }
        
        [TestCase("aaa")]
        [TestCase("")]
        [TestCase(" ")]
        public void SignInInvalidPasswordNegativeTest(string password)
        {
            var mainMenuPage = new MailRuMainMenuPage(webDriver);
            
            Assert.Throws<InvalidUserPasswordException>(() => mainMenuPage.SignIn().Login(UserCredentials.MailRuLogin, password));
        }
        
        [TestCase("Feugiat sociosqu nostra dis massa magna auctor aliquam nullam, " +
                  "porta mauris aliquet iaculis integer ornare netus, suscipit bibendum imperdiet elit ",MessageWithName), Order(0)]
        public void SendingReadingEmailTest(string messageFromFirstServer, string messageFromSecondServer)
        {
            var mailRuMainMenuPage = new MailRuMainMenuPage(webDriver);
            var yandexMainPage = new YandexMailMainPage(webDriver);
            
            mailRuMainMenuPage.SignIn().Login(UserCredentials.MailRuLogin, UserCredentials.Password).EnterNewEmailButton()
                .SendEmail(UserCredentials.YandexLogin, messageFromFirstServer);
            
            webDriver.Navigate().GoToUrl("https://mail.yandex.by");
            
            var yandexMailBoxPage =
                yandexMainPage.SignIn().Login(UserCredentials.YandexLogin, UserCredentials.Password);
            
            var actualMessage = yandexMailBoxPage.ReadMessage(UserCredentials.MailRuLogin);
            yandexMailBoxPage.SendEmail(UserCredentials.MailRuLogin,messageFromSecondServer);
            
            Assert.AreEqual(messageFromFirstServer, actualMessage);
        }

        [TestCase(MessageWithName), Order(1)]
        public void ChangeUsernameToNewOneFromMessageTest(string newNickName)
        {
            var mailRuMainMenuPage = new MailRuMainMenuPage(webDriver);
            var mailRuMailBoxPage = new MailRuMailBoxPage(webDriver);

            var messageText = mailRuMainMenuPage.SignIn().Login(UserCredentials.MailRuLogin, UserCredentials.Password)
                .ReadMessage(UserCredentials.YandexLogin);
            mailRuMailBoxPage.RenameUser(messageText);
            
            Assert.AreEqual(MessageWithName,mailRuMailBoxPage.GetUserNickName());
        }
    }
}