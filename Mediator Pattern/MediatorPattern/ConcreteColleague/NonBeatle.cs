using System;
using MediatorPattern.Colleague;

namespace MediatorPattern.ConcreteColleague
{
    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    public class NonBeatle : Participant
    {
        // Constructor
        public NonBeatle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}