using System;
using System.Collections.Generic;

namespace ItIsNotOnlyMe.SistemaDeQuest
{
    public class Quest : IQuest
    {
        private event Action _iniciar;
        private List<IEstado> _estados;
        private bool _inicializado;

        public Quest()
        {
            _estados = new List<IEstado>();
            _inicializado = false;
            _iniciar += Iniciar;
        }

        ~Quest()
        {
            if (!_inicializado)
                _iniciar -= Iniciar;
        }

        private void Iniciar()
        {
            _inicializado = true;
            _iniciar -= Iniciar;
        }

        public void AgregarEstado(IEstado estado)
        {
            _estados.Add(estado);
        }

        public void AgregarTriggers(ITrigger trigger)
        {
            trigger.Avisar(_iniciar);
        }

        public void Avanzar(IAccion accion)
        {
            if (!_inicializado)
                return;

            _estados.ForEach(automata => automata.Actualizar(accion));
        }

        public bool EnEsteEstado(IEstado estado)
        {
            if (!_inicializado)
                return false;

            bool estadoLogrado = false;

            for (int i = 0; i < _estados.Count && !estadoLogrado; i++)
                estadoLogrado = _estados[i].EnEsteEstado(estado);

            return estadoLogrado;
        }

        public bool Terminado()
        {
            if (!_inicializado)
                return false;

            bool Finalizado = true;

            for (int i = 0; i < _estados.Count && Finalizado; i++)
                Finalizado = _estados[i].Finalizado();

            return Finalizado;
        }
    }
}