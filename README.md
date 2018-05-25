# RushGun
A simple shooting game I quickly made in one afternoon using Unity. It was my code sample to be hired at DeltaEngine, as I had no C# code I could share at the time:

* *RushGun\Player.cs:* handes user interaction and controls (e.g: UI)
* *RushGun\Glock.cs:* handles the gun behavior
* *RushGun\BulletStuck.cs:* stops bullets when they hit static objects and instantiates the corresponding particle and sound effects
* *RushGun\Spawner.cs:* spawns mobs on somehow random intervals and moves them across predefined paths. Uses Catmull–Rom splines for path smoothing.
* *RushGun\Overlord.cs:* handles the mobs behavior when hit by bullets
* *RushGun\Events.cs:* helps keeping source files more independent from each other, by providing common event delegates

[Video of the game](https://www.youtube.com/watch?v=MB-gdsrFPfU)
[Binaries for windows and mac](https://github.com/jaliborc/rushgun/releases)
