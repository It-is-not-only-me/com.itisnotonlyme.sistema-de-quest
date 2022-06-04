using ItIsNotOnlyMe.SistemaDeQuest;

public class AutomataFinitoPrueba : IEstado
{
    private uint _estado;
    private uint _cantidadDeEstados;

    public AutomataFinitoPrueba(uint cantidadDeEstados)
    {
        _estado = 0;
        _cantidadDeEstados = cantidadDeEstados;
    }

    public void Actualizar(IAccion accion)
    {
        if (Finalizado())
            return;
        _estado++; 
    }

    public bool EnEsteEstado(IEstado estado)
    {
        AutomataFinitoPrueba automata = estado as AutomataFinitoPrueba;
        return _estado <= automata._estado;
    }

    public bool Finalizado()
    {
        return _estado == _cantidadDeEstados;
    }
}
