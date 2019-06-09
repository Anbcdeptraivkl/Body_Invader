# Currently Working:
1. New Enemies, New Spawning Points and Enemy Types:
   1. With their own Arts @ + Animations and Sfx (apearring, moving and attacking).
   2. Enemies with Curves Movement (in Group when spawned):
      1.  using Bezier Curves Formula and Interpolating Movement (with Lerpings) @
      2.  Smooth the Movement with Support Functions.
   3. Auto-shooting in Star patterns.
   4. Sideline Spawning Points with their own Spawning Mechanic to spawn groups of side-moving enemies.
2. 
3. Shield Upgrade Implementations:
   1. 
   2. 
   3. Sound Effects (when activating (receiving Upgrades sounds) @ - defending @ and vanishing)
   
4. Dynamic Spawning Manager and SPawning Modules:
   1. 
   2. Spawn using Table-based collections and Weighing Formulas (the same as Random Loot Tables Implementations)
   3. New Side-way Spawn points for Enemies with sideway movements (both random and in-level progression)
   
5. 4 Beginning Levels with Hard-coded, pre-Designed and pre-Determined Spawn Patterns and Spawn Routines: still using Weight Formulas, but now the Enemies Types and Waves Structures are pre-Design, not fully random anymore) 
   1. The Level Spawners follow Difficulty Progression Spawning Patterns: the Enemies become more and more difficult as Player's Points and Play-time Increase and:
   2. Clearance  Spawn Rates: new Enemies will spawn only when the old ones are all destroyed from the current scenes, not follow the time-based rates anmore.
6. 
7. Red Enemies continous y-axis Movements (with velocity)   
   
8. 

9.  Bosses!
    
10. PLayer appear flashing light effects.
    
11. More Music!
    1.  Better BGM for Menu and Normal Rounds.
    2.  Different BGMs for each levels.
    3.  Boss BGMs.

12. More Background arts: Varied Scrolling backgrounds for different stages.
13. SPread Shots Upgrade: Arts and Functionality.
14. Missiles: Arts, UI and Functionality.
15. Normal Shot Upgrades: Arts, UI and Functionality.



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
