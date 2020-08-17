# SCRIPTS

## PLAYER

### Shared Player Component
- 

### Missile Launcher Component
- 


## ENEMY
- Seperated Enemies will be Distinguish with Different Components instead of Inheritance (Cumbersome)
  + All Enemies have unique Movement and Attack Patterns (especially the Boses): these Modules will not be implemented in the shared Enemy Component
  + Movements and Attacking Modules are created and named after the Enemy Types they are associating with (or a General name if they are shared between 2 or more enemy Types)
- Counting the remaining Enemies in the Scene

### Boss
- Boss will inherit Enemy (Boss is A Kind of Enemy but with differing Behaviours and Functionatlities)
- Polymorphism Dying

# STATS CONFIGURATIONS
- Configs are Serialized and Parsed as JSON with the same kind of Methods

## PLAYER
- See player-config.json in Resources for more Details

## ENEMIES

### 
