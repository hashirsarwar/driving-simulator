**What we added in the project**

- Scene enhancements:
    * Added rain to the environment.
    * Increased the size of the scene (including road and sky dom).

- Added multiplayer:
    * Added split screen to the game using two cameras.
    * Handled side cases for multiplayer gameplay.

- Added nitro boost:
    * Added particle system for the nitro boost.
    * Added motion blur when nitro is fired.
    * Corrected the physics of the cars and obstacles to work with nitro boost (e.g. replaced `Translate` with `AddForce`).

- Added jumping ability:
    * When player encounters an obstacle, it can jump over it to earn extra scores.

- Added scoring:
    * Made UI for scoring (on the top left + small tags appeared above the car).
    * Detected when a player jumps over an obstacle to earn positive points.
    * Detected when a player collides with an obstacle to earn negative point.
    * Detect which player is in the lead, and increment his points after every 5 seconds.

- Added sound effects:
    * Added SFX for rain, car's engine, nitro boost, jumping, hitting obstacles.
