# RushGun
Extremely simple shooting game I quickly made in one afternoon using Unity. Repo only includes the source code files, as I've lost the media files since then.
<iframe width="854" height="480" src="https://www.youtube.com/embed/MB-gdsrFPfU" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

### Code
* *RushGun\Player.cs:* handes user interaction and controls (e.g: UI)
* *RushGun\Glock.cs:* handles the gun behavior
* *RushGun\BulletStuck.cs:* stops bullets when they hit static objects and instantiates the corresponding particle and sound effects
* *RushGun\Spawner.cs:* spawns mobs on somehow random intervals and moves them across predefined paths. Uses Catmull–Rom splines for path smoothing.
* *RushGun\Overlord.cs:* handles the mobs behavior when hit by bullets
* *RushGun\Events.cs:* helps keeping source files more independent from each other, by providing common event delegates
