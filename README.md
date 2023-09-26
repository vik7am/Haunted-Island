# Haunted Island

Haunted Island is a Horror first-person game where you are stuck on a haunted island where ghosts patrol at night and you must find a way to eliminate ghosts and escape from the island.

<img src= "https://i.imgur.com/FrZm7C6.png">

[Click Here](https://vik7am.itch.io/haunted-island) to play WebGL Build.

### Design Patterns Used
1. Singleton - Added Singleton classes to create GameManager.
2. State Machine - It is used to define enemy movement states like idle, patrolling, and roaming.
3. Observer Pattern - C# Events are used to broadcast and inform all its subscribers to perform their actions accordingly.

### Features
1. First person for immersion - First-person view makes the game more scary and immersive.
2. Dark environment - Whenever you go near the ghost or hold its bone you have to navigate the island using a flashlight in a dark environment.
3. Enemy AI - Ghost patrols around its bones and roams in random directions using NavmeshAgent and kills the player if he gets too close.
4. Campfire - Campfires can be used to burn bones.
5. Bones - Can be picked up and dropped by the player and make the environment dark while the player is holding it. 
5. Inventory System - The player can collect and drop items from their inventory.
6. Drowning - The player will drown if he jumps into the deep water.

### Best Practices Used
1. Proper naming convention for methods and variables.
2. Proper use of abstract class and interface for abstraction.
3. Following the single responsibility principle.
4. Caching data to reduce function calls.
5. Enums to improve code readability.
6. Generic classes to reduce code repetition.

### Gameplay Screenshots
<p float="left">
<img src= "https://i.imgur.com/ewsZo0x.jpg" width="48%">
<img src= "https://i.imgur.com/PuoxWu4.jpg" width="48%">
<img src= "https://i.imgur.com/49uLEkE.jpg" width="48%">
<img src= "https://i.imgur.com/6ZatL0v.jpg" width="48%">
<img src= "https://i.imgur.com/KJIUACv.jpg" width="48%">
<img src= "https://i.imgur.com/uOsy8Sn.jpg" width="48%">
<img src= "https://i.imgur.com/SIzMHVw.jpg" width="48%">
<img src= "https://i.imgur.com/BPbq1YE.jpg" width="48%"> 
</p>   
