# SB SpaceBattle
Console based shooter arcade game  
[Executable in repository](https://github.com/Daniel249/SB/raw/master/SBattle.exe "SBattle.exe download")


TO DO  
bool direction en Thing. player/enemy  
enemies have their textures turned around on construction

rework travel() en Bullet to either,  
have a direction based on (TO DO)Thing.direction,  1*  
or base it completely on (non positive only) coordinate direction

contructor en Bullet  
Bullet base values (rn they're test values only true for player)  
contructor en Weapon to include direction (if 1*) and position in Unit

rework textures to be self contained in a class outside thing  
support either individual color per pixel or per horizontal line

bind unit or player speed and battle cycles

create outter bounds of map and clear references to things leaving it



LI  
Player.runturn probar con y sin if(console.KeyAvailable)

posibles optimizaciones en printer.cs  
print- y deleteThing no se basan en printdelete.



AI

