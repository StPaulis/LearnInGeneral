using System;
using MediatorPattern.ConcreteMediator;

namespace MediatorPattern.Colleague
{
    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    public class Participant
    {
        // Constructor
        public Participant(string name)
        {
            this.Name = name;
        }

        // Gets participant name
        public string Name { get; }

        // Gets chatroom
        public Chatroom Chatroom { set; get; }

        // Sends message to given participant
        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }
        // Receives message from given participant
        public virtual void Receive(
            string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
                from, Name, message);
        }
    }
}