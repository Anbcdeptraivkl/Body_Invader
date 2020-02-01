
- Placing Enemies into the background with your own Design and Timing
  - Brutes spawn in 2 / 3 Lines simultaneously / consecutively
  - UFOs spawn in 2: 1L, 1R right next to each others
  - Toad Trackers spawn with their platforms, sticking to the background scroll
  - Manta Titan is now the final Boss, will be more Powerful -> defeat to win!
- New Enemies
  - Swordfish: flies straight to the player
    - Super Fast flying speed
    - Fragile (1 - 2 HP - can be killed in 1 hit, but you must be quick)
  - Softshell Turret
    - Attack in a Rotating Strings Pattern
    - Stationary like the Trackers
- Manta's Powers
  - Shoot Laser from the middle
  - 2 more Turrets shooting Flowering Pattern Bullets

==================================================================================================================

# PRINCIPLES

==================================================================================================================

## Checking and Teesting Each Components

## Modular Design

## Prototype!
- A Lot of Iterations!
- Cheap + Fast
  - Focus on the Main Features / Systems before designing smaller Composite Functions
  - You don't need to make everything, just Implement some of them and leave the rest for later Immersion Updates
  - Use Placeholders and Primitive Arts to Implement + Iterate the Mechanics + Programming Functionalities First
- Make things Fully Work + Check if things are Viable + Fun enough
- Aim to Emulate the Full Functional Loop (Game Loop)
  - Ex: Go to Menu -> Select Power-ups -> Select Lvs -> Play -> Go to Shop -> Buy Power-ups -> Rinse and Repeat for the Next Lvs
- After fully tested and fixed -> Consider Adding your Arts 

## Seperate Mechanics and Appearances! The Arts and Effects will be saved for later

==================================================================================================================

# CODE DESIGNS + ARCHITECTURES

==================================================================================================================

==================================================================================================================

# REFACTORING

==================================================================================================================

## POLISHING
- Rename the Files to more Accurately Describe the Reusability and Modularity of the Script Components

## DEBUGGING

==================================================================================================================

# MECHANICS + FEATURES

==================================================================================================================

## LEVEL DESIGNS

### Backgrounds
- Unique BG Images for each Levels
  - Big + Long
  - Scrolling
  - Simple, but still got some Feels
  - Enemies + Spawn points are children of the Scrolling Background -> when Activated when entering Activate Box surrounding the player will become Independent / Spawn Independent Units (out of the Hierachy, etc.+ won't move with the background anymore)
  - The Background will Stop scrolling / Repeat a Blank Segment when facing Bosses / the Last Waves of each Levels

### Hazards
- Unique for each Levels
- Deal Constant Amount of Dmgs
- Have Build-ups + Effects and can easily be Avoided on their own (Not so much when surrounded by enemies though!)

## LEVELS SELECTION SYSTEM
* Futuristic Space UIs
* Testing and Updating the Entities to the new Level Prep + Selection System

### Adding Levels
- Adding Dup Level Scenes (with their own Spawn Data files that are also Dup)

### Level Completion Screen
- Icons
    + Money
    + Score
- Values
- Highscores
- New Highscore! Flasher
- Options
    + Next Level
    + Return (to Level Selection)

## BULLET HELL MECHANICS

### Bullets
- SMaller
- Faster
- More!

### Shot Patterns
- Bullets fly in Shaped Patterns
- Player Bullets are longer and thinner, emulating a feeling of speed and piercing forces

### Track Cannons
- The Tracker Toad now Slowly move to the end of the screen (like a stationary turret that keeps on while you move)
- Spawn on Background Platforms
  - The Platforms Sprites are attached to the Toads itself
  - Move at the Constant Speed the same as the Background: Create an Illusion of Stationery!
- Shoot the Fastest Bullets

### Brute Tunas
- Spawn in many Form of Shaped Groups and Patterns
  - Rectangles
  - Triangles
  - Lines
- Can spawned from side and from top
- Dropping Bullets toward the middle of the field
  - Velocity update with current position
- Less HPs

## SHOP SYSTEM
- The Shop Data and Prefs will later be refactored and stored in external Files (XML, JSON, etc.) for more versatility
  - Only after all the basic functions are laid out and working perfectly

* With these Items You have to choose in your collections which one to bring with you into the Battle(s) (In Tab Groups coupled with Screen Transitions)
  - Ships + Cosmetics
  - Weapons 
  - Equipments
  - Consumables

### Effects
- Tab Transitions
  - with Panels
- Highlights

### Shop Items
- Implement Real Items
- Setting Prefs - Documentations

### Debugs
- Reset Money
- Reset Payment History alongside Bought Prefs
   
## PLAYER SKILLS + POWER-UPS
* Including
  - Equipments
  - COnsumables
  - Skills
  - Upgrades
  - SHips
  - Cosmetics

### GUn
- Updating Bullets
  - Smaller Impact Shockwave
  - Tri-shot

### Item Managements
- Based on Prefs to Activate / Deactivate Weapons + Equipments + Consumables
- Using Bool COntrol States in Player Controller + Player Attacker
- Using Components: Setting and Resetting

### Flamethrower
- Short Range attack, wide Cone
- Damage over Time: High
- Constant Fire-rate
- Activate with Prefs (Reset after level completed)

### Equipments
- Dash - Booster -> Invincible when Dash -> Deal 1 Dmg on Dash
- Shield - Gravity Layer-> Longer Active Duration -> Faster Cooldown -> Reflect
- Support Drones
  - Hovering around player
  - Dropping Energies + HP occasionally

### Weapons
- Normal Guns
  - Straight 
- Flamethrower
- Spark Beam
  - Weapon
  - Piercing Effects
  - Low Dmgs
  - Hold to Fire COntinously

### Consumables
- MIssile Pack: Free 2 Missiles at the Start
- HP Pack: Heal to 1 HP when Dying
- Battery: Immediately refill Energy Bar on Out of Mana

### New Playable Ships
- The Orca
    + High HP
    + Only Melee Attacks: Chargable and Spammable
        * Headbutt: Butting straight ahead, dealing High Dmg and knock the player back a little
        * Sawblade: Slash forward in a wide Arc, dealing High Dmgs
- UFO
    + Low HP
    + Extreme Attacker: x10 Bullets Circle Spread
    + Become Invincible for many seconds (~2s) everytime took dmgs

* Customed Ships have their own Special Weapons and Cannot choose any others

### Cosmetics
- SKins for the Player
    + Different Colors and Accessories
    + Different Equipment Appearances
    + 2 for each SHips

## ENEMIES DESIGNS

### New Enemy - Starfish
- Stationery Turrets: Spawn and SLide down with the Background
- Shoot and Circling in Star 5 x 5 Bullets Pattern (Based on Sky Force Anniversary)
- Medium Health and Size

### New Enemy - Octopus
- Stationery Turrets: Spread out a Groups of Mines moving at different Speed
- TUrning around while shooting
- Medium Health and Size

### New Enemy - Stingray
- Spawn x2 at Left and Right
- No Shooting
- Home toward Player position for a short time, then start moving straight out off the screen
- Small Size and Small Health
- Fast but Dodgable

### New Enemy

### Better Enemy - Tuna
- Removed the Unnecessary Turnings
- Adding Shooting Patterns

### Better Enemy - Tracker Toad
- Swimming down continously

### Better Enemy - Titan Manta

### Better Enemy

### Enemy Patterns

## DETAILED STAGES DESIGNS
- Every Levels is a distinct Stages with Special
    + Themes and Backgrounds
    + Unique Enemies
    + Unique Hazards
    + Unique Bonuses and Drop Powers
    + Bosses (every 2nd Levels)

### 1 + 2
- Theme: Aquatic
- Unique Hazard: Bubble
- Enemies
    + Snails
    + Sting Rays
    + Octopi
    + Titan Hammerheads (Sub-boss)
    + Death Balls
    + Starfishes

### 3 + 4
- Theme: Rocky Mountain
- Unique Hazard: Volcano

### 5 + 6
- Theme: Outer Space
- Unique Hazard: Meteors

### Bubbles
- Have Signal: Small, Bubling Areas
- If the Player passes by: Spawn and Immobilize for short amount of time

### Volcanos

### Asteroids

## BOSSES DESIGNS
- Super Powerful Enemies at the end of each Levels
- Attacks dealing 2 dmgs
    + Some can even Instant-kill!

### GIANT CRAB

### METAL DRAGON

### SHOCK BRAINY

## RANKING + REWARD SYSTEM

- 1 - 2 - 3 Stars Rating when Level Complete
  - Based on Player's Score and Health in-game (Mostly Score)
    - Completing the level with Perfect health and defeat a considerate amount of enemies for highest ranks

==================================================================================================================

# ART

==================================================================================================================

## ENEMIES
- TItan's VFXs -> Titan Manta
  - Big Explosion on Destroyed
    - Following by Many Small Ones
    - White out the Screen for a little
- Enemy SPrites and Animation Re-Designs Based Loosly on other Sh'mup Arts and Designs
    - Zero Ranger
    - Blue Revolver
    - Sky Force series

## PLAYER
- Redesign Plyaer's Main Ship: More Rigid Looking and Cooler Style

### Animations
- Sliding Sides (Left - Right)
- Charging Animations
  + Light
  + Burst Particle

### Flamethrower
- Plasma (Blue)
- Sharp Animations

## UI - UX DESIGNS

### Customized Elements
- Filled Panels
- Frames
- Text Labels
- Buttons
  + Shape Buttons
  + Covers
  + Icons
- Animations + Effects
  + Selection + Marking
  + Tooltips
  + Sliding
  + Changing

### Transition Effects

### Panel Sliding Effects

### Hover Effects

### Tick Effects

### High Score Level COmpletion Effects

### Level UIs

### Shop UI
- UI Panels and Objects (Slight) Animations for each Items Thumbnails
  - Sliding in when Spawning
  - Sliding out when Transiting
  - Couple with Electro SFXs

## BACKGROUND ARTS
- Self-Designed and Draw
  + using References
  + using COnsistent Colors
- Themed
  + Sea Bed
    * Sand
    * Underwater
    * Lively with Creatures
  - Space
    + Precise
    + Round
    + Clear
  - Space Station
  - On Mars
  - ...and many more
- Parallax Scrolling
- Infinite Scrolling

## MUSICs
- New BGMs and SFXs
  - Implement Hit and Explosion SFXs
  - Make with LMMS Samples and Instruments
  - Need Practices!

- Background Musics for each Stages
- Boss Musics
- Level COmplete Music

## MISC.

### Coins
- Dropping Effects
  - Sparkling Particles 
  - Shining Radiant SFX (Coin Dropping Sound)

- Collecting
  - Sprakles Particles Visual

- Sound Effects
  - Homing
  - Receiving

### Tutorials and Tooltips
- Tutorial Tips to help players understand Equipments, Spark Skills and the COntrols in-game
   + Will pop up when player receiving upgrades, equips or skills for the first time.

### Level Starting and Complete Pop-ups
