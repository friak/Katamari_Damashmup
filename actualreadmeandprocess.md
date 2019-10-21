# The Process

## From another repo as homework I described this game as such:

*"Katamari/Kirby Air Ride Shmup: Katamari is a game about an alien that rolls objects up with a katamari or sticky ball thing, and the main goal of the game is to get to a specific circumfrence from accumulating enough objects in a certain amount of time. The twist on this classic game series for my shmup idea is that now the player has to avoid non roll-upable items while roll up specific objects for the katamari for one half of the level. The next half of the level is to use the kind of katamari that the player rolled up as ammo to now shoot down what was attacking the player before. Rolling up certain objects can give the player certain power ups, almost like Kirby Air Ride where you have to accumulate power ups for your vehicle and then battle against your friends in the next half of the level."*


## I then refined the idea:

*Player vs Game- This will be mainly player vs game (unless co-op mode is introduced in another iteration) where the player must go against the game bosses and attacks. Players also utilize items and resources that the game world has to provide.*

*The Objective and Basic Mechanics- To complete each level, the player has to collect and roll up a strategic plethora of powerups and items to then utilize their katamari as "ammo" that is used to defeat the boss of each level. This is done by throwing it at them and having it bounce back to the player. This is done all while trying to avoid bullet storms and items that can negatively affect your katamari ammo.*

*The Rules and Conflict- The level starts with a "collecting phase" where you roll up items around you in a set time span. You need to be strategic with how much you roll up because if your katamari is too big, you can't dodge the bullets as effectively; roll too small, you'll have a weak katamari with no powerups.*

*The powerups and items work in that there's some silly logic to them, and it's all about being creative; Say one of the bosses is a giant baby type, well babies hate scary things and vegetables (I don't know, I have cats not kids) so in the collecting phase you'd want to roll up spiders and brocolli! Or if the boss is a big wig banker, roll up the hippies and revolutionists! Keep in mind this phase of the game looks like a tradition katamari level where there's plenty of weird things to roll up in the environment.*

*The second phase of the level is combative, where the boss runs around the map while spewing bullets and dropping items, if you roll an item that hurts the objects of your katamari, you will be damaged and/or your katamari grows weak (say if you had a hippie heavy katamari and you roll over soap or debt bills, your katamari will get a hit! Again I don't know, this seems to be a game to get creative in though~)*

*Resources- Like the traditional katamari games, the world is your oyster! But again, be strategic with the seemingly endless resources, because this game is about finding the "right" resources in the "right" amount.*

*Narrative tidbit: "Katamari Damashmup is the fan-based alternate universe in Katamari Damacy where in the future the King of the Cosmos (your father! Gasp!) turns on you as you rise against him and his tyrannical rule to take his crown and restore peace to the Cosmos! But be wary young prince, as he has many goons (your cousins! Gasper!) on his side to stop you..."*

## And now, time to look at repos!

I'm using the shmup template dicribed in IGDPAD, Chapters 30 along with a Katamari unity clone by UnderGear (https://github.com/UnderGear/Klonamari) to begin the actualizing process of the game. I'm going to start by tweaking the enemies as collectable items that get attached to the katamari, and then I'm going to think about wanting to change the movement of the game to something more resembling of the Katamari games or staying in this shmup design. I'm then going to get to a boss in a different scene that spews bullet storms. Lastly, I'm gonna also work on using the katamari weapon a more boomerang type of weapon with aiming (mouse aiming). Lastly, I'm going to work with the two phases of the level, carrying static classes(?) across scenes.

## The Basic Idea

*Katamari DamaShmup*

A fan-made alternative katamari game where there a two phases to each level---a katamari building phase to optimize the best weapon against your opponent, and a combat phase where you put your katamari to use by bouncing it off the bullet-storm spewing boss!


## THE PROCESS PART 2

The new iterations of the game includes only having one phase; however, the element of Katamari is still presented through the anti-collecting element of the battle phese. The items the enemy drops can hurt your katamari and decreases your damage, if it gets too low, you will lose. I also ended up not using UnderGear's Klonamari elements, but may look back for future iterations after the class.


