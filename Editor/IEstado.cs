namespace ItIsNotOnlyMe.SistemaDeQuest
{
    public interface IEstado
    {
        public void Actualizar(IAccion accion);

        public bool EnEsteEstado(IEstado estado);

        public bool Finalizado();
    }
}