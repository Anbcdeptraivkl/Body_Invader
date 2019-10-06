
# Checking and Teesting Each Components


# Modular Design


# Prototype and Make things Work! Seperate Mechanics and Appearances! The Arts and Effects will be saved for later


# DESIGNS

## Fun and Varied Mechanics

## Challenges

## Engaging and Stylist Arts

## Juicy and Responsive Effects (Both Sounds and Visual)

## Dynamic and Smooth Animations

## Immersive and Bumbping Sounds + Musics

## Intuitive and Easy UI + Display (HUB, etc.)

=====================================

# REFACTORING

======================================

# DEBUGGING

- Shop
  - Reset Buying
  - Deplete Money to Test UI
  - Test Panels and Tabs

======================================

# POLISHING

======================================

# DEvELOPING FEATURES

## SHOP SYSTEM

- Shop Scene
  - GUI: Themed
    - Text displaying the amount of Money remain ~
      - Couple with Increasing / Decreasing value Running Animation ~

    - Panels and Objects for For Sale Targets
      - Images and Animation for each Items Thumbnails
      - Description
        - Name
        - Effects / Powers
        - Prices

      - Buy Button
        - Select Items (Marked in Script Data and Highlight on UI) -> Click Buy -> Sold then Update Coins and Preferences
          - Bought Items will be Greyed out + Labeled SOLD (will become Unclickable)
        - Items bought will be Recorded and will be Checked on Level Entering UI and In-game Innitialization

- Unlocking (with other Currencies and Conditions, usually collectibles)
  - New Ships
  - Cosmetics
  - Special and Upgraded Skills

## ENERGY SYSTEM

- For using skills
  - Deplete when activate Skills / Ship Abilities

- Refill slowly with Time
  - and Energy Pots Dropped by Enemies!

- Display in Player HUB
    - Yellow Colored Theme
    - Fill Bar Appearance

## DASH Skill

- Dash and Blink A Short Distance
    - Fast (almost Instantly)
        - but still Damagable
    - Coupled with Visual Particle Effects
        - and Dash Sound

- Deplete Lots of Energy (a full bar of energy can use Dash 3 consecutive Times)

- Has Cooldown (about 2.5s between each Dashes)

## SHIELD Skill

- A Temporary Sphere that Absorb All Damages Coming
    - for a short amount of time (about 1s)

- Use little energy
    - but long cooldown (about 15s)

## UPGRADES SYSTEM

- Equipments
  - New Weapons
    - Flamethrower
    - Laser Beam
    - Spread shots
    - Homing Shots
  - Weapon Upgrades
  - Drones
    - Attacking
    - Supporting 

- Consumables
  - HP
  - MIssile Packs
  - Energy

## SPECIAL PLAYER SHIPS

- Special Abilities

- Special Attributes

## LEVEL SYSTEM  

- Level Completion Screen
  - UI Futuristic Styles
    - Fonts
    - Buttons
    - Layout
    - Icons
      - Money
      - Score
  - Return to Level Select Screen
    - Go to Next Level
    - Main Menu

- Picking Skills and Equipment Screen
  - Open when going into Level
  - Player Art Preview

- Level Selection Screen
  - Unlocking New Levels Mechanic
  - UI
    - Shop Button
    - Quit Button
    - Layouts
    - Art Style Templates
  - Effects
    - Sounds
    - Hover Effects
      - Tick
      - Change Brightness
    - Click Effects: SFXs and Change Colors

## COINS

- Dropping Effects
  - Sparkling Particles 
  - Shining SFX (Coin Dropping Sound)

- Collecting
  - Sprakles Particles Visual

- Sound Effects
  - Homing
  - Receiving

## HEARTS

- Collecting SFXs: Healing
  
## MISSILES

- SFX when gained new ones

## Enemy - Titan

- Animator and Animations
  - Hit Effects
    - Blinking Red - White
    - Hit Sounds
    - Hit Explosion Particles 
      - Spawn Randomly on the Model
  - Explode when Destroyed
    - Small Explosion Particle
      - Randomly generated among a frame
      - Collaborative sounds

- Big Explosion
  - Exploding Sound
  - White out the screen for a little
  - Dramatic Explosion Particles

## Graphics

- Whiter and more Opaque Enemy Shot

## UX

- Design Futuristic theme GUI
  - Elements
    - Buttons
    - Panels
    - Icons
  - Layout

## Background Arts

- Themed
  - Space
  - Space Station
  - On The Moon
  - Mars
  - ... and many more

- Parallax Scrolling
- Infinite Scrolling

## More Music

- Self-composed Based on cool SOngs collected

- Background OST:
  - Menu
  - Stages

- Boss Musics
- Level COmplete Music

## STAR RANKING System

- 1 - 2 - 3 Stars Rating when Level Complete
  - Based on Player's Score and Health in-game (Mostly Score)
    - Completing the level with Perfect health and defeat a considerate amount of enemies for highest ranks

=======================================

# IN QUEUE

- 4 Beginning Levels with Hard-scripted, pre-Designed and pre-Determined Spawn Patterns and Spawn Routines:
  - Some Levels will have Bosses
  - And uique Hazard (Meteors, Turrets, etc.)
  - Unique backgrounds, too!

## New Enemy

- The Stingray
  - Fast, but Fragile
  - Fly Down the Screen
  - Shoot Side way in Cross Patterns (4 shots)
  - Drop:
    - Coins
    - Hearts
    - Energy
    - Missiles

- Implement a Shop system to use COin currency!
  - New Ships!
  - Equipments!
  - Skills!
  - Cosmetic!

- Laser Attack for Enemies: AOE and Straight Damaging (will be researched more later on)

- Permanent Shield Skills: Buy in Shop and Use (consume high amount of Energy) in Game for a short-lived, invincible Cover ~

- SFX Tweaks
  - Lower the volume and pitch so the SFXs sound less irritating.
  - Add SFX for enemies's appearance and movement.

- Change the Player Status UI to a simple Flat grids just like in the Game's Model: ~
    1. HP Bar. /f
    2. Missiles Count. /f
    3. Ship Equipment and Upgrades ~
    4. Coin Counter; /f
    5. Energy Bar  (will be use for Spark / Skills) ~

1.  Enemies Types - based on difficulty:  More and More Enemies too!!! ~
   1.  Easy: Small and Light, simple attacks (e.g UFO, Brute)
   2.  Normal: Specialize Movements and Attacking Patterns (some are harder than other) (e.g Trackers)
       1.  Enemies >= Normal will always Drop Coins and Upgrades (defined in their own Dropping Components) 
   3.  Hard: Big, Bulky and Many Attacking Patterns (e.g Titan and Surfer)
   4.  Ultimate: Formations of multiple enemy Types that are extremely hard to deal with;
   5.  Boss: nuff said - The Most Powerful Enemies in the game, only show up at the last stages of the levels and can spawn Minions: Special Units that only spawned in Boss fight
      1. Crabber
      2. Quez
      3. Big Brain
   6.  Harder Enemies for higher Difficulty Progresses:
	+ Bigger and Bulkier
	+ Harder Attack Pattern 
	+ Trickier Maneuvering

16. Bosses! ~
    1.  At Each Arc-ending Levels.
    2.  Big, Sturdy (Hundreds of HP)
    3.  Summon Enemies and Have Signature Attack / Defense Moves.
    4.  Before Each Bosses, player received a random Permanent Upgrades (last for the whole battles):
        1.  New Weapon (s) and Shot Upgrade Levels.
        2.  HP Recovery a.
        3.  Missiles.
        4.  
    
17. PLayer appear flashing light effects. ~
    
18. More Music! ~
    1.  Better BGM for Menu and Normal Rounds.
    2.  Different BGMs for each levels.
    3.  Boss BGMs.

19. More Background arts: Varied Scrolling backgrounds for different stages. ~

20. MOre Equipments: ~
   1.  Ship Armor Equip: More HP and Damage Resists (represent by an energy armor bar that deplete with damage received):
      + Change the appearances.
      + Provided an armor bar from the start.
   2. Health Booster: Add 1 more HP.
   3. Engine Boost: Increase movement speed by a significant percent.
   3. Attack Drone: Shoot electric sparks at enemies on interval, dealing moderated damages!
   4. Support Drone: Frequently Drop COins and Energy for you to pick!
   - Enhanced Missile: Higher Dmg for Missiles
   - Weapons: (changing the Player Weapon COmponent to generate the new Weapon Types)
      + Each has their own Appearances, Quirks and Upgrade Tiers!
      + Laser Gun: default - Constant Fire rate and consistent damages.
      + Buster: Fire small, fast laser beams -  Faster and fire in succession, but deal less damage per shot!
      + Flame Thrower: Fire a Range of Fire - Broader but shorter range and can deal damage continously (at the risk of moving closer to enemies).
      + Cannon: Fire Metal Balls - BIg and Strong, but slow Shooting Rate and slow Speed


21. More In-battle Drops: (the Skills and Equipments will change player ship's appearance, while the upgrades will affect stats only)
   - Collectibles - Coins, Energy and Missiles can drop multiple ones at time depend on the difficulty and drop setting of the enemies dropping!
   - Weapon Tier Upgrades
   - Coins
    2. Homing Missiles: Stackable High Damage Bombs with Arts, UI and Functionality (will be implemented seperatedly as a kind of weapon for player to use)
    3. HP Recovery Batteries (only drop on Normal-up Enemies)
    4. Energy Refiller.
    5.  >> Need to change the whole mechanics around HP Managing and Upgrades: Refactor and Modify!


- Tutorial Tips to help players understand Equipments, Spark Skills and the COntrols in-game:
   + Will pop up when player receiving upgrades, equips or skills for the first time.


21. Spark Skills: will get each as the players progress and can be equip one-per-level every level (including Endless Mode) - Consume Energy on uses:
   1.  An invincible Dash (Cuphead styles): USe Energy per Dash.
   2.  Laser Beam: Special Weapon: Long duration, but less damages.
   3.  Bomb: SW: Slow, High AOE dmg.
   4.  A Charge Shield: can be used Infinitely but consumes a lot of Energy per Uses.
   5.  Energy are provided infinitely and very slowly recharge by itself (need to pick many Enery Filler to fully utilize the Spark Skills through out the game).
	8. Supporting Homming Sparks: Frequently Shoot at enemies 2 Electric Sparks.


