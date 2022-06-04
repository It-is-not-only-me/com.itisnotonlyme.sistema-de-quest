using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
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

public class AccionPrueba : IAccion
{

}

public class QuestTest
{
    private IAccion _accionBasica = new AccionPrueba();


    [Test]
    public void Test01QuestNoInicializadaNoEstaTerminada()
    {
        IQuest quest = new Quest();

        Assert.IsFalse(quest.Terminado());
    }

    [Test]
    public void Test02QuestConUnEstadoTerminadoIgualYNoInicializadoNoEstaTerminada()
    {
        IQuest quest = new Quest();
        IEstado estado = new AutomataFinitoPrueba(1);

        estado.Actualizar(_accionBasica);
        quest.AgregarEstado(estado);

        Assert.IsTrue(estado.Finalizado());
        Assert.IsFalse(quest.Terminado());
    }

    [Test]
    public void Test03QuestConUnTriggerPeroNoLlamadoYUnEstadoTerminadoNoEstaTerminada()
    {
        IQuest quest = new Quest();
        IEstado estado = new AutomataFinitoPrueba(1);
        ITrigger trigger = new Trigger();

        estado.Actualizar(_accionBasica);
        quest.AgregarTriggers(trigger);
        quest.AgregarEstado(estado);

        Assert.IsFalse(quest.Terminado());
    }

    [Test]
    public void Test04QuestInicializadoYSinEstadoEstaTerminada()
    {
        IQuest quest = new Quest();
        ITrigger trigger = new Trigger();

        quest.AgregarTriggers(trigger);
        trigger.Activar();

        Assert.IsTrue(quest.Terminado());
    }

    [Test]
    public void Test05QuestInicializadaYConUnEstadoNoFinalizadoNoEstaTerminada()
    {
        IQuest quest = new Quest();
        IEstado estado = new AutomataFinitoPrueba(1);
        ITrigger trigger = new Trigger();

        quest.AgregarTriggers(trigger);
        quest.AgregarEstado(estado);
        trigger.Activar();

        Assert.IsFalse(quest.Terminado());
    }

    [Test]
    public void Test06QuestInicializadaYConUnEstadoFinalizadoEstaTerminada()
    {
        IQuest quest = new Quest();
        IEstado estado = new AutomataFinitoPrueba(1);
        ITrigger trigger = new Trigger();

        quest.AgregarTriggers(trigger);
        quest.AgregarEstado(estado);
        trigger.Activar();
        quest.Avanzar(_accionBasica);

        Assert.IsTrue(quest.Terminado());
    }

    [Test]
    public void Test07QuestInicializadaYConUnEstadoFinalizadoYOtroNoNoEstaTerminada()
    {
        IQuest quest = new Quest();
        IEstado estadoTerminado = new AutomataFinitoPrueba(1);
        IEstado estadoSinTerminar = new AutomataFinitoPrueba(1);
        ITrigger trigger = new Trigger();

        quest.AgregarTriggers(trigger);
        quest.AgregarEstado(estadoTerminado);
        trigger.Activar();

        quest.Avanzar(_accionBasica);
        quest.AgregarEstado(estadoSinTerminar);

        Assert.IsFalse(quest.Terminado());
    }

    [Test]
    public void Test08QuestInicializadaYConDosEstadosFinalizadosEstaTerminada()
    {
        IQuest quest = new Quest();
        IEstado estadoTerminado = new AutomataFinitoPrueba(1);
        IEstado estadoTerminado2 = new AutomataFinitoPrueba(1);
        ITrigger trigger = new Trigger();

        quest.AgregarTriggers(trigger);
        quest.AgregarEstado(estadoTerminado);
        quest.AgregarEstado(estadoTerminado2);

        trigger.Activar();
        quest.Avanzar(_accionBasica);

        Assert.IsTrue(quest.Terminado());
    }
}
