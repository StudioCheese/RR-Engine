![Reel to Reel Logo Stroke](https://user-images.githubusercontent.com/69170079/180670272-a608a629-a62b-4f02-8d18-9e0d66a7092a.png)
![Logo Stroke](https://user-images.githubusercontent.com/69170079/174708107-ad028aba-22d2-43c5-ad11-a39537216eae.png)

# Description
The RR Engine is a Unity codebase for simulating and animating old animatronics, with various features to customize the viewing experience.

The sofware is split into two major sections. The Editor Mode allows users to maticulously look and edit animation files,
while giving a variety of analysis options. The Game Mode provides a first person view of the animatronic stages, 
allowing the user more customizablity in the presentation, while also giving simplified controls. The Game Mode also
has features to unlock special items as rewards for animating the simulated animatronics. This is usually stage props
or movable animatronics, allowing the player to create a fully custom stage or layout to host their animations.

# Credits
- The 64th Gamer (Codebase)
- Himitsu (Improved simulation effeciency)

The RR Engine and its creator should be credited in any derivative works.

# Plugins
A set of plugins are required for building properly, and are not included within the public codebase.
- [Open WAWV Parser](https://assetstore.unity.com/packages/tools/audio/open-wav-parser-90832#publisher)
- [Dynamic Bone ($20](https://assetstore.unity.com/packages/tools/animation/dynamic-bone-16743#description)
- [Off Screen Target Indicator](https://assetstore.unity.com/packages/tools/gui/off-screen-target-indicator-71799#publisher)
- [Standalone File Browser](https://github.com/gkngkc/UnityStandaloneFileBrowser)

# Switching Branches
Depending on whichever bracn is pushed with new updates, the default branch you might start in when opening the project could be different. Navigate to the "Scenes/Manger/Manager.unity" scene and open it. Click on the only object in the scene and look in the inspector. There a custom script will have buttons for switching between the 4 different builds. Click the branch button you want, then toggle the VR switch on or off to activate the branch switch. You may need to flick the VR switch a few times if it doesn't work. Be sure to open the game to be sure your branch has been switched to before leaving the Manager scene.
