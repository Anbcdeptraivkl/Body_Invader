# CHANGELOG

* All notable changes in the code base will be documented here.
* Made by Ho Thai An - Anbcdeptrai with Love and Care. All the Arts and Scripts are Self-made by Me. If you ever have the chance to obtain them please do not use them for commercial purpose without my Consents.
* All rights reserved.


## [Unreleased]

### Added
- How-to Play Tutorials
- Shop UI
  - Shop Items Data and UIs
  - Hovering and Selecting Effects
  - Buying Selecting Items
  - Access from Level Selection Screen (or right after you Complete a Level => Move on to the Next Level to Fight Immediately, Roguelike Style!)

### Changed
- Swapped more Sprites and Animations with Pixel Arts
- Shop data is now JSON format and will be saved on the Client Computer

### Fixed
- Fixed the Audio Import Settings
- Removed Obsolete Elements and Scripts
- Fixed the Level Panel UIs
- Fixed the Titan Over-movement


## [1.1.0] - 8/9/2020

### Added
- JSON files for storing and Reading Configs (with JsonUtility Library)
  - Player 
  - Enemy COnfigs (for all Types of Enemies)
- Config Objects for Storing and Assigning JSON Data
- Boss Manta
  + Movements
  + Attacks
- Boss Dying Explosions Effects and Winning Sequences
- Better Controlled Repeated Scrolling, more Pleasing Sea Background
- Charge Weapon and Weapon Upgrades Mechanics (by gaining charges with defeating Enemies)
  - New Weapon Upgrades: Double Shots
  - Charge Bar representing Weapon Upgrade Progress
- Updated In-game Effects for Enemies
- Updated Menu UIs and Elements into Puxel Arts

### Changed
- Overhauled Scripts Structures
  - Merging Enemy COmponent into a Single Concentrated Component shared between all Types of Enemies for easier creating Processes (excluding the Unique Movements and Behaviours of each Types: they got their own Unique Components)
  - Same for the Player COmponents (excluding the Missile Launcher since it is a standalone Upgrades and should not be merged into the Main Component)
- COnfigurations and Stats for Shared Components are Serialized and Parsed as JSON files for each types of Players and Enemies
- Changed In-game Menu Elements into Self-made Pixel Arts that are better for the theme of the game
- Changed Entities and Effects to Pixel Arts

### Fixed
- Fixed Boss Manta Movements and Collisions Detecting
  - No more detecting collisions when destructing
- Player no longer can be controlled during Winning Sequences (Boss destructing)
- Fixed Overflow Layouts for Longer Devices (adxing Black Boxes the SIde of the Screen)
- New Layout for Stages and Enemy Spawns
- Fixed Enemies Stats to be more Balanced
  - Basic Enemies now have 2 HP by default
  - Fast Moving, Dangerous Enemies will now have less HP
  - Slow but Strong Enemies will have from double to tripple the Player's Estimate Firepower
- Fixed Audio Import Settings for better Loading Time

### Removed
- Removed Merged Scripts COmponents
- Removed Random Drops and Random Upgrades
- Removed and Replaced Obsolete Scenes



## [Playable: 1.0.0] - 3/4/2020

### Added
- Enemy Spawn points
- Sea background sprites + basic movements
- Swordfish Prototype - Stabbing Enemy
  - Behaviours: Rotate then Charge at Player (old) Positions
  - Spawn in Groups of 3, one by one
  - Updated Pixel Sprite
- Boss Titan Manta
  + Defeat Bosses to Win the Level
- Level Complete Screen
  + Showing Money Collected
  + Return to Main Menu

### Changed
- Re-located all scripts into approriate Groups and Folders
- Added Parents Object to some Enemies for Positionings, Movements and Animations Relativity
- Tweaked the Enemies Movements, SPeed and HP
- Toad Trackers Changes
  - Now have Stationery Platform (left out on the background on Toads Destroyed)
  - Move with the same Speed as the Background Sliding
- Enemy's Cam Shake: Cam now only shake on Shot Down, not every time getting shot
- Updated the Movement scripts
  - Replaced wrong Lerpings in Update functions with MoveTowards(), Rigidbody.velocity overriding and RotateTowards so the movements are smoother and faster
  - Tweaked the numbers

### Removed
- Removed Shop System
- Removed Level Preparations -> Levels now Loaded organically right from the Level Selection Screen
- Removed redundant Dummy Levels
- Removed some redundant Properties in Enemy Scripts
- Removed Score system and Increase Missile with Score Feature
- Removed Hp Break Effect

### Fixed
- Tracker Tracking in Sync: now Toad Trackers will Finish Rotating before Shooting
- Game Over functionalities
  - Background now stopped scrolling on Game Over
  - Disabling the Player HUD
  - Activating the Game Over canvas

## [0.17.0] - 1/2/2020

### Added
- Art Overhaul: Re-draw + Update all the UI, Player and Enemy Sprites
  - Neat Electro Theme
  - Soft Colors
  - Fitter Sizings
  - Leaner
  - Straighter
  - New Models
  - New Animation Sheets
- Level Preparation system
  - Item Panels: with Ticks and Highlight Effects
  - Basic UI Layouts and Elements
  - Selectable and Swappable
- Added Highlight Effects to UI Elements (Level Selection, Shop, Level Prep, etc.)
- Added Player Movement Animations Sheets: Left - Right
- Added Player Activate Box for Triggering Enemy SPawnings
  - Bigger than the Playing Field by 2 Unity Units per Sides
  - Has its own Tag
- Added Enemy Spawn Points: SPawn Points are now placed manually accross the level (with Kinematic Rigidbody + Collider)
- Added Scrolling Background

### Changed
- Trackers now move continously to the end of the Screen, but with slower speed
- Reduced the Brute Brute HPs for faster battle paces
- Increased the Brute Tuna Speed
- Changed the Enemy's Shot Prefabs: 3 Shots, each with their own Collider
  - Consequently Increase the Player Dmg per Attack to 3
- Increased the Missile's Dmg to 10
- Changed the UFO's Behaviours: they now spawned in group of 3, moving in an arc horizontally (implemented with animations) while tracking + shooting at the player's position
- Brutes won't attack but instead move in a straight line to the bottom as soon as spawned

### Fixed
- Fixed the Un-called Coroutines Bug
- Fixed the Unlimited Attacks from the Brutes
- Fixed the Delay Bug on Player's Movement Animations
- Bound Box no longer destroys Parents

## [0.16.0] - 25/12/2019

### Added
- Added the Level Selection's Lock / Unlocking Mechanic
  - Level Panels are Locked (with Sprite and Color Effects) by Default
  - Levels will be unlock by checking the Level Completion Prefs everytime the Level Selection Activates
  - Level Completion Prefs will be updated each time you completed a new Level (higher index than the Completed Prefs)
  - Added Level Progress Reset (by Reset the Level Prefs and Re-lock the Panels)
- Added Level 2 and Level 3 Scene
- Added Cam Shake and Impact effects on Shield - Ray
- Added 2 more Left - RIght Spawn Points
- Added Variations to the Brute Enemies
  - Straight movements Ahead + Spawned in Groups
  - Straight, then Turning movement + Spawned in Lines
- Added Symmetrical Synchronous Spawning Mechanics
  - Some Waves (Synced Waves) will have Enemy Groups with the same amount of Units
  - Spawn 1 each for each Groups, then Iterate til the target amounts for each Groups

### Changed
- Updated the Level(s) Spawn Data files: Correct namings and attributes
- Reduced the size scale of all in-game Entities, including
  - Bullets
  - Enemies
  - UI ELements
- Bulky: Add more HP (about 20%) to Enemies
- Changed the Spawn Orders in Spawn Data
- UFOs now are harder to deal with
  - Now Shoot Repeatedly in Circular Spread Patterns
  - Move Slower: to the middle of the screen then turn back
- Brutes
  - Renamed
  - Changed the movement Script to Simplified Straight movement and Rotating (Distance-based + Direction-based)
- Trackers 
  - Now have 2 Shot SPawns: Double Shoots
  - Rotate and Shoot Faster
- Titan
  - Shoot 2 waves of spread shots instead of 1 now

### Fixed
- Fixed the Collision bug where Ray and Bullets can still pass the Shield (changed the Collision all into 2D-based Trigger Test)

## [0.15.0] - 13/12/2019

### Added
- Spawning Test XML File
- 2 more Left and Right Spawn Spots
- Full-fledged Death Ray Ball Enemies:
  - Complete Functions and Effects as other Enemies
  - Added Sprite Arts for the Ball and the Death Ray (coupled with Animations)
  - Delayed and Spaced Interval Movement with Repeated Turning Attack Patterns
  - Custom Animations Transitions over Time Steps
  - Medium Health: 10pts
  - Added Death Ray with Hitbox and Colliding Behaviours
- Added Titan's Got Hit Animation: White Blinking
- Added Slight, Quick Cam Shake on Hitting Enemies
- Player Shield Skill: Player now became untargetable (moved to ghost layer) when Shielded: Immune to Bullets and Lasers
- Prolonged the Lvs with more Enemies and Waves

### Changed
- Brute Enemies Revamped
  - The Enemy Brute Right and Left now spawn in group of 3
  - Simpler Movement: use Values, Velocity Lerping and Timing-based Functionality to Move and Turn Smoothly Over Time
  - Rotate following Velocity movement (with some small modifiers)
  - Now Move Slower, and don't shoot

- Player Getting Hit Animation now Blink White (Changing Sprite Material to GUI Text Shader in Animation Clip)
- Updated the Level Spawning Data Files to represent the changes

### Fixed
- Fixed the bug where the camera fly to negative thousands on hiting Enemy Titan

### Removed
- No more complicated Bezier Movements
- Removed Unnecessary Debug Logs


## [0.14.3] - 17/11/2019

### Added
- Cam now Shake on Destroying enemies
- Added Poly-like Spawn Particle VFX on Player Shooting, called Shot Spark

- Shield Power
  - Temporary Shield off Enemy's Attacks - will still take Dmgs from Colliding with Enemies
  - COnsume Energy and Worked for a short amount of time (~ 1.5s)
  - Moderate Cooldowns (~ 5s)
  - Working Shield Sprites, Animations and Impact Effects

### Changed
- VFXs Overhaul: Poly-like Shapes with Simpler Layers and Palette
  - Enemy SHots Sprites are now all biger, with Clearer Colors and Outlines
  - Changed the Hit Impact Particle Effects - Impact Blasts: Faster and Flashier
  - Changed the Enemy's Explosion Effects: Bigger and Brighter

### Removed
- Temporarily removed the annoying explosion and impact SFXs
- Removed unnecessary Debug Statements
- Removed Deprecated Textures
- Removed Cam Shaking on-hit: Cam will Shake on Impactful Effects instead of Everytime


## [0.14.2] - 6/11/2019

### Added 

- Shop's UI Overhaul

### Changed

- Increased Player and Bullets's Size
- Increased Dash Distance and Speed
- Increased Player Shooting Speed

### Removed

- Temporarily removed the Endless Mode feature for future maintanance

### Fixed

- Fixed the bug where Level Spawner can't access XML Data Files after Building: Level Data (XML Files) are now loaded through public TextAsset and XmlDocument.LoadXml() method
- Fixed the inconsistent size of Player Bullets's Colliders


## [0.14.1] - 5/11/2019

### Added

- New Bullet's SPrites Designs
    + Enemy's: Red Orbs
    + Player's Bullets: Blue Orb

- Overhauled UI Arts for the Level Scenes and Main Menu Scene
    + Panels
    + Buttons
    + Selection Panels (Filled)
    + Borders

### Changed

- Lowered the difficulty at the beginning of levels
- Changed the Health UI Primary Icons and Arts to Battery ( more suitable for Futuristic SPace Theme)
- Refactored all the Dash-related Properties and Behaviours into DashSkill class
- Reduced Player's fire Rate

### Removed

- Removed annoying shooting SFXs

## [0.14.0] - 24/10/2019

### Added

- Added Warning Message Panel when return to Menu from Pausing for Confirming that the player is sure to quit and lose the current progress)(scripted in the Pausing component)

- Added some Debug Functions to the Main Menu
  - Reset Money
  - Log Total Money

- Implementing Shop System: Buy Abilities and Upgrades with Coins

- Shop UI: Added Grid Panel Populations to the Selling Items Content UI
  - Added a Auto-Grid-Populating Script to Fill the Grid with Grid Item Prefabs (going to be changed soon into manual Prefab Management individually for each Items) with Custom Sizes and Colors
  - Horizontal Grid with Scroll View
  - Currently with 3 Categories Tabbed: Skills, Gears and Consumables
  - Added Coin Counter (with Incremental Running Effect)

- Shop Debug Functionalities
  - Increase Money by 1000
  - Deplete money by 10 - 50 - 100
  - Reset Purchase Data (all Bought Items are reset)

- Shop Items Prefabs: with ItemPanel Components
  - Tagged: ItemPanel
  - Properties: Name and Price for each items
  - Selectable with mouse Click (will Highlighted and Referenced in ItemsController when Clicked using EventSystem's RaycastAll() and PointerEventData) to Buy
    - Single Selection at time
    - Implemented in Shop Controller, while the Panels's Responds are in Item Panel Component

- Buy Functions
  - Select Items > Click Buy (using EventSystem's RayCasting and static Object) > Update Players Prefs and Item Panel's State
  - Added related Debug Functions (usable only in Shop)
    - Get Bought Status
    - Reset Purchases (All)

- Added Buttons to Go to Shop (change Scene addictively while still retains the Main Menu scene) in the Level Selection UI and Return to MainMenu from Shop (unloading the Shop Scene) in the Shop Menu

- Added Debug Functions to Main Menu: Getting Bought Preferences

- Added Player Energy system
  - Represents by UI (Blue-themed with Cover Frames, Back Bar and Fill Image): Displaying the percentage of Energy left updated constantly
  - Can be Deplete and Refill with Input Events
  - Refill by killing Enemies

- Added Dash Movement Mechanics
  - Manipulating Rigidbody position to get the destination and direction - acting like a short Teleport, but with Continous Collision detections
  - Overload-Lerping a fixed distance to the last moving direction Fast (with high interpolate rate - Dash rate, about 4x the normal Move rate)
    - The Interpolates are multiplied by deltaTime for smooth, constant screen-rate movements
  - Deplete 20 Energy per Uses
  - 2s cooldown
  - Visual Effect: Dash Lines (Rotatable)
  - SFX: Teleporting

### Changed

- Increased the Moving speed and Shot Rate of UFOs
- Increased the Enemy Spawn time and Spawn Rate
- Updated Unity Version and Default Assets
- Increased the Changing Speed of the Shop's Money Coin Text
- Increased the player's movement Speed (acts as distance, Multiply with Input direction for the distance, then add onto current position for current position)
  - Overload-Lerping with delta Time

### Fixed

- Fixed the bug where the item still can be bought even if the money amount is insufficient (no pre-check)
- Fixed the bug where the player can dash when out of energy

### Removed

- Removed the Auto Grid Populating: Item Panels are made and set manually
- Removed and Merged the Tabs COntroller into the SHop Controller
- Removed the Scripts from the Main COntainer Child (the Controler script is moved into Shop Canvas)

========================================

## [0.13.0] - 25/09/2019

### Added

- Added Heart Upgrade Prototype:
  - Heal 1 hP (re-draw and re-display the Hearts)
  - Upgrade-class Components

- Added Default values to some Private Serializable Variables

- Added Missile Upgrade Drops and Missile Weapon with Behaviours
  - Missiles now drop persistently with Strong Enemies and randomly with Small Enemies
  - Press Ctrl to Fire: Will Fly to the center then Explode and Deal Dmgs
    - Rotate toward Center before Moving
  - Added Explosion Particle Animation and SFXs
    - The Exploding Sounds of Missile will bybass other Explosions (calculated based on damages received)
    - Followed by Cam Shaking Effect
  - Player will get one Missile every 300 points earned

- Added Coin's Sprites and Animations

### Changed

- Refactored the Code Base
  - Dropping Mechanics now included Delays
  - Enemy HP Managing Mechanics: Now enemies can be damaged and die by all kind of Dmg-dealing methods (The Alive-Dying Checks are perform everytime dmg is dealed, not just when getting shot)

- The Other Upgrades, like Money, will Burst out in the Beginning (Co-effects)
  - Implement in the Drop's Behaviour Component

- Straight Movements are now Treated as Seperated Script Component for Drop Items
  - Shots's special movement is Break into an individual Component: SHot Simple Straight Movement

- Reduced Spawn time between Enemy Waves
- Reduced Priority of Shooting and Enemy Exploding Sounds

- Reduced the Drop rate of Missiles and Hearts

- Cam Shaking Effects now have varying magnitude and duration depend on the Triggering Events

### Fixed

- Fixed the bug where the player Canvas wouldn't hide fully on Game Over (Added Hide-when-Game-Over Function)

### Removed

- Removed and Replaced some Unnecessary Scripts with Smaller, more Specific Components

## [0.12.0] - 27/08/2019

### Added

- Finished the Frameworks for Titan: Hard Enemies with High HP and Tricky Movement:
  - Big and Bulky with high HP
  - Spread Shots Attacking Pattern
  - Circling, Back and Forth Movement

- Added Cam Shake Effects when enemies are hit

- Added Coins and Money System:
  - Drop on Enemy defeated as Persistent Drops (customizable amount)
  - Coin amount will be updated and store as Money preferences
  - Coin Text Display in-game
  - Coin Movement Behaviours: Dropping, Turning and then Home toward Player
  - Coin Piicking and Money Mechanics
  - Added a Prototype for Coin (the Arts and Effects will be Added Later in the Production process)
  - Added Update Calls for when Game Over and Completing Levels (Money and Score will not be updated when you quit in the middle (with warning messages))

- Added Level Completion Panels (Prototype) with Return to Menu function (the Coins and Score will be Updated on Completion Screen)
- Added some test buttons (hidden on Play)

### Changed

- Enemies no longer immediately die on player contacting.
- Tweak the Upgrade Mechanics
- Reduced the Drop Rate on Enemies
- Tweaked the Score Text and Coin Count Display: more spaces and clearer

### Removed

- Removed the Shield Upgrade (will soon be replaced with Missiles, Healths and Energy Drops)

### Fixed

- Fixed the issue where coins won't be updated when you finish the levels
- Fixed Coin Infinitely Updating Loop on Level Complete
- Fixed when the Level Complete panel show up too soon, neglect the last coins dropped



## [0.11.0] - 20/07/2019

### Added:
- Implemented Level Selection UI and Functionality (the Appearance and Juiciness will be upgraded and improved later)
- The Old Play Scene now becomes Endless mode.
- Add a small interface for accessing enemy's common data.
- Implemented 2 more Scenes: Level 1 and Level 2, each with their own Spawner scripts (functioning basically the same as Endless Spawner):
  - Spawn in Waves: fixed orders of Enemies sets + Spawn Positions - in the form of XML Data file: LevelData.xml.

- Fully Working Level Spawner: (tested for Level 1)
  - Stored in XML Format with many Levels
  - Wave Class: Contain List of all Info of the Enemies in that Waves with some more Control variables:
    - Restriction (the enemies in the waves need to be wiped out before moving to the next)
  - Enemy Element:
    - Name (identical to the names Registered in the Spawn Manager Data)
    - Position index (based on directions, will pick out the indexed position in the list)
    - Amount (num per spawn, with delay)
  - The XML Data will be read by Level index: Waves by Waves, Enemies by Enemies (each will be stored in their respective collections)
  - Coroutines to Spawn Waves with Delay between Waves (or Enemy ALive Checks for Restricted Waves)

- Added Enemy Count Component to check if the enemies are still alive or not.
- Added Arts for the Titan Hard Enemies.

### Changed:
- Size changes:
  - Increase Trackers size and all Bullet sizes.
  - Reduce Player sizes.

- Increase Player's Speed and Fire rate.
  
- Tri-UFO behaviours:
  - Now can fire shots at facing directions over time.
  - Moving down in the beginning, then over time slowly move up (Using time-based Coroutines and Lerping techniques)

- Increase the Delay at the start of Spawning, and between Waves
- Changed the Tags of some Enemies and Shot types

### Fixed:
- Fixed the bugs where the HP Reducing Particle Effects won't play at the right time.
- Shield no longer destroy enemies (too Over-powered!)
- Fixed the Bound Box bug where the parent's objects won't be cleared out: now the whole hierachy wil be removed all contact
- 



## [0.10.0] - 25/06/2019

### Added:
- Shooting Patterns and Orb Shots for the Brutes.
- More arts for weapons
- New Flash Explosion Animation sheets: Bigger and more Impactful.
- Added new HP UI: with its own MEchanics (implemented into the PlayerHpManager) and Special Effects (Glass-breaking)

### Changed:
- Increased Spawn rates for more challenges.
- Strong Wave Shots now Spread.
- UFO and Brute no longer spawn Shot Upgrades.
- Increased Enemy's Shooting Rate and SHot speeds

### Fixed:
- Fixed the bugs where the Brute enemies turn the wrong diretions.
- FIxed the bugs where the Brute enemies can't shoot, but there is still shooting sfx.
- Fixed the bugs where the HP UI will always display 4 healths (lacking enabling)



## [0.9.1] - 13/06/2019

### Added:
- Brute Enemies
  - NOw Brute enemies (both left and right) Spawn in formations of 3.
  - Brute Enemeis on-getting-hit animations and effects.
  - Now has Shooting Functions (Spawned shots at consistent speed and rotations), but currently not working.
  
- Upgrade SHots System: with many Permanent upgrades in Fire power:
  - Normal Shots.
  - Strong Shots.
  - Double SHots.
  - Spread Shots.
  - Strong Waves.

### Changed:
- Lower the enemies upgrade drop rates.
- Lower Shield's active time.
  
### Removed:
- The old Strong shot mechanics now replaced with shot upgrades.
- The old Upgrades mechanics.




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

