using System;
using MediatorPattern.Colleague;

namespace MediatorPattern.ConcreteColleague
{
    public class SemiBeatle : Participant
    {
        public SemiBeatle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Semi-Beatle: ");
            base.Receive(from, message);
        }

    }
}