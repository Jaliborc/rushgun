# RushGun
Extremely simple shooting game I quickly made in one afternoon using Unity. Repo only includes the source code files, as I've lost the media files since then.

[![](http://jaliborc.com/images/other/rushgun.jpg)](https://www.youtube.com/watch?v=MB-gdsrFPfU)

[Video preview](https://www.youtube.com/watch?v=MB-gdsrFPfU)

### Code
* *Player.cs:* handes user interaction and controls (e.g: UI)
* *Glock.cs:* handles the gun behavior
* *BulletStuck.cs:* stops bullets when they hit static objects and instantiates the corresponding particle and sound effects
* *Spawner.cs:* spawns mobs on somehow random intervals and moves them across predefined paths. Uses Catmull–Rom splines for path smoothing.
* *Overlord.cs:* handles the mobs behavior when hit by bullets
* *Events.cs:* helps keeping source files more independent from each other, by providing common event delegates
