# SB SpaceBattle
Console based shooter arcade game  
[Latest release. Contains executable and texture file](https://github.com/Daniel249/SB/releases "Current Release")  
[Standalone executable in repository](https://github.com/Daniel249/SB/raw/master/SBattle.exe "SBattle.exe download")

Move with up down keys, stop with left key

Textures.txt needs to be on the same folder as executable  
Otherwise textures will reset to defaults

TO DO  

rework travel() en Bullet to either,  
have a direction based on (TO DO)Thing.direction,  1*  
or base it completely on (non positive only) coordinate direction

contructor en Bullet  
Bullet base values (rn they're test values only true for player)  
contructor en Weapon to include direction (if 1*) and position in Unit

bullet printing pattern based on direction. this will make bullet heads (hitbox) more accurate

support either individual color per pixel or per horizontal line

HI

posibles optimizaciones en printer.cs  
print- y deleteThing no se basan en printdelete.  
calc second offset based on last position and new position  
transform char array to string and print once

LI  

Player.runturn probar con y sin if(console.KeyAvailable)

change to jagged array texture for performance

dinamically load weapon to ship based on texture  
adjust fire rate to not be op

AI

