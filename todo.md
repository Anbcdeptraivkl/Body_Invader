
# Checking and Teesting Each Components!


# Prototype and Make things Work! The Arts and Effects will be saved for later!!!

## Fun to Play and Enjoy before Fun on the Surface

## Engaging and Stylist Arts

## Juicy and Responsive Effects (Both Sounds and Visual)

## Dynamic and Smooth Animations

## Immersive and Bumbping Sounds + Musics

## Intuitive and Easy UI + Display (HUB, etc.)


# MECHANICS:
* MISSILES: 
<!-- - Drop random:
	+ Done: Fixing the Dropping so that the Persistent Upgrades can all Drop together
	+ Done:
		+ Replace Scrpts with Smaller Components 
		+ Behaviours for All Drop pieces: Burst out -> stand still -> Move  -->

+ Ongoing:  - Gain 1 every 200 points!
  
+ Ongoing: Making the Missile Launcher Script:
  + Press button to Shoot == Spawn Missile
  + Deplete amounts
  
+ Making the Missile Behaviour to control each individual missiles:
  + After Spawned
  + Missile flies to middle of the screen -> Wait for amount of time -> Explode
  + Deal Dmg to all enemies on screen (~ 10)
  + Play Sounds and Explosion Effects
  + Shake the Screen Dramatically

- Act as Upgrade Components
- Can be stored (til stage-end):
  - Display on Screen UI (just like HP and Enery!)
  
- Use with Button
  - Shoot a Missile (Animated) (from Player)
    - Move to the Middle >> Explode
    - Emit an Explosion and Smoke
    - Effects
    - Particles
  - Deal 10 Dmgs to all enemies on Screen (usually Wiping them All-out!)


* UX:
- Warning Messages:
  - Quitting
  - Reseting


* SHOP SYSTEM:
	- To Buy: with Money (in-game, stored as Preferene on Gameplay)
     - Upgrades
     - Supplies
	 - Cosmetics
	- Unlocking:
		+ Ship
		+ Weapons
		+ Skills


* LEVEL COMPLETION MECHANIC: 
 - Prototype with Placeholders and templates first: Finished @
   - Level Complete UI Screen (UI/UX) @
   - Next Level 
   - Return to Menu @
     - Return to Level Select Screen

 - Arts
 - Effects


=====================================


# ARTs - What to Designs and Intergrate:

* COINS: 
+ Model
+ Spinning and Turning rounds (around the Y axis)
	+ Sheet Animations!
+ Dropping Effects
	+ Sparkling Particles 
	+ Shining Effects 
+ Collecting:
	+ Particles Visual
	+ Sound Effects:
		+ Dropping
		+ Homing
		+ Receiving
		
		
* HEARTS:
+ Sparking Light Particles
+ Collecting SFXs: Healing
	
* Enemy - Titan:
+ Hit Effects:
	+ Blinking Red - White
	+ Hit Sounds
+ Explode when Destroyed:
	+ Small Explosion Particle
		+ Randomly generated among a frame
		+ Collaborative sounds
	+ Big Explosion:
		+ Big Sound
		+ White out the screen for a little
		+ Dramatic Explosion Particles

* Level Selection UI:
+ Layout
+ Art Template
+ Hover Effects:
	+ SFX
	+ Change Brightness
+ Lock Effects:
	+ Level Unlocking Mechanics
+ Click Effects:
	+ Change Color
	+ Click sounds

* Level Completion UI:
+ Same as above 
	+ WIth more Images represent Coin + Score

* More Background Arts
+ Themed:
	+ Space
	+ Space Station
	+ On The Moon
	+ Mars
	+ ... and many more
+ Parallax Scrolling
+ Infinite Scrolling
	
* More Music:
+ Based on cool SOngs collected
+ Background:
	+ Menu
	+ Stage
+ Boss Musics
+ Level COmplete Music
+ Game Over Music


=======================================


# IN QUEUE:

- 4 Beginning Levels with Hard-scripted, pre-Designed and pre-Determined Spawn Patterns and Spawn Routines: ~
   + Some Levels will have Bosses ~
   + And uique Hazard (Meteors, Turrets, etc.) ~
   + Unique backgrounds, too! ~


* New Enemy:
- The Titan:
   1.  Drops:
       1.  1 missile ~
       2.  Energy

- The Stingray: 
  - Fast, but Fragile
  - Fly Down the Screen
  - Shoot Side way in Cross Patterns (4 shots)
  - Drop:
    - Coins
    - Hearts
    - Energy
    - Missiles
   

- Implement a Shop system to use COin currency!
   + New Ships!
   + Equipments!
   + Skills!
   + Cosmetic!
   

- Heart Gift: ~
   1.  Restore 1 Lost health bar;
   2.  Only drop by Normal-up Enemies.


- Homing Missiles:
   + Quickly Fly forward to group of enemies and explode - dealing high damages (about 5)
   + Gain more Damage with Equipments, and Ammunition with in-battle Upgrades (drop by all kind of enemies)


- Laser Attack for Enemies: AOE and Straight Damaging (will be researched more later on)

   
- Permanent Shield Skills: Buy in Shop and Use (consume high amount of Energy) in Game for a short-lived, invincible Cover ~


- SFX Tweaks:
   + Lower the volume and pitch so the SFXs sound less irritating.
   + Add SFX for enemies's appearance and movement.

   
14. Change the Player Status UI to a simple Flat grids just like in the Game's Model: ~
   14. HP Bar. @
   15. Missiles Count. ~
   16. Ship Equipment and Upgrades.
   17. Coin Counter; ~
   18. Energy Bar  (will be use for Spark Skills)



15. Enemies Types - based on difficulty:  More and More Enemies too!!! ~
   19. Easy: Small and Light, simple attacks (e.g UFO, Brute)
   20. Normal: Specialize Movements and Attacking Patterns (some are harder than other) (e.g Trackers)
       1.  Enemies >= Normal will always Drop Coins and Upgrades (defined in their own Dropping Components) 
   21. Hard: Big, Bulky and Many Attacking Patterns (e.g Titan and Surfer)
   22. Ultimate: Formations of multiple enemy Types that are extremely hard to deal with;
   23. Boss: nuff said - The Most Powerful Enemies in the game, only show up at the last stages of the levels and can spawn Minions: Special Units that only spawned in Boss fight
      1. Crabber
      2. Quez
      3. Big Brain
   24. Harder Enemies for higher Difficulty Progresses:
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


