# May:
  
- Player HP Manager. /w
	+ UI and Effects:
    	+ Effects for HP Segment Depleting: 1 @ 2 @ 3 @
	+ Synergy with Upgrades. /w
	+ Scripts to Control the Interface and Effects:
    	+ The PlayerHPManager.
        	+ The UiHpController for Depleting Special Effects. @
    		+ Game Over and Destruction of Player on Out-of-HP. @
    	+ EnemyContactPlayer and EnemyShotPlayer only deplete player's HP and no longer cause Explosions: The Explosions, Destruction of Player and Game Over Controller are now managed with PlayerHPManager. @

+ Follow naming conventions: Related Objects will be the prefixes for every scripts (e.g All enemy related scritps will start with 'Enemy-') @
  + Remember to Update the Script Components and References after renaming to avoid errors @
  
  
- Upgrades! /w
	+ Upgrades UI.
	+ Special Effects + Sounds and Music.
	
+ Follow the Single Responsibility and Component-based approaches: Every scripts do only one specific tasks, affecting related Objects Only and Can be passed around Related Objects as Components or Script References! /w
  
- Hit ANimations and hit sound effects for all types of enemies. /w
- Juiciness: /w
	+ Colorful!
	+ Exclusive Special Effects with Particle Effects!
	+ More Animations!
	+ More Sound Effects!
    	+ Buttons Pressed.
    	+ navigating sounds.
    	+ Action sounds.
    	+ Achievement sounds.
	+ Cam Effects:
		+ Screen shake!
		+ Slow Mo!
		+ Zooming!
		+ Flashing!
  
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
	
- Brute Hard Enemies Prefabs: /w
	+ Arts @
	+ Behaviours.
