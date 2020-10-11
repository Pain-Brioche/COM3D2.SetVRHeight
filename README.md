## SetVRHeight

Simple plugin to adjust vertical position in VR, for those, like me, who'd rather look their maids in the eyes rather than their belly buttons.

### Install
- BepinEx required
- Copy COM3D2.SetVRHeight.plugin.dll in \COM3D2\BepinEx\plugins

### Usage
- Just play in VR
- plugin is disabled in dance to avoid camera glitch.
- You can change the height settings in the config (requires the game to be run at least once for the config file to be created)
- Values are in increase height relative to the default camera height, meaning 0.0 will do nothing while 0.5 will make you a giant (you can use more than one decimal)
- Karaoke has a separate setting, on account of needing less change.

### Known issues
- During yotogi skill selection, camera will be a bit too high. This is due to the fact that it's the only part in the game where the default height makes sense, and I haven't found a way to isolate this scene.
- Some scenes have eye level camera, as such you'll be taller than needed.
