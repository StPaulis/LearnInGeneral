using Microsoft.VisualStudio.TestTools.UnitTesting;
using  MediatorPattern;
using MediatorPattern.Colleague;
using MediatorPattern.ConcreteColleague;
using MediatorPattern.ConcreteMediator;

namespace MediatorPatternTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var chatroom = new Chatroom();

            Participant george = new Beatle("George");

            chatroom.Register(george);
            george.Send("George", "My sweet Lord");

            
            Assert.IsTrue(george.Chatroom == chatroom);
        }
    }
}
