# ZigZag Runner - Juego 3D

ZigZag Runner es un videojuego en 3D desarrollado en Unity donde el jugador controla un personaje que corre a lo largo de un camino en forma de zigzag. El jugador debe presionar la tecla `Espacio` para cambiar la dirección del personaje y evitar que caiga. El camino se genera aleatoriamente a medida que el personaje avanza, aumentando la dificultad con el tiempo. El personaje también realiza movimientos expresivos mientras corre.

## Características Principales
- Control de personaje simple con una sola tecla (Espacio).
- Camino en zigzag que se genera de forma aleatoria.
- Animaciones expresivas del personaje durante la carrera.
- Incremento gradual de la dificultad con la velocidad del juego.
- Sistema de puntuación basado en la distancia recorrida.

## Requisitos del Sistema
- Unity 2021.3 o superior
- Visual Studio 2019 o superior con soporte para C#
- Sistema operativo: Windows 10/11, macOS 10.15+, o Linux

## Estructura del Proyecto

- **Assets/**: Contiene todos los recursos del juego, incluyendo scripts, modelos, texturas y escenas.
- **Scripts/**: Código fuente en C# que controla la lógica del juego.
- **Scenes/**: Escenas de Unity donde se desarrolla el juego.
- **Prefabs/**: Objetos preconfigurados que se pueden reutilizar en las escenas, como las secciones del camino y el personaje.

## Instrucciones de Uso

- **Girar**: Presiona la tecla `Espacio` para hacer que el personaje gire y continúe corriendo en un nuevo segmento del camino.
- **Evita Caer**: Gira en el momento adecuado para evitar que el personaje caiga del borde del camino.
