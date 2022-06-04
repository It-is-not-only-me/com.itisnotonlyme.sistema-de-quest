# Sistema de Quest

La idea general de una quest se puede separar en 3 bloques
 * Las acciones que inicializan una quest
 * El estado de la quest
 * Las acciones hechas 

### Triggers
---
Comunmente son dadas por npc, pero de esta forma estan generalizadas para que las quest empiece por multitud de acciones o una. 

### Estado
El estado, ya sea un maquina de estado o un arbol, va a ser la forma de seguir el proceso de esta quest. 
Tambien se va a poder preguntar por el estado, ya sea verificar si ya paso o saber el estado actual de la quest.

### Acciones
Las acciones son lo que avanza la quest, puede o no ser relevantes para la quest en cuestion pero son todas las acciones que hace el jugador, o se generan en el mundo.

Por ejemplo, si tenemos una quest de salvar el mundo, en una de esas tenemos dos arboles de estados que representan la salvacion o la destruccion. Si en este juego, podemos lograr que los ciudadanos colaboren para salvar el mundo, eso es una accion que avanzaria el arbol de estado de la salvacion, pero si empiezan a discutir, avanzaria el arbol de estado de la destruccion.