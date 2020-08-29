# SCRIPTS

## PLAYER

### Shared Player Component
- All different Types of Ship that the Player can controls follow the Same fundamental Properties and Behaviours: They share the same Player Script Component
- Special Ships that Unlocked later will have Special Augmented Movements and Attacking Components that will be defined later

### Missile Launcher Component
- Missile is bought in shop and will not replenish

### Winning
- The Level is finished once you defeat the Boss: Victory Panel will show after the Explosion sequences finished
  - The Player becomes Invincible as soon as the Boss HP reaches 0 and die
- Coins and Performance (Stars) will be counted

## ENEMY
- Seperated Enemies will be Distinguish with Different Components instead of Inheritance (Cumbersome)
  + All Enemies have unique Movement and Attack Patterns (especially the Boses): these Modules will not be implemented in the shared Enemy Component
  + Movements and Attacking Modules are created and named after the Enemy Types they are associating with (or a General name if they are shared between 2 or more enemy Types)
- Counting the remaining Enemies in the Scene

### Boss
- Boss will inherit Enemy (Boss is A Kind of Enemy)
- Each Boss, like Enemies, has their own Unique Movement and Attacking Behaviours
- Polymorphism Dying
- Dramatic Explosion on Destroyed: Ending the Level, cue the Result screen

# STATS CONFIGURATIONS
- Configs are Serialized and Parsed as JSON with the same kind of Methods

## PLAYER
- See player-config.json in Resources for more Details

## ENEMIES
- See Enemies COnfig files for more details (named after kind of enemies)

# SHOP
- Coins are used to buy in the Shop
  - Coins are only Counted when you passed the Level (killed the Boss and get to the end), dying without completing the level won't earn you anything
- Some items need special conditions to be purchasable
  - To stop Players from mindless Grindy
  - Need to pass a Level with 3 stars
  - Need to killed a Boss with no damage received
  - etc.

## WEAPONS

## UPGRADES & SKILLS

## CONSUMABLES

# PERFORMANCE STARS RATING