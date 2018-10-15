# Ideas for a game project

## Possible (non-)arcade games for references
* starfox
* battle tank
* zaxxon
* Sid Meier's Pirates '87
* ftl
* pixel dungeon
* POTTS indie naval game


## desirable genres for reference
* top-down  
* rogue-like
* 
## re-doing a classical arcade / adding a certain feature list
* pong with MP funtion
* snake with first pirson view

## creative concept ideas aka freedom of thought
### rogue-like concept
Ship game. Moving in open sea, meeting on the way different ships to engage in battle with
in order to obtain resources to proceed with a journey.

### key parts of the game, generalisation
* map
	* devided into leveles, aka rooms
* rooms can consist of
	* different ship's decks, so progression goes thorugh decks containing mobs to attack
	* differnt parts of the sea, containing hexagons with islands/rocks, and having ships to attack
* progression between rooms/lvls
	* we can't proceed to the next one until lvl is cleared
	* reaching the border of lvl we greeted with a msg that we can't proceed (we don't know location)
	until we acquired piece of a map from a boss/treasure.
* attack, battle mode
	* abordage/naval boarding, i.a., we appear on the deck having animations of our team attacking in
	meantime while we're progressing with our character going from one attacker to another
	* naval attack shooting out of the cannons, 
### Detailed Overview
#### Room/lvl
* terrain  consists of hexagons, containing islands, rocks
* initially covered with a fog of war
* has a artificial borders that are closed for progression until piece of map is acquired
#### Movement
* actual:
	* use navmesh for pathfinding
* obsolete:
	* one move = proceeding to the next adjacent tile
	* moving between tiles uses food/energy state
	* turning around on one hexagon (for attack) uses food/energy state
#### Ships
* pirat armored ship
* trading ship
#### Parameters

#### Charachterstics

#### Progression/States
* exp system/lvling
* health
* additional system affecting health state, like food/energy
* money to buy upgrades
* armor lvl
* weapon lvl
* team?
#### Goal
* acquire piece of a map from a mob/boss to proceed to the next room/lvl
* gain food/energy to be able to move further
* collect all the pieces of a map to reach a final stage/battle

#### Naval Attack
* cannons shoots only from sides (TODO: look up how to control weapon firing direction, crate a separate weapon)
* create a fire points (Transform type) to create a canons on the sides spawning projectiles
* check if opponent's ship is located to you sides: true -> shoot, false -> take a turn to turn around
* with upgrades shooting range can be increased
* every attack substract health of the opponent
	* side shoot substracts more than nose, back of the ship
	* succesfull rate can be counted to add crit chance, which can be upgraded
* after succesfull battle loot is acquired
#### Loot
* Currency
* Food, i.a., energy 
* Map pieces for room progression
* treasure keys 
#### UI

#### Additional ideas to be considered
* wind leads you to the boss or key points on map

