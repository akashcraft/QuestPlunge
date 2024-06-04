ECE 5010 Group 5 README File

Software Type - 2D Platformer Game
Name - Season Plunge
Built using Unity

Group Members -
Akash Samanta (20211671)
Abdulrahman Abdulghani (202103750)

Brief Description
Season Plunge is a 2D Platformer featuring 6 levels of varying difficulties and challenges throughtout.
Each level has its own unique set of puzzles, traps and/or enemies that are very different to solve or tackle. This was done to minimize simple "copy pasting" of prefabs all around. There is also a Boss Level in Level 6.

Auxiliary Files - 
Images, Resources, Textures, Music Folders
4 of the background Music (BGM) used in the Game were made from scratch by Abdulrahman. Built on FLSTUDIO.
Many of the Sprites and Assets were Staged and Created on PowerPoint and Photoshop before Importing to Unity by Akash.
The main character in game (called Ethan the Hero) and Explosions are the only assets downloaded from Unity Store.
All SFX Audio was acquired from the Internet.

Instructions - 
1) Install Unity Hub and Editor
2) Place all C# .cs files in the Project Root of Unity.
3) Remaining Auxiliary Folders (Not Included) need to be placed inside Assets Folder.
4) Also Drag other folders (Not Included) in the Project Root.
5) Install LeanTween Package in Unity Package Manager.
6) Also install Ethan The Hero, Unity Explosion Pack from Unity Store.
7) You can either run the game using Unity Editor or the .exe file in the compiled Build Folder (Not Included).
8) You may also request Unity Cloud access from us. The game is available through Unity Cloud Collaboration.

The game is also planned to be showcased on https://www.akashcraft.ca after the completion of this semester.

The remainder of this README file gives a brief information on what each script does.

BoatLogic.cs = Handles Animation and State of the Boat found in Level 4
BossLogic.cs = Handles Animation and State of the Evil Square Boss found in Level 6
CamelSpawner.cs = Responsible for Spawning and Destroying Camels in Level 3
CameraControl.cs = Small Script to always follow Player Position
CannonBallLogic.cs = Handles the Cannon Ball found in Level 6 and causes Enemy Damage
CoinLogic.cs = Responsible for Animating Coins across the Game and Updating Coin Value
CrushLogic.cs = Triggers Instant Player Death if Player is trapped in Crusher
FireCharge.cs = Handles the Fire Charges from Ghast found in Level 2 and causes Player Damage
FlagUp.cs = Triggers a Flag Hoisting Animation for all CheckPoints in Game
FlintLogic.cs = For Animating Flint and Steel, Checking if Player has picked up the item and Activating Nether Portal found in Level 2
GateLogic.cs = Checking for Key for Locked Gate to open in Level 3
GhastLogic.cs = Handles Ghast Fire Charge Spawning within certain intervals found in Level 2
GoldBlockLogic.cs = For Displaying Mario Style Power Up Pickups in Level 3 and Level 4
HealthLogic.cs = Main Script to show Remaining Health of Player, Respawn Player, Update Health Value
KeyLogic.cs = For Animating Key, Checking if Player has picked up the item found in Level 3
LadderLogic.cs = Controlling all Ladders found in Level 1 and Level 3
MainLoad.cs = For Loading Last Game Level Save
MusicHandler.cs = Important for Controlling for BGM and SFX sounds
PauseButtonLogic.cs = Resume, Reset Level, Main Menu and Quit Functionality in In Game Menu
PauseMenu.cs = Handles Animation to show Pause Menu. Also freezes/unfreezes Game State
PlayerLogic.cs = Important for Player Ground and Jump Movement
PortalLogic.cs = Teleports Player in Level 2
PowerLogic.cs = Handles all Power Ups in Game
PowerPickupLogic.cs = Similar to PowerLogic.cs but is free of cost when item is picked up
PushableBox.cs = Small Script to Apply Force on PushableBoxes in Game depending on Player velocity
SettingsLoad.cs = Game Settings/About Page/Level Select Navigation
SoundPlayerLogic.cs = Triggers a Single SFX when Player triggers hitbox. Can be Repeated using Boolean.
SpikeLogic.cs = Very Important for all Active and Passive Enemies in Game. Not just Spikes!
VolumeChanger.cs = To change BGM or SFX Volume in Settings

Total Scripts = 33


