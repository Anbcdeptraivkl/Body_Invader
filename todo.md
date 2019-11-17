
# Checking and Teesting Each Components


# Modular Design


# Prototype and Make things Work! Seperate Mechanics and Appearances! The Arts and Effects will be saved for later


# DESIGNS

==========================================================================================================================================

# REFACTORING

==========================================================================================================================================

# DEBUGGING

==========================================================================================================================================

# POLISHING

- Removing unnecessary Debug.Log() statements

==========================================================================================================================================

# ART

- Enemy's VFX when Hit
  - Hit Animations
    - Hit Effect Particle
    - WHite Blinking

- TItan's VFXs
  - Hit Animations and Hit Effects as normal Enemies
  - Distinct Explosions
    - Small, Rapid ones on 1/3 and 2/3 HP
    - Big, Impactful one on Destroyed
      - Many Small Ones -> Lead to a Big One
      - White out the Screen for a little

- UI Panels and Objects (Slight) Animations for each Items Thumbnails
  - Sliding in when Spawning
  - Sliding out when Transiting
  - Couple with Electro SFXs

- Enemy SPrites and Animation Re-Designs
  - Zero Ranger

- New BGMs and SFXs
  - Implement Hit and Explosion SFXs
  - Make with LMMS Samples and Instruments
  - Need Practices!

==========================================================================================================================================

# MECHANICS AND FEATURES

## NEW ENEMIES

## ENEMY PATTERNS

## UPGRADES SYSTEM

- SKill Upgrades
  - Dash -> Invincible when Dash
  - Shield -> Faster Cooldown and Longer Active Time
  - Deadly -> Increase all weapon dmgs by modifier of 1

- Equipments
  - New Weapons
    - Flamethrower
    - Laser Beam
    - Homing Shots
  - Drones
    - Attacking
    - Supporting 

- Consumables
  - HP Pack
  - MIssile Pack
  - Battery: Immediately refill Energy Bar

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

## SHOP SYSTEM

- The Shop Data and Prefs will later be refactored and stored in external Files (XML, JSON, etc.) for more versatility
  - Only after all the basic functions are laid out and working perfectly

- Unlocking (with other Currencies and Conditions, usually collectibles)
  - New Ships
  - Cosmetics
  - Special and Upgraded Skills

## COINS

- Dropping Effects
  - Sparkling Particles 
  - Shining SFX (Coin Dropping Sound)

- Collecting
  - Sprakles Particles Visual

- Sound Effects
  - Homing
  - Receiving

## ART THEMEs and DESIGNs

### Enemy Designs

- Boss Monster
  - Super Powerful Enemies at the end of each Levels
  - Ideas
    - Giant Mecha Crab
    - Giant Robo Dragon Head
    - Giant Squid

- Change the Theme to Robotic Aquatic Creatures (Fishes, Tentacles, etc.)

### UI - UX Designs

- Futuristic and Machinery

<!-- - Panels
- Filled Panels
- Frames
- Main BUttons
- Navigation Buttons
- Shop Panels -->

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

===========================================================================================================

# IN QUEUE

- 4 Beginning Levels with Hard-scripted, pre-Designed and pre-Determined Spawn Patterns and Spawn Routines:
  - Some Levels will have Bosses
  - And uique Hazard (Meteors, Turrets, etc.)
  - Unique backgrounds, too!


## ENERGY SYSTEM

- Energy Pots Dropped by Enemies randomly!

## DASH Skill

- Cooldown Signals:
  - Radical Cooldown Icons (Filled)

## SPECIAL PLAYER SHIPS

- Special Abilities

- Special Attributes


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


## HEARTS

- Collecting SFXs: Healing
  
## MISSILES

- SFX when gained new ones

## TINY EFFECTS

1.  PLayer appear flashing light effects. ~

##  MOre Equipments

1.  Ship Armor Equip: More HP and Damage Resists (represent by an energy armor bar that deplete with damage received):
  + Change the appearances.
  + Provided an armor bar from the start.
2. Health Booster: Add 1 more HP.
3. Engine Boost: Increase movement speed by a significant percent.
4. Attack Drone: Shoot electric sparks at enemies on interval, dealing moderated damages!
5. Support Drone: Frequently Drop COins and Energy for you to pick!
- Enhanced Missile: Higher Dmg for Missiles
- Weapons: (changing the Player Weapon COmponent to generate the new Weapon Types)
  + Each has their own Appearances, Quirks and Upgrade Tiers!
  + Laser Gun: default - Constant Fire rate and consistent damages.
  + Buster: Fire small, fast laser beams -  Faster and fire in succession, but deal less damage per shot!
  + Flame Thrower: Fire a Range of Fire - Broader but shorter range and can deal damage continously (at the risk of moving closer to enemies).
  + Cannon: Fire Metal Balls - BIg and Strong, but slow Shooting Rate and slow Speed

## Tutorials and Tooltips

- Tutorial Tips to help players understand Equipments, Spark Skills and the COntrols in-game:
   + Will pop up when player receiving upgrades, equips or skills for the first time.


## Spark Skills:

-  will get each as the players progress and can be equip one-per-level every level (including Endless Mode) - Consume Energy on uses
1.  Laser Beam: Special Weapon: Long duration, but less damages.
2.  Bomb: SW: Slow, High AOE dmg.
3.  Energy are provided infinitely and very slowly recharge by itself (need to pick many Enery Filler to fully utilize the Spark Skills through out the game).
4. Supporting Homming Sparks: Frequently Shoot at enemies 2 Electric Sparks.


