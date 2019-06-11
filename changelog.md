# Changelog
All notable changes will be documented here. Made by Anbcdeptrai all rights reserved.



## [Unreleased]



## [0.9.0] - 11/06/2019

### Added:
- UFO Trio prefab: with Movement and Auto-rotating behaviours.
  
- Dynamic Spawning Upgrades:
  - Now enemies can spawn in 3 directions and move accordingly: Straight and Left / Right.
  - Added a Function for spawning multi enemies continously.
  - Added a Function for determining spawning locations based on SPawn Direction (defined in Enemy base structure)
  - More spawn Points for each Directions.
  
- New Data properties for Enemy Units (defined in Data Structures): Difficulty and Direction.
  
- New Enemy: Brute Flyer: 
  - Movement: Fly in smooth curve from one edge of the screen to another.
  - Fragile: 1 - 2 Hp.
  - Fast.

- Bezier Drawer for testing Bezier Routes before applying.

### Changed:
- Changed the Prefab of Brute enemies to included the Bezier Movement curve landmarks, nested for easier Instantiating and Modifying in run-time.
- Slower Brute enemies's flying speed.
- Reduce Enemies HP and Spawn Rates in the beginning for Easier and Faster start.
- Changed the Curves of Brute Movement to a much smoother and longer routes.

### Removed:
- Old Brute Enemies prefabs.



## [0.8.2] - 10/06/2019

### Added:
- Bezier Curves Component:
  - Quadratic Curves Algorithms Supported: 3-points Curves.
  - Curved Line renderer.
  - Interpolative Steps Movement (Interpolant increasing and approaching 1 every steps (loops)) Coroutines (time and steps based): Calculate the Position on the Curves and Override the current position, step by step (interpolant increases a little every loop depended on the number of steps) each iterations - the more steps in the loop, the smoother the movements. 

- Brute Enemies Prefabs with Curved Movements and Visual Appearances.
- Side Spawn Points (with Collections of turning Coordinates for Curved Movements)

### Changed:
- Increased Upgrade Drop Rates of Enemies.

### Fixed:
- Fixed the laggy movement of the Bezier component (by increasing the number of move points and steps)



### [0.8.1] - 06/06/2019

### Added:
- Particle Visual and Sound effects when blocking for Shield.
- Added sfx for receivving Upgrades: Power up sounds.

### Changed:
- Increased Player shoot rate.
- Lower Enemies Numbers but increase normal Spawn rates.



## [0.8.0] - 04/06/2019

### Added:
- Player Booster Particle Effects.
- Player Appearing Animation (at the beginning)
- Strong Shots Impact Particle (with sounds) Effects (trigger on checking whether the enemy had collided with a strong shot or not) with distinct shooting and hitting sound effects.
- PlayerShield Upgrade:
  - Activating and Deactivating on receiving Upgrade Orbs (by Collision and Instantiating) through Player Scripts.
  - Functionality: Block off Enemies Shots and Contacts with Blocking COmponents.
  - Persist for a short time, then deactivate.
  - Visual Effects: change Player Renderer's Material Color to purple-ish and Particles effects on contact.
  - Sound Effects: on contacts.

- Endless Random Spawner that use the Spawn Manager interfaces to IMplement Routines for Spawning Enemies Randomly and Continously at Specific time rates, time ranges and Delays.


### Changed:
- Increase the HP of enemies.
- Added more Categorized Tags to Game objects.
- Player now chnage colors on Shielding to produce 3D-ish effects.
- Upgrade the Spawner to a Dynamic Random Spawning Manager using weights (the same mechanics as Random Loot Dropper):
  - An Enemy Collection: Comprised of Names, Object Prefabs for Pooling and Spawn Rates for Spawning Calculations.
  - Weight-Table Random Spawning System (follow the Weight Formula)
  - Spawn Functions that find Enemy entities using names and Instantiate them in specific, pre-built positions and rotations.

- Balanced the Upgrades Drop-rates and Enemy Spawn Rates.

### Fixed:
- The bugs where player colors won't changed on Shielding.
- The bugs where the Shield prefabs got destroyed on toggle (by Replacing Enabling with Instantiating)
- The bugs where only the Enemies with lowest spawn-rate are spawned (wrong condition checkings)

### Removed:
- The 3-UFO Strings Enemies Types.



## [0.7.0] - 27/05/2019

### Added:

- Upgrades now give scores.
  
- Added Blinking on-hit animations to enemies, both UFO and Trackers:
  - Coupled with Shaking animations and Impact SHockwave Sprite Particles for each of them.

- Implemented Player getting hit effects (when HP depleted):
  - Blinking and Shaking animations.
  - Cam Shake.
  - Hit SFX.
  
 - Added more sfx for shots and impacts (and explosions in between)

### Changed:

- Balanced the Game Controller's Wave Spawning rate.
- Upgrades of the same types won't stack and have to be fully went out before getting new.
- Increased the size of Enemy's Shot to be more intimidating.



## [0.6.3] - 23/05/2019

### Added:

- Player Upgrades Script Component: Checking for contact, the types of Upgrades, then apply them to player's features.
- Added a Shot Damage Component for Shot-type Objects:
  - HP Calculatioors and Damage Calculators now will use the Shot Damage COmponent to determine the HP damage received. 

### Changed: 

- Decreased Upgrade Drop Chances.
- Strong Shots now deal 2 damage to enemies (EnemyGettingShot).
- Strong shots will have a timer, balancing their OP powers.
- Increase enemies's HP: 
  - UFO: 2
  - Tracker: 4;

### Fixed:

- Fixed the bug where Upgrades don't spawn at where enemies get destroyed.
- Fixed the bug where strong shot deals only 1 dmg (fixing the HP Managers).
- Fixed the bugs where Strong Shot won't get Applied (can't recognized the tags)



## [0.6.2] - 22/05/2019

### Added:

- Implemented the Enemy Upgrade Dropper with Dynamic Collections and Random values:
  - Will activated on Destroyed by getting shot, has a chance to drop a random Upgrades (determined by the rarities of Upgrades).
- Implemented the Strong shot mechanic:
  - Strong shots prefab and Player's ability to shoot Strong shot (for a time).
  - Strong shot upgrade orb.
  - Dropper.

### Changed:

- Every Player related behaviour scripts now have the prefix 'Player-'

### Fixed:

- Fixed where Player Status doesn't fade when pause (by sorting canvas).



## [0.6.1] - 19/05/2019

### Added:
- Added Invincible Frames after damaged for Player (about 0.75s) (by stop Collision checkings on Conditions).

- Added UI and VFX for Player's HP.

### Fixed:

- Fixed the bug where player object got destroyed on Invincibility frames.
  


## [0.6.0] - 17/05/2019

### Added:

- Added new types of enemies replacing old enemies and hazards:
	+ A UFO enemies floating and maneuvering toward the bottom of the screen.
	+ A Red Battleship Tracking and SHooting at player's Direction in real-time.

- Added HP Manager for Enemies and Player:
  
- Added Invincible Time for enemies a short time (0.5s) at their spawns (so they won't be destroyed before entering the screen)
  
	
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

- Changed the Enemies's color palette to Main Red Palette!

### Fixed:

- Fixed the bugs where the enemies can be shot even before they spawned.
- Fixed the bugs where animations on hit will not play, and enemies become indestructible. 
- Fixed SPawning checking always return false.
- Fixed Buggy and Irresponsive HP UI Animations (caused by slow Trigger values).

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

