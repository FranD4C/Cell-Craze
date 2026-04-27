Cell Craze 

Género: Plataformero, Sigilo

Objetivo: Llegar a la meta evitando obstáculos y ser detectado por los enemigos, los cuales buscaran atacarte para matarte.

IA Implementada: FSM (Finite State Machine), el enemigo cuenta con un campo de visión y 3 comportamientos: 
. Patrulla: El enemigo gira y/o se mueve intentando detectar al jugador, lograndolo si este entra en su campo de visión.
. Perseguir: Al detectar al jugador, el enemigo comenzara a perseguirlo, acercándose a el. Esto se detiene si el jugador se esconde detras de una pared o estructura, provocando que el enemigo deje de perseguir al jugador y vuelva al estado de Patrulla.
. Atacar: El enemigo al entrar en contacto con el jugador comenzará a atacarlo.

Controles: Movimiento - WASD / Salto - Barra Espaciadora
