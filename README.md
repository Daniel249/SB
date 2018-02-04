# SB SpaceBattle
Console based shooter arcade game  
[Latest release. Contains executable and texture file](https://github.com/Daniel249/SB/releases "Current Release")  
[Standalone executable in repository](https://github.com/Daniel249/SB/raw/master/SBattle.exe "SBattle.exe download")

 ### Keybindings

Move with up down keys, stop with left key  
Toggle fire with F key


## Texture customization
*Textures.txt needs to be on the same folder as the executable  
Otherwise textures will reset to defaults*

A texture consists of an ASCII Art image, and a name or key  
Images are delimited by a '//' (double slash) above and below them, and are customizable without restraint  
Names/keys are hard coded into the game and only their assigned image is modifiable  

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
By default ships are loaded with a single weapon in the (vertical wise) center of the ship, rounded up for ships with even heigth

Weapon locations *can* be manually marked on a texture image, as well as multiple weapons placed  
This is done by putting an upper case 'W' on the desired rows of the texture image

In this example the ship on top gets it's weapon relocated
The second ship gets 2 weapons in different locations to the default one
```
// main  
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
### Things to consider

Empty lines will be visually included in images

Names/keys must be referenced once. Failing to do so will crash the game on launch

As images are delimited by a '//' above and *below* them. The last image in textures.txt must be followed by a '//' or else it won't be loaded (and assigned to a name/key) 

There is a limited number of name/keys, and images not assigned to one will simply be ignored  
The textures(.txt) file can be used as a virtually unlimited storing place for images

Placing a weapon mark outside an image's rows will create an emty line an include it on the texture image

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
  - Determine texture size and key
  - Storage in texture book
- Gameplay
  - Endless cycling minigame
&nbsp;


&nbsp;  
## TO DO
rework travel() en Bullet to either,  
be as is   
or base it completely on (non positive only) coordinate direction

bullet printing pattern based on direction. this will make bullet heads (hitbox) more accurate

support either individual color per pixel or per horizontal line

HP

rework printing to console to be frame based  

design GUI
includes: health, damage, attack speed, tickrate


LP  

Player.runturn probar con y sin if(console.KeyAvailable)

dinamically load weapon to ship based on texture  
adjust fire rate to not be op

AI

