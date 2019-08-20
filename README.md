# SB SpaceBattle
Console based shooter arcade game  
[Latest release. Contains windows executable and texture file](https://github.com/Daniel249/SB/releases "Current Release")  
[Development Notes](https://github.com/Daniel249/SB/projects "Development")

### Keybindings

Move with up down keys, stop with left key  
Toggle fire with F key

### Game mode

There are 3 rotating phases with increasing enemy strength and decreasing quantity  

The player's ship can be destroyed by it's health dropping to or below 0 and there won't be any ship for the player to control  
This won't automatically exit the game  

Balance suggestions regarding player and enemy health, damage, rate of fire,  
as well as texture image proposals to be released with the textures file are appreciated
## Texture customization
*Textures.txt needs to be on the same folder as the executable  
Otherwise textures will reset to defaults*

A texture consists of an ASCII Art image, and a name or key  
Images are delimited by a '//' (double slash) above and below them, and are customizable without restraint  
Names/keys are hard coded into the game and only their assigned image can be changed  

To change the image assigned to a name/key, simply transport the name/key to the right of the '//' above the desired image

In this example the image on top is assigned to the "main" key. This image is then used for the player controlled ship  
The second image is not assigned to any key, and thus it won't be used in game


```
// main  
 | \
=[_|H)--._____
=[+--,-------'
 [|_/"""
//
XX<=
 <<::0:>=-
  <=[]>
 <<::0:>=-
XX<=
//
```
### Available names/keys:
- Player controlled
  - main
- Enemy controlled
  - minor
  - middle
  - major

### Weapon location
Changing a weapon's location affects the place relative to the ship, from which bullets are spawned  
By default ships are loaded with a single weapon in the (vertical wise) center of the ship, 
rounded up for ships with even height

Weapon locations *can* be manually marked on a texture image, as well as multiple weapons placed  
This is done by putting an upper case 'W' on the desired rows of the texture image

In this example the ship on top gets it's weapon relocated  
The second ship gets 2 weapons in different locations to the default one
```
//  
 | \
=[_|H)--._____  (default weapon location)
=[+--,-------'
 [|_/"""        W (new location)
//
XX<=
 <<::0:>=-   W (new location)
  <=[]>       (default weapon location)
 <<::0:>=-   W (new location)
XX<=
//
```
The placing of a mark (W) is always to the right of the image, even for enemy ships (which shoot to the left)  
The spacing between a mark and the image is not important



## Simplified Game Architecture
- Basic engine
  - Game set up
  - Game loop
  - Map boundaries and state
  - Unit movement
  - Player input
  - Weapon loading and firing
  - Game-tick aware objects
    - Attack- and MoveSpeed mechanics
    - Toggle firing
  - Projectile and hitbox collision
  - Print game state to console
- Texture loading and processing
  - Read texture file
  - Process texture image and weapon locations
  - Determine key and store in texture book
- Gameplay
  - Endless cycling minigame
