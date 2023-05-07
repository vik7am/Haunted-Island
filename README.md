# Haunted Island

Haunted Island is a Horror first person game where you are stuck on a haunted island where ghosts patroll at night and you must find a way to eliminate ghosts and escape from the island.

<img src= "https://i.imgur.com/JvEZfd7.png">

### Design Patterns Used
1. Singleton - Added Singleton classes to create Game nad UI manager.
2. State Machine - It used to define enemy movement states like idle, patrolling and chasing.

### Features
1. First person for immersion - First person view make game more scary and immersive.
2. Dark environment - You have to navigate the island using a flashlight in tatally dark environment.
3. Enemy AI - Enemy and patrolls in random directions usign NavmeshAgent and chases player if it's within range. .
4. Campfire - Campfire provides players a safe area when enemies will not enter.
5. Inventory System - Player can collect and drop from it's inventory.

### Best Practices Used
1. Proper naming convention for methods and variables.
2. Proper use of abstract class and interface for abstraction.
3. Following the single responsibility principle.
4. Caching data to reduce function calls.
5. Enums to improve code readability.
6. Generic classes to reduce code repetition.
