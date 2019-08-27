
# Checking and Teesting Each Components!


# Prototype and Make things Work! The Arts and Effects will be saved for later!!!

## Fun to Play and Enjoy before Fun on the Surface

## Engaging and Stylist Arts

## Juicy and Responsive Effects (Both Sounds and Visual)

## Dynamic and Smooth Animations

## Immersive and Bumbping Sounds + Musics

## Intuitive and Easy UI + Display (HUB, etc.)


# Currently Working:

* HEART:
- Drop randomly by all enemies (low to high drop rates, based on Enemy Power Level)

- Restore 1 health bar
  - +20 score
  
- Act as an Upgrades (with similar Components)


* MISSILES:
- Drop random 
  - All enemies
  - Drop rates and Amounts varies with Enemies Power

- Upgrade Components
- Can be stored (til stage-end)
  
- Use with Button
  - Shoot a Missile (Animated)
  - Emit an Explosion and Smoke
    - Effects
    - Particles
  - Deal 10 Dmgs to all enemies on Screen


* UX:
- Warning Messages:
  - Quitting
  - Reseting




* COINS:
1.  Drop Randomly by Enemies, in addition to set amounts when killing harder enemies (>= Normal)
2.  Use to Buy SHips, Cosmetics, Upgrades and Skills (both permanent and one-use)
3.  Only Drop in Campaign, but what you buy will carried over to Endless Mode! Buy one time, use for lifetime!
   - The Shop Mechanics will be implemented later

- Coin Arts: 
  - Visual
  - Special Effects
  - Sounds
  - Coin Dropping Effects  
  - Coin Receiving Effects
  - Audio Effects: SFXs

- Test if the MOney are Updated and Saved in-out of the App: @: Fully Functional 
  - Now worked on Game Over and Level Completed, too!


* SHOP SYSTEM:
   - To Buy: with Money (in-game, stored as Preferene on Gameplay)
     - Upgrades
     - Supplies


* LEVEL COMPLETION MECHANIC: 
 - Prototype with Placeholders and templates first: Finished @
   - Level Complete UI Screen (UI/UX) @
   - Next Level 
   - Return to Menu @
     - Return to Level Select Screen

 - Arts
 - Effects



=====================================



- 4 Beginning Levels with Hard-scripted, pre-Designed and pre-Determined Spawn Patterns and Spawn Routines: ~
   + Some Levels will have Bosses 
   + And uique Hazard (Meteors, Turrets, etc.) ~
   + Unique backgrounds, too!


- New Enemy - The Titan:
   1.  Drops:
       1.  10 coins @
       2.  Shot Upgrades @
       3.  1 missile ~
   

- Implement a Shop system to use COin currency!
   + New Ships!
   + Equipments!
   + Skills!
   + Cosmetic!
   

- Heart Gift: ~
   12. Restore 1 Lost health bar;
   13. Only drop by Normal-up Enemies.


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


