# GAME 351 Assignment 3 - README
# Team Members: Robin Zheng, Cougar Bellinger, Minh Le, MiLee Vogel
# OVERVIEW
A first-person action game set in the American Wild West called “A Palmful of Paper Money”, the game will feature a 19th century mining town, cacti, folksy music, explosives, 
and a few bandits (non-player characters – NPCs). Please develop a pseudo-game 
# Implemented Features
### Core Features
2. **Player can Kick:**
   Apply character to click keyboard space to kick by animator.
4. **Shoot at Targets**
   Player shooting:
   Target types:
   Barrels: Full of TNT, explode spectacularly when hit using a particle system. Delete the barrel object and replace with debris on explosion finish.
   Bandits: Play death animation with the bandit's animation controller when hit.
   Bullet firing: Press 'F' key. Spawn bullet prefabs and send along player's line of sight, detect collisions.
   Fire rate limit: 1 shot per second.
5. **Dynamic Soundtrack:**
   a) Suspense Sound: player gets near the Supply Store
      Fight Sound: player gets start shooting
      Default Sound: The other two sounds are not played.
   b) Five Foley effects: Footsteps, gunshots, explosions, subtle wind ambience, and bandit pain/death sounds (when shot)
   c) Unique Taunts: Each bandit direct 2 - 3 taunts to the players

### Core Features
7. **Monsoon Weather**
   The dark clouds, rain and lightning were created through the particle system. The wind was also added with the sounds of rain and lightning downloaded from the asset store, and the wind sound used the template sound. The materials were all colored by myself without using the downloaded materials or prefabs.

# Installation Instructions

1. **Setup Unity Project**
   - Launch Unity Hub and select "Create new project".
   - Ensure all necessary packages and plugins used in the project are installed.
   - Open the "Package Manager" in the Unity Editor and verify all packages are correctly installed.

2. **Import Project Files**
   - Unzip the project folder and open it in Unity.

3. **Rendering Pipeline**
   - This project uses Unity's Universal Rendering Pipeline (URP).
### Assets

   **List of Assets**
   -  The project includes a mix of provided and downloaded assets from the Unity Asset Store which include the following:Animations, Audio, BasicBandit, BloodDecalsAndRffects, Controllers, Wastern, Metal_Barrels, Scenes, True Explosions, Tutoriallnfo.
