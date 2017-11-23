using System;
using MediatorPattern.Colleague;
using MediatorPattern.ConcreteColleague;
using MediatorPattern.ConcreteMediator;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {


            // Create chatroom

            var chatroom = new Chatroom();

            // Create participants and register them
            Participant george = new Beatle("George");
            Participant paul = new Beatle("Paul");
            Participant ringo = new Beatle("Ringo");
            Participant john = new Beatle("John");
            Participant yoko = new NonBeatle("Yoko");
            Participant stamatis = new SemiBeatle("Stamatis");

            chatroom.Register(george);
            chatroom.Register(paul);
            chatroom.Register(ringo);
            chatroom.Register(john);
            chatroom.Register(yoko);
            chatroom.Register(stamatis);

            // Chatting participants

            yoko.Send("John", "Hi John!");
            paul.Send("Ringo", "All you need is love");
            ringo.Send("George", "My sweet Lord");
            paul.Send("John", "Can't buy me love");
            john.Send("Yoko", "My sweet love");
            stamatis.Send("Yoko", "Ono?");
            yoko.Send("Stamatis", "Yeap");

            // Wait for user
            Console.WriteLine("\nPress a key to exit..." );
            Console.ReadKey();
        }
    }
}