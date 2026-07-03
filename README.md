# Jetpack Joyride Replica

A Unity-based Jetpack Joyride-style side-scrolling game project developed to practice clean gameplay architecture, reusable systems, object pooling, procedural level flow, and mobile game development patterns.

The project focuses on building core endless runner mechanics step by step with maintainable and scalable code.

## Project Goal

The main goal of this project is to recreate the core feel of Jetpack Joyride while improving my Unity and C# skills through clean architecture, modular systems, and professional Git workflow.

This project is not only a gameplay prototype, but also a practice project for writing reusable, readable, and extensible game systems.

## Current Features

- Player movement with jetpack-style vertical control
- Player finite state machine
- Input system abstraction
- Dependency injection with VContainer
- Camera follow system
- Collision and death flow
- Endless level chunk spawning
- Obstacle spawning system
- Object pooling for obstacles
- Object pooling for level chunks
- Parallax background system
- Collectible coin system
- Coin object pooling
- ScriptableObject-based coin pattern system
- Coin pattern spawning
- Runtime cleanup for spawned objects

## Technologies Used

- Unity
- C#
- Rider
- Git & GitHub
- VContainer
- ScriptableObjects
- Object Pooling
- Event-driven programming
- Component-based architecture

## Architecture & Code Approach

The project is developed with a modular structure. Each system has its own responsibility and is kept separate from unrelated gameplay logic.

Some of the main architectural ideas used in the project:

- **Finite State Machine** for player states
- **InputService** to separate input logic from player behavior
- **Dependency Injection** with VContainer
- **Object Pooling** to avoid unnecessary Instantiate/Destroy calls during gameplay
- **ScriptableObjects** for reusable coin pattern data
- **Event-based communication** for collectible interactions
- **Single Responsibility Principle** to keep classes focused and maintainable

## Main Systems

### Player System

The player system is built around a finite state machine. Movement, input, collision, and death logic are separated into different responsibilities to keep the player code clean and easier to extend.

### Level System

The level system spawns chunks ahead of the player and cleans up old chunks behind the camera/player. Chunk pooling is used to reduce runtime allocation and improve performance.

### Obstacle System

Obstacles are spawned ahead of the player and returned to the pool after they are no longer needed. This keeps the endless runner flow efficient and avoids constant object creation.

### Collectible System

Coins are managed through a dedicated coin pool. Coin layouts are defined with ScriptableObject-based patterns, allowing different shapes such as lines, rising paths, diamonds, and custom collectible formations.

The coin system is designed so that:

- CoinPool manages coin reuse
- CoinPattern stores pattern data
- CoinPatternSpawner places patterns in the level
- Coin events notify the system when a coin is collected

### Parallax System

The background uses a parallax layer and repeater system to create depth and continuous scrolling visuals.

## Git Workflow

The project follows a feature branch workflow:

```text
feature branch -> develop merge
