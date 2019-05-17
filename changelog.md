# Changelog
All notable changes will be documented here.


## [Unreleased]


## [0.6.0] - 17/05/2019

### Added:

- Added new types of enemies replacing old enemies and hazards:
	+ A UFO enemies floating and maneuvering toward the bottom of the screen.
	+ A Red Battleship Tracking and SHooting at player's Direction in real-time.

- Added HP Manager for Enemies and Player.

- Added UI and VFX for Player's HP.

- Added Invincible Time for enemies a short time at their spawns (so they won't be destroyed before entering the screen)
  
	
### Changed:

- Reduce spanw rates and enemies' speed for balanced difficulty.

- Refactor the Code to be more Modular, Reusable and Single-responsible:
	+ Every scripts now followed a naming convention depended on their targeted objects. E.g every enemy's behaviours scritps have 'Enemy-' as prefixes.
	+ Break the Controller scripts into Smaller, more Focused and easy to understand Components.

- Implemented the HP Mechanic into the Script Base:
	+ Enemies Shooting and Contacting will deplete player's HP.
	+ Game Over when out-of-HP.
	
- UFO Enemies's Movements: no Random values, they now maneuver in a consistent and similar patterns.

- Smaller Sprites Scales for player and enemies in general. Bigger Bullet Scales for Clearer view
  
- Player ship:
	- no longer move vertically and will not rotate when moving.
	- Move faster and shoot faster.
	- Change the player color palette for clearer views (white-green).

### Fixed:

- Fixed the bugs where the enemies can be shot even before they spawned.
- Fixed the bugs where animations on hit will not play, and enemies become indestructible. 
- Fixed SPawning checking always return false.

### Removed:

- Outdated scripts and Prefabs.
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

