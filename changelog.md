# Changelog
All notable changes will be documented here.


## [Unreleased]

### Added:

- Red Enemies's HP Features and On-hit animations.

- Modular and Dynamic Approach on Enemy Spawn Manager: the Spawn Manager was break down into 2 smaller components:
	+ The Main Manager: storing Data for Enemies, enemies types and providing Spawning + utility methods (the Base Data and Methods)
	+ Spawners controlling the wave spawning schedule, random spawn rates and waves data (doing the real Spawning)
    	+ Intergrate and Implement the Spawn Manager with the new enemies (currently having their own spawn ratios) in the Endless Spawner:
          - Easy
          - Normal
          - 3 Easy

- UFO Easy Enemies prefabs:
  - SImilar Effects to the old Red Enemy.
  - Behaviours:
    - Move and Maneuver in a consistent manners (based on the old Red Enemy Prefab)
    - Auto Self-rotating.

- UFO String prefab: consists of 3 UFO enemies in a column, spawning and moving simutaneously.

- Add a bool control value for on hit Animation on Getting Shot Component Script: will not play on hit animatioons if set to false.
  
- Red enemies are now Normal in difficulty, with the new behaviours as follow: 
  - When instantiated, move forward along the y axis for a random amount of time.
  - Then turn toward the current player position (using Relative Quaternion) and spawn shoot in that direction.
  - DOuble Auto-shooting follow the facing directions before every updated rotations.
  - The rotations and shooting directions are updated and applied continously every set amount of time (depend on how hard you want the enemies to be)

- After spawned, the enemies have a short invincible time so they won't be destroyed off-screen.

	
### Changed:

- Reduce spanw rates and enemies' speed for balanced difficulty.

- Break and Tweak the Controllers script into 3 smaller, fully referenced and intergrated modules:
	+ the Spawn Manager.
	+ The Score Manager.
	+ The Game Over Manager.
  
- Break and Reimplement the Enemy Controller into 3 Module (Script Components):
	+ The Player Contact Processor: Player Destroying and Game Over Trigger.
	+ The On-Shot Processor: Deal with HP, On-hit, and Destroyed Effects.
	+ The HP Manager: This Modules Determine and Manipulate HP: Can be intergrated Modularily as Components for virtually any Objects in the Game.
	
- Refactored the Code t be more flexible and reusable.

- Enemies's Movements: no Random values, they now maneuver in a consistent and similar patterns.

- Smaller Sprites Scales for player and enemies in general.
  
- Bigger Bullets scales.
  
- Player ship:
  - no longer rotate when moving.
  - Move faster and shoot faster.

- Change the player color palette for clearer views (white-green).

### Fixed:

- Fixed the bugs where the enemies can be shot even before they spawned.
- Fixed the bugs where animations on hit will not play, and enemies become indestructible. 
- Fixed SPawning checking always return false.

### Removed:

- Outdated scripts.
- The old Spawning and Contact systems.


## [0.5.0] - 23/04/2019

### Added:
- Custom TextMesh Fonts.
- A UFO Enemy Sprite to replace meteor later.
- Auto Shooting for the Player and red enemies.
- Stage Controller (child of the game controller) for upcoming Changes.
### Changed:
- More OC Arts for explosion particle effects!
- Changed UI templates and fonts for space theme feels.
- Changed the Title to 'Spark Invader'
- Decrease Enemy Spawn Rates.
- Split the player controller script into moving and shotting components.
- Changed the spawn rate and shooting rate of enemies.
### Update:
- Update the TextmeshPro Packages.
- Add sfx to the player's shot prefab.
### Fixed:
- Fixed the bug where the game over animation plays twice.
- Fixed the Alignments of Some UI Elements.
- Fixed the bugs where the explosions won't play (because of 3D and 2D Particles incompatibility).
### Remove:
- Remove the Meteors.
- Remove Enemy Weapon Script.


## [0.4.0] - 11/04/2019

### Added:
- Master Volume Mixer.
- Volume Slider in Option Menu.
- Graphics Dropdown Picker.
- Scripts for Option Settings.
- Script for Graphic Setting.
### Changed:
- Player and Enemy SPaceship sprites are now all OC arts.
### Fixed:
- Fixed the Buggy Graphic Dropdown list items.


## [0.3.0] - 2019-3-27
### Added:
- Highscore;
- New Highscore Message with Animation (Layered on Game Over Animations) and Associated Sounds (Component and Script)
- Highscore Icon and Menu on Main Menu UI.
- Reset Highscore Button in the Highscore UI Panel.


## [0.2.0] - 2019-03-22
### Added:
- Functional Pause Menu UI and Scripts.
### Changed
- Reduce the falling speed of meteors to -6.
- Updated the explosion color for grey meteor.


## [0.1.0] - 2019-03-22
### Added
- New enemy: spaceships that can shoot and maneuver randomly through coroutines.
- New sfx for enemy ships's explosion.
- Title screen music.
### Changed
- Reduce the spawn rate to 10 hazard objects per wave.
- Increase the falling speed of meteors to -7.
- Now every hazards have their own score value, updating with scripts.
- Refactor the scripts and merge the button functionalities into one single handler class.

