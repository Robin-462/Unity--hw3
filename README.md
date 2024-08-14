# GAME 351 Assignment 3 - README
# Team Members: Robin Zheng, Cougar Bellinger, Minh Le, MiLee Vogel
# OVERVIEW
A first-person action game set in the American Wild West called “A Palmful of Paper Money”, the game will feature a 19th century mining town, cacti, folksy music, explosives, 
and a few bandits (non-player characters – NPCs). Please develop a pseudo-game 
# Implemented Features
### Core Features
3. **Shoot at Targets**
   The player’s avatar should be able to shoot at least two types of targets,which include barrels and bandits. Bullets should be fired with the ‘F’ key. Spawn bullet
   prefabs and send them down range along the player’s line of sight, detecting collisions with game objects. Barrels are full of TNT and should explode spectacularly when hit. Use a particle
   system to simulate the explosion; delete the barrel game object and replace it with debris as the explosion finishes (broken barrel debris are provided for you). When a bandit is hit, you
   should play a death animation with the bandit’s animation controller. Limit the player’s rate of fire to 1 shot per second. 
