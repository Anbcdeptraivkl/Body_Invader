
# DATA
* Prefs and Values are checked everytime they are in use

## PLAYER PREFS
- The Number of Levels COmpleted: LevelsDone, 0
  - Updated every Level COmplete (only if the completing lv's index are higher (meaning New Lv))
- Currently Possessing Coins: Money, 0
- Current High Score (Updated every Level's End): highScore, 0

## SHOP ITEM PREFS
- Shop Item's Bought / Not Bought status: (int) Item's Key + "Bought", 0(Bought) / 1(Bought)
  - Will be set every Buying Session when the player successfully bought something
  - Items are Named following the IDs, and the IDs will be used as Pref Names to Set Prefs

### Weapon Prefs
- GunBought (Normal Laser)
- "FlameBought"
- "BeamBought"

### Equipment Prefs
- DashBought (Booster)
- "ShieldBought"
- "DroneBought"

### Consumable Prefs
- MissileBought (Pack)
- "ENPackBought"
- "HPPackBought"

## PREP ITEMS PREFS
- Set / Reset Prefs every Level Preps / Level Ends

### Weapons
- "UsingWeapon" int
- Default: 0
- Flamethrower: 1
- Piercing Laser: 2

### Equipments
- "UsingEquip" int
- Booster (Dash): 0
- Gravity Field (Shield): 1
- Support Drones: 2

### Consumables
- "UsingConsume" int
- 1 Free Missile: 0
- Energy Pack: 1
- Health Pack: 2

## LEVEL DATA


## ARCHITECTURES

### Player's Components
- PlayerController
- PlayerHPManager
  - PlayerGettingShot
- PlayerAttacking
- PlayerMissileLauncher
- PlayerUpgrade

### Enemy's COmponents
- EnemyCount: Checking Wave Cleared
- HP Manager + Short Invincibility on SPawned
- Drop Manager
- GettingShot + PlayerContact
- Movement (Options)
- Attacing (Options)

### Enemies's name
- BruteL/R
- BruteTurnL/R
- TriUFO
- Tracker
- RayBall
- Titan