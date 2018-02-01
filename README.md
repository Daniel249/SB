# SB SpaceBattle
Console based shooter arcade game  
[Executable in repository](https://github.com/Daniel249/SB/raw/master/SBattle.exe "SBattle.exe download")

Move with up down keys, stop with left key

Textures.txt needs to be on the same folder as executable  
Otherwise unit textures will reset to defaults

TO DO  

rework travel() en Bullet to either,  
have a direction based on (TO DO)Thing.direction,  1*  
or base it completely on (non positive only) coordinate direction

contructor en Bullet  
Bullet base values (rn they're test values only true for player)  
contructor en Weapon to include direction (if 1*) and position in Unit

bullet printing pattern based on direction. this will make the bullets head (hitbox) more accurate

support either individual color per pixel or per horizontal line

HI  

LI  
Player.runturn probar con y sin if(console.KeyAvailable)

posibles optimizaciones en printer.cs  
print- y deleteThing no se basan en printdelete.
calc second offset based on last position and new position

change to jagged array texture for performance

AI

