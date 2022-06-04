using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeQuest
{
    public interface IQuest
    {
        public void AgregarTriggers(ITrigger trigger);

        public void AgregarEstado(IEstado estado);

        public void Avanzar(IAccion accion);

        public bool EnEsteEstado(IEstado estado);

        public bool Terminado();
    }
}