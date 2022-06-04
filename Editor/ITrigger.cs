using System;

namespace ItIsNotOnlyMe.SistemaDeQuest
{
    public interface ITrigger
    {
        public void Avisar(Action questIniciar);

        public void Activar();
    }
}