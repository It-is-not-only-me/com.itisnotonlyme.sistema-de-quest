using System;
using System.Collections.Generic;

namespace ItIsNotOnlyMe.SistemaDeQuest
{
    public class Trigger : ITrigger
    {
        private List<Action> _eventosAlActivar;

        public Trigger()
        {
            _eventosAlActivar = new List<Action>();
        }

        public void Activar()
        {
            foreach (Action iniciarQuest in _eventosAlActivar)
                iniciarQuest?.Invoke();
        }

        public void Avisar(Action questIniciar)
        {
            _eventosAlActivar.Add(questIniciar);
        }
    }
}