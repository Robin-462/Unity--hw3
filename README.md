# GAME 351 Assignment 3 - README
# Team Members: Robin Zheng, Cougar Bellinger, Minh Le, MiLee Vogel
# OVERVIEW
A first-person action game set in the American Wild West called “A Palmful of Paper Money”, the game will feature a 19th century mining town, cacti, folksy music, explosives, 
and a few bandits (non-player characters – NPCs). Please develop a pseudo-game 
# Implemented Features
### Core Features
1. **Cutscene Camera & Movement**
   - Implemented a cutscene camera in the initial start of the game that lasts for a total of 52 seconds
   - Allow for player to be able to press the "esc" key at any time to terminate it and go to the beginning of the game
   - At the end of the cutscene, transitions to 3rd person camera that is centered on the character
   - Apply character to move through the use of clicking the W, A, S, D keys
3. **Player can Kick:**
   - Apply character to click keyboard space to kick by animator.
4. **Shoot at Targets** 
   - Two types of targets
      - Barrels: Full of TNT, explode spectacularly when hit using a particle system. Delete the barrel object and replace with debris on explosion finish.
      - Bandits: Play death animation with the bandit's animation controller when hit.
   - Bullet firing: Press 'F' key. Spawn bullet prefabs and send along player's line of sight, detect collisions.
   - Fire rate limit: 1 shot per second.
6. **Dynamic Soundtrack:**
   - Suspense Sound: player gets near the Supply Store
   - Fight Sound: player gets start shooting
   - Default Sound: The other two sounds are not played and default background music is played
   - Five Foley effects: Footsteps, gunshots, explosions, subtle wind ambience, and bandit pain/death sounds (when shot)
   - Unique Taunts: Each bandit direct 2 - 3 taunts to the players

### Core Features
7. **Monsoon Weather**
   - The dark clouds, rain and lightning were created through the particle system
   - Wind was also added with the sounds of rain and lightning downloaded from the asset store, and the wind sound used the template sound.
   - The materials were all colored by our team without using the downloaded materials or prefabs.

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
   -  The project includes a mix of provided and downloaded assets from the Unity Asset Store which include the following: Animations, Audio, BasicBandit, BloodDecalsAndRffects, Controllers, Wastern, Metal_Barrels, Scenes, True Explosions, Tutoriallnfo.
