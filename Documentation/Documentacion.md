# Documentacion
---

Este sistema esta estructurado con 4 interfaces:
 * IQuest
 * ITrigger
 * IEstado
 * IAccion

Tanto IEstado como IAccion estan pensadas para que el usuario final tenga control de como manejarlas, por eso no hay una clase concreta de estas. A diferencia de estas dos esta IQuest que si tiene una clase concreta y es la esperada para usar pero obviamente la interfaz permite que se pueda usar cualquiera que el usuario vaya a implementar. Por ultimo esta ITrigger que es el caso intermedio, tiene una implementacion pero en una ambiente de desarrollo de juegos le faltan cosas, por lo que lo esperado de esta clase es implementar una clase que herede de la clase concreta y expanda desde ahi.

### IAccion
---

Esta interfaz viene a representar cada una de las acciones que pueden suceder en el juego y pueden ser dato para avanzar alguna quest. Pueden ser tan simples como activarse al matar enemigos, o pasar un cierto tiempo desde que se empezo una quest, o la accion que sea, por eso es tan ambiguo su implementacion. 

Esto esta hecho de esta forma pensando en la interfaz IEstado, para que se implementen al conjunto (con una gran relacion entre las mismas). Una forma de pensarlo es que los estados tienen solo una accion que haga que avance, o tal vez se puede pensar que si la categoria de accion es la misma entonces avanzar ese estado.

### IEstado
---

La idea con esta interfaz es que generalmente va a ser un automata finito (state machine) que siga el progreso de la quest en paralelo a las acciones que vaya haciendo el jugador. No me parece el mejor diseño que el conocimiento del jugador este vinculado a la quest por eso mismo es toda una clase aparte que puede usarse en otros lados y no estar hardcodeado en la interfaz IQuest.

### ITrigger y IQuest
---

Ambas estan muy vinculadas entre si, los triggers inicializan la quest, por eso mismo son tan simples, para que se pueda tener muchas formas de inicializar una quest. La quest actualmente sirve para trackear lo que el jugador haga, en si no tiene mucho por lo especifico que es para cada juego. 

### Idea de implementacion
---

Lo ideal seria hacer, como mencione antes, un IEstado como state machine, que mande una señal cada vez que se avanza. Los triggers siendo colliders, npc dando informacion, o cualquier accion. Y las acciones las haria tan granular como pudiera, entrar a un lugar, hablar con npc, destruir algo, construir algo, pasar tanto tiempo desde que hiciste una accion pero no hiciste otra.
