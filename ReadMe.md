 

ASTEROIDS GAME

 

?Prepared for the Ga?me Designers.

 

 

?At? the beginning  the scene has CANVAS (UI Panels), GAME MANAGER and AUDIO MANAGER.

The Main Menu and the rest of UI elements are controlled by C# UIManager.cs (belongs to GAME MANAGER).

The CANVAS has 5 states (at the moment):

Logo

Main Menu

Playing Mode

Game Over

Game Over Menu

State n....

 

All Objects are collected in Assets/Prefabs.

 

You start the game by pressing PLAY button in Main Menu.

 

Main Menu => Playing Mode of CANVAS

Top Left corner for LIVES

Top Right corner for SCORES

 

In the centre the SHIP is spawn and after time DelaySpawAsteroids  ASTEROIDS are spawn ( qty and delay time are  controlled in GAME MANAGER=> GameManager script=>Level setup )

 

SHIP has Control Module (ShipControl script) and Collision Module (ShipCollisions script).

 

The SHIP can be controlled by Key UP and Down for force

                              Key Left and Right to turn

                              Key Space to shoot

Force and Turn of the SHIP you can change in the Inspector => ShipControll script

 

BULLET's life time and speed you can control in the GUN Inspector => GunFire script (GUN is a child of SHIP)

 

There are  3 types of ASTEROIDS:

Large

Medium

Small

Each Asteroid can have n of Children. It can be setup in the ASTEROID Inspector=> AsteroidCollisions script

Also there you can setup the POINTS after the ASTEROID was destroyed.

 

Start force and turnForce can be setup the Inspector=>AsteroidBehavior script.

 

When ASTEROID dies it spawns its children, till we have ASTEROID with no children.

 

Lives of SHIP we can setup in the GAME MANAGER Inspector=>GameManager script=> Max Lives.

 

SCREENBORDER object is for looping objects movement according the screen size  (when switch it off, the objects will go away)

 

The AUDIOMANAGER control's all sound clips in the game except Shoot audioClip and Explosion audioClip

Also we have a Audio Mixer (under construction connections)

Here we can add any qty of audioClips and set up volume, pitch and loop.

 

When Ship is dead and no lives any more we clean the screen and CANVAS mode change to GAME OVER panel, then after two sec mode will change to GameOverMenu.

 

In the finish game we store the HIGHSCORE and it will load on the launch game.

 