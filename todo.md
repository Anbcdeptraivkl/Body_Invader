# Currently Working:
1. New Enemy - The Titan: @
   1. Big + High HP
   2. Behaviours: Spawn -> Move down the screen then start floating side by side, left to right and attack player in the mean time.
   3. Shoot Burst Shots
   4. Special Attack: Laser Burst
   

2. Enemies Types - based on difficulty:  More and More Enemies too!!! @
   1. Easy: Small and Light, no attack (e.g UFO)
   2. Normal: Specialize Movements and Attacking Patterns (some are harder than other) (e.g Brutes and Trackers)
   3. Hard: Big, Bulky and Many Attacking Patterns (e.g Titan and Surfer)
   4. Ultimate: Formations of multiple enemy Types that are extremely hard to deal with;
   5. Boss: nuff said - The Most Powerful Enemies in the game, only show up at the last stages of the levels and can spawn Minions: Special Units that only spawned in Boss fight
      1. Crabber
      2. Quez
      3. Big Brain
      4. 
   

3. Heart Gift: @
   1. Restore 1 Lost health bar;
   2. Only drop by 
   
4. Shield Upgrade Implementations:
   1. 
   2. 
   3. Sound Effects: when Vanishing \i
   
5. Change the Player Status UI to a simple Flat grids just like in the Game's Model: \i
   1. HP Bar. @
   2. Missiles Count. \i
   3. Ship Upgrades and Energy Bar (will be use for Spark Skills).
   4. Coin Counter;
   5. Ammo Upgrades Bar.
   
6. 4 Beginning Levels with Hard-scripted, pre-Designed and pre-Determined Spawn Patterns and Spawn Routines: 
   1. Each Levels will have their own Spawner (can be called Spawn Managers): Waves's Order and Structures will be Designed, Calculated and Scripted into Each Level: no Random factors, only Patterns and Challenges!!! @
      1. Co-routines and the likes (with Yieldings and Intervals are extremely suitable for these kind of Spawning Scripts)
   2. The Campaign Levels won't have score system, but instead the player can collect coins to buy supplies and upgrades. @
   3. Each waves will be more difficult than the last.
   4. Set-pieces: premade Formation of Enemies (stored in Script and Data form, or generated as complete Prefabs): These will be called SEF: Special Enemy Formations;
   5. Enemies and Waves, Times and Upgrades are spawned are manually designed and crafted for the whole level (less random factors, only in loot drops): their timings, structures and Positionings.
   6. The Levels will spawn more and more Difficult enemies so that the players have to utilize their skills and upgrades to the maximum: Challenging
   7. Some Levels will have Bosses and uique Hazard (Meteors, Turrets, etc.)


7. Harder Enemies for higher Difficulty Progresses:
	+ Bigger and Bulkier
	+ Harder Attack Pattern 
	+ Trickier Maneuvering
   
8. Enemies Shots can now rotate with velocity (tracking, etc.) @

9.  Bosses!
    1.  At Each Arc-ending Levels.
    2.  Big, Sturdy (Hundreds of HP)
    3.  Summon Enemies and Have Signature Attack / Defense Moves.
    4.  Before Each Bosses, player received a random Permanent Upgrades (last for the whole battles):
        1.  New Weapon (s) and Shot Upgrade Levels.
        2.  HP Recovery.
        3.  Missiles.
        4.  
    
10. PLayer appear flashing light effects.
    
11. More Music!
    1.  Better BGM for Menu and Normal Rounds.
    2.  Different BGMs for each levels.
    3.  Boss BGMs.

12. More Background arts: Varied Scrolling backgrounds for different stages.

13. MOre Upgrades:
    1.  Ship Armor Upgrades: More HP and Damage Resists (represent by an energy armor bar that deplete with damage received).
    2.  Missiles: Stackable High Damage Bomb with Arts, UI and Functionality.
    3.  HP Recovery Batteries.
    4.  Armor Upgrades: Change the Appearances and Provide the Player with an Armor Bar that will absorb Dmgs for them.
    5.  >> Need to change the whole mechanics around HP Managing and Upgrades: Refactor and Modify!

14. Spark Skills: will get each as the players progress and can be equip one-per-level every level (including Endless Mode)
    1.  A Movement Dash (Cuphead styles): USe Energy per Dash.
    2.  Beam Weapon: Constant fire-rates but less damages.
    3.  Bomb Shots: Slow Shot Rates but High AOE dmg.
    4.  A Charge Shield: can be used Infinitely but consumes a lot of Energy per Uses.
    5.  Energy are provided infinitely but won't recharge by itself (need to get Enery Filler upgrades) to regain.
    6.  Max HP: Start the Level with 1 more HP bar.
	7. Quick start: Start the Levels with one of the provided random Upgrades including:
		- 5 Missiles.
		- Tier 1 Armor
		- Tier 1 Weapon
	8. Supporting Homming Sparks: Frequently Shoot at enemies 2 Electric Sparks.
    
15. New Enemies, New Spawning Points and Enemy Types:

16. Fix the Bugs where Enemies will drop 2 upgs at once.



# Ongoing:

## VFX: /w

### Particle Animations: 
- Enemies OnHit by normal shot (shockwave and sparks) (in **Particle** form) 
	+ NEw Effects by Strong Shot. /w
	+ UFO effects. @
	+ Tracker effects. @
  
- Tracker new Explosion Particle Effects. /w
	
- Player:
  -  got Hit Visual (Spark and Shock Sprite Particles). /w

### Animations: 
- OnHit Animations for Enemies: UFO and Red Tracker (Blinking!) @
  - Shaking! @
- Onhit animations for player: red Blinking and Shaking. @

### Special:
- Cam SHake when player got hit. @

## SFX: 
- More Music! /w

- Hit sound effects: /w
  - Enemies (varied with shot types) @
  - Players. @
  - IMplement into logic and scripts. /w

- SHot Sounds:
  - Strong Shots. @

- Enemies Flying sounds. /w 
	+ Disticnct Appearing sounds. /w
  
## Upgrades! /w
+ Adding Score values: getting Upgrades will gift player big points! @

+ The Templated Approach: make one, then using the functional one as framework for the others. @
    + Use the Hierachy Template: The Parents are Upgrade-base, containing the shared behaviours, data, and identifiers, the children are Visual and Audio Effects + Specific Upgrade types identifiers and data (for checking collision and applying Upgrades). @
    
+ Behaviours and Controllers: @
  + The Random Dropper (for Enemies): Usiong Collections to dynamically allocate and call Objects, wiht some random values. @
  + Player Receiving Upgrades by checking Collision with tags, and Update Upgrade Scripts to activate features. @

### Strong Shot: /w
+ Update The Auto Shooting Mechanic to include Shooting Strong shots. @
  
+ Arts and Designs: @
  + Orb. @
  + Featured Objects. @
   
+ Effects:
  + Visual Effects: Animations and Particles + On COntact Effect on Enemies. @
  + SFX: Shooting sounds + Hitting sounds. @
  
+ UI: 
  + Strong shoot timer. 
  + Shot Type Indicators. 

### Shield: /w
- Shield Functionality: /w
  - Be Invincible by being covered in a round ET field for some seconds: avoid on Damage by normal enemies (not bosses).

- Shield Appearances: /w
  - Visuals and ANimations.
  - Sound Effects.
  
- UI:
  + Shield Timer.
  
### Missle:

+ Num. of Missiles.

### Spread Shot:
  	
+ Spread shot timer.


## General Designs:
  
+ Follow the Single Responsibility and Component-based approaches: Every scripts do only one specific tasks, affecting related Objects Only and Can be passed around Related Objects as Components or Script References! /w
  + Refactor the Player Getting SHot Mechanics: Add and move the script components to the player object. @

### Juiciness: /w

+ Colorful, but Consistent: /w
  + Color Palettes! /w
  + Same Main Colors for Enemies. @
  + Smae Color Schemes for Upgrades and Players Positive / Negative Effects: Player Blue, Enemy Red, etc. @
  
+ Responsive **Special Effects** + **Particle Effects**: every actions, every events will have their own exclusive vfx + sfx feedbacks!

+ More Robust and Impactful Animations (still subtle and won't affect gameplay):
  + Moving and Flashing vfx (Paarticles) when starting the games for player ship. 
  + Lighting when shooting and VFX (Animations, Particles and Special Effects) when getting hit, both player and enemies. /w
  
+ More Sound Effects!
  	+ Hovering + Buttons Pressed sounds. 
  	+ Navigating sounds:
    	+ Low Hp sfx. /w
    	+ Enemies Spawning Warning sounds. /w
    	+ Getting Upgrade SOunds.
    	+ Distinct sounds for reach types of Enemies, on moving, attacking and destroyed (sfx for the explosions, etc) /w
  	+ Action sounds:
    	+ Enemies moving. /w
    	+ Enemy Getting shot sound. /w
    	+ Player got shot (and invulnerable frame indicators) or got in contact /w
    	+ Achievement sounds.
    	
+ Cam Effects:
  + Screen shake!
  + Slow Mo!
  + Zooming!
  + Flashing!

### Level design:
  
- Can even go one step further and add levels and levels designs: /w
  - Terrains and Obstacles.
  - Hard-coded spawnsets.
  - Bosses.
  - Challenges.
  - About 2 Zones, each with 4 levels is enough.
  - Should be implement last after every other core mechanics, like combat and Upgrades had been laid out.
	
- Develop a random but intuitive design for Endless Mode by spawning not random enemies, but random set pieces (Sets of Enemies Spawning sequences): Still random, but you can control perfectly what will be spawned, and what challenges and difficulty the players will faced >> More friendly and More Fun! /w
  - The percentages will now determine the waves - the set pieces of enemies to spawn, cycle endlessly
  - About 5 set pieces, increasing in difficulty would be enough.
  - The higher the difficulty, the faster the enemies move.

### Coding:

- Code Refactoring:
  - Players COntacts and Collision Checking will be all implemented in a single script as Part of player components and will be controled by the player objects instead of the colliding objects: Object Oriented Encapsulation + SImple Relationship (KISS) + Focused Single Responsibility Design.

### New Enemies:
	
- Brute Hard Enemies Prefabs: /w
	+ Arts @
	+ Behaviours.


# Finished:

+ Follow naming conventions: Related Objects will be the prefixes for every scripts (e.g All enemy related scritps will start with 'Enemy-') @
  + Remember to Update the Script Components and References after renaming to avoid errors @
  
- Player HP Manager. /w
	+ UI and Effects:
    	+ Effects for HP Segment Depleting: 1 @ 2 @ 3 @
    	+ Fade the UI when Paused. @
	+ SOme Invincible frames when got hit (about 0.75 s), couples with vfx and sfx juicy responds @
	+ Scripts to Control the Interface and Effects:
    	+ The PlayerHPManager.
        	+ The UiHpController for Depleting Special Effects. @
    		+ Game Over and Destruction of Player on Out-of-HP. @
    	+ EnemyContactPlayer and EnemyShotPlayer only deplete player's HP and no longer cause Explosions: The Explosions, Destruction of Player and Game Over Controller are now managed with PlayerHPManager. @
