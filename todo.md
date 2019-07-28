# Currently Working:
   
8. 4 Beginning Levels with Hard-scripted, pre-Designed and pre-Determined Spawn Patterns and Spawn Routines: ~
   <!-- 1. Each Levels will have their own Spawner (can be called Spawn Managers): Waves's Order and Structures will be Designed, Calculated and Scripted into Each Level: no Random factors, only Patterns and Challenges!!! @
      1. Co-routines and the likes (with Yieldings and Intervals are extremely suitable for these kind of Spawning Scripts) @
      2. Spawn multiple enemies in arow iwth delay (using amount="" Attributes) @
         1. Fixing the Bound Bugs @
         2. Fixing the Wave clearing Bugs @
            - Some Waves will need the enemy to be wiped all out before moving to the next waves: A Restricted (rest) Wave @
      3. Using pre-designed Data >> Read >> Parse >> Use! @ -->
   2. Some Levels will have Bosses and uique Hazard (Meteors, Turrets, etc.) ~
   
9.  New Enemy - The Titan: ~
   <!-- 4. Big + High HP @
   5. Behaviours: Spawn -> Move down the screen then start floating side by side, left to right and attack player in the mean time: @
      + MOve down for a fixed amount of time, then randomly move right or left.
      + The position is clamped, and if the Titan reaches the Bounds the velocity will change directions. -->
   6.  Shoot Tripple Burst Shots ~
   7.  Special Attack: Laser Burst
   8.  Drops: ~
       1.  10 coins
       2.  Shot Upgrades.
       3.  1 missile.
   

10. Coins: ~
   9.  Drop Randomly by Enemies, in addition to set amounts when killing harder enemies (>= Normal)
   10. Use to Buy SHips, Cosmetics, Upgrades and Skills (both permanent and one-use)
   11. Only Drop in Campaign, but what you buy will carried over to Endless Mode! Buy one time, use for lifetime!


- Implement a Shop system to use COin currency!
   + New Ships!
   + Equipments!
   + Skills!
   + Cosmetic!
   

12. Heart Gift: ~
   12. Restore 1 Lost health bar;
   13. Only drop by Normal-up Enemies.


- Homing Missiles:
   + Quickly Fly forward to group of enemies and explode - dealing high damages (about 5)
   + Gain more Damage with Equipments, and Ammunition with in-battle Upgrades (drop by all kind of enemies)

   
13. Remove the Shield Upgrades to a Permanent Shield Skills ~


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


