
# Checking and Teesting Each Components


# Modular Design


# Prototype and Make things Work! Seperate Mechanics and Appearances! The Arts and Effects will be saved for later

==================================================================================================================

# DESIGNS

==================================================================================================================

# REFACTORING

==================================================================================================================

- Rename the Files to more Accurately Describe the Reusability and Modularity of the Script Components

==================================================================================================================

# DEBUGGING

==================================================================================================================

# POLISHING

==================================================================================================================

# ART

==================================================================================================================

## ENEMIES
- Enemies's Blinking White When Hit
- TItan's VFXs -> Titan Hammerhead
  - Big Explosion on Destroyed
    - Following by Many Small Ones
    - White out the Screen for a little
- Enemy SPrites and Animation Re-Designs
  - Zero Ranger, Air Force and other Sh'mup Arts + Designs
  - Brute Visual -> Tuna
      + Tail-wagging animations
      + More Menacing SFXs!
  - UFOs Visual -> Snail Orbs
      + Light Flashing
      + Menacing SFXs
  - Tracker Visual -> Octopus
      + With Tentacles
      + Swimming and Squigling Animations

## PLAYER

## UI - UX DESIGNS
- Futuristic and Machinery: Clean and Flashy
- Filled Panels
- Frames
- Buttons
- Animations
- Particle Effects

- UI Panels and Objects (Slight) Animations for each Items Thumbnails
  - Sliding in when Spawning
  - Sliding out when Transiting
  - Couple with Electro SFXs

## BACKGROUND ARTS
- Themed
  - Space
  - Space Station
  - On The Moon
  - Mars
  - ... and many more

- Parallax Scrolling
- Infinite Scrolling

## MUSIC
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
  - Shining SFX (Coin Dropping Sound)

- Collecting
  - Sprakles Particles Visual

- Sound Effects
  - Homing
  - Receiving

### Tutorials and Tooltips
- Tutorial Tips to help players understand Equipments, Spark Skills and the COntrols in-game
   + Will pop up when player receiving upgrades, equips or skills for the first time.

### Level Starting and Complete Pop-ups

==================================================================================================================

# MECHANICS AND FEATURES

==================================================================================================================

## RE-BALANCE THE SPAWN DATA
- Changed the Level Spawning Data files to fit the Refactored Spawning Mechanics and Rules
- Correct Names
- Correct Orders
- From Easy -> Difficult

## MORE BULLET HELL-Y

### Shot Patterns
- Enemies shoot more Bullets
- Bullets fly in Shaped Patterns
- Player Bullets are longer and thinner, emulating a feeling of speed and piercing forces

### Spawn Patterns

### Snail Discs / UFOs

### Track Turtles

### Brute Tunas
- Spawn in many Form of Shaped Groups and Patterns
  - Rectangles
  - Triangles
  - Lines
- Dropping Bullets toward the middle of the field

## LEVEL SYSTEM
* Futuristic Space UIs

### LV Lock/Unlocking System 
- PlayerPrefs on Level Canvas and Level Complete
  - Level COmplete will Update Prefs bases on Lv Index value set in the Script COmponent
- Check Prefs to change Interactable status and Lock Effects

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

### Preparation Screens
- Open and Transition right when Selecting a Level
- Picking Skills and Equipment
    + Previews
    + Show Stats Modifyings and Benefits

### Lv Selection UI
- Functions
    + Select Level(s)
    + Shop
    + Return to Menu
- Unlocking New Levels Mechanic
    + After Completing a Level
    + With Effects: 
        + Lock and Breaking
        + Light Flashing
- Transition Effects
    + Sliding Down
    + Button Flashing
- Hover Effects
    + Change Brightness
    + Bubling Visual

## SHOP SYSTEM
- For Buying and Upgrading: All using in-game Currency (Coins)
- The Shop Data and Prefs will later be refactored and stored in external Files (XML, JSON, etc.) for more versatility
  - Only after all the basic functions are laid out and working perfectly

### SKill Upgrades
- Multi-tiers: Cheap -> Expensive
+ The Stronger the Skills, the Higher the Prices
- Dash -> Invincible when Dash -> Deal 1 Dmg on Dash
- Shield -> Longer Active Duration -> Faster Cooldown -> Reflect
- Weapon Upgrades -> Increase all weapon dmgs by modifier of 1
- Charge Shot: Can Charge a Powerful Shot
    + Deal High Dmgs
    + Pierce through Multiple Regular Enemies (not Bosses)

### Equipments
- New Weapons
    - Flamethrower: High Dmgs, Limited Ranges
    - Laser Beam: 
        - Piercing Effects
        - Low Dmgs
        + Can be Hold down
    - Homing Shots
        + Home Toward Nearest Enemies
        + x2 Homing Missiles
        + A little Tricky to control
- Ship
    + Extra Health
    + Extra Armor Layer: Add 2 Bar of Armor that will take Dmgs for the Player from the Beginning of each Stages
- Drones
    + Can buy 1 - 2
    - Attacking: Shoot at enemies
        + Slow Shooting Rate
        + x3 Bullets, Spread Patterns
    - Supporting: Dropping Energy and Heart Occasionally 
- Consumables
  - HP Pack: Heal when Dying
  - MIssile Pack: Free 2 Missiles at the Start
  - Battery: Immediately refill Energy Bar on Out of Mana

### New Playable Ships
- The Orca
    + High HP
    + Only Melee Attacks: Chargable and Spammable
        * Headbutt: Butting straight ahead, dealing High Dmg - then knock the player back
        * Sawblade: Slash forward in a wide Arc, dealing High Dmgs
- UFO
    + Low HP
    + Extreme Attacker: x10 Bullets Circle Spread
    + Become Invincible for many seconds (~2s) everytime took dmgs

### Cosmetics
- SKins for the Player
    + Different Colors and Accessories
    + Different Equipment Appearances
    + 2 for each SHips

## ENEMIES

### Better Enemy - Tuna
- Replace the Left and Right Brute
- A lil Bigger
- Has Tail Animations 

### New Enemy - Starfish
- Stationery Turrets: Spawn and SLide down with the Background
- Shoot and Circling in Star 5 x 5 Bullets Pattern (Based on Sky Force Anniversary)
- Medium Health and Size

### New Enemy - Stingray
- Spawn x2 at Left and Right
- No Shooting
- Home toward Player position for a short time, then start moving straight out off the screen
- Small Size and Small Health
- Fast but Dodgable

### New Enemy

### Better Enemy - Snail Orbs * 3
- Replace the UFOs: Still SPawn in Tripple and Spin to the Bottom of the Screen
- Now Bigger and Bulkier
- Move Slower

### Better Enemy - Octopus
- Replace the Tracker: Still Track the Player Shoot
- Bulkier
- Shoot more: 4 bullets in SPread Pattern
- Swimming and Squigling Animations

### Better Enemy - Titan Hammer Head
- Replace the Titan
- Nothing differ much but the Arts

### Enemy Patterns

## STAGES
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

## HAZARDS

### Bubbles
- Have Signal: Small, Bubling Areas
- If the Player passes by: Spawn and Immobilize for short amount of time


## BOSSES
- Super Powerful Enemies at the end of each Levels
- Attacks dealing 2 dmgs
    + Some can even Instant-kill!

### GIANT CRAB

### METAL DRAGON

### SHOCK BRAINY


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

##  More Equipments

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
