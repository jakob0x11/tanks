### Architecture Decisions:

1. Godot 3
	- For some reason, with godot 4, C# is not compatible with deploying to the web platform
2. Mono / C#
	- Seeing as GDScript in Godot 3 does not play nice with "cyclical" dependencies, we need C# to implement things like the handy-dandy Controller pattern
	- Plus, it just makes for cleaner code (in my inexperienced opinion)