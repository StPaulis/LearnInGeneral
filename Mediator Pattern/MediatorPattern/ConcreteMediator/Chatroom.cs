using System.Collections.Generic;
using MediatorPattern.Colleague;
using MediatorPattern.Mediator;

namespace MediatorPattern.ConcreteMediator
{
    /// <inheritdoc />
    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>

    public class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> _participants =
            new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }

        public override void Send(
            string from, string to, string message)
        {
            var participant = _participants[to];

            participant?.Receive(@from, message);

            // if (participant != null)
            //{
            //    participant.Receive(from, message);
            //}
        }
    }
}