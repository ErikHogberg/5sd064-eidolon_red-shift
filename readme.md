5SD064 - Game Design 2
======================
Group Eidolon - Red Shift
-------------------------

Folder/project structure:
* Assets
    * Audio
        * Sound Effects 
        * Background Music
    * Graphics
        * Characters
        * Environment
* Prefabs - Unity prefabs, with any scripts (or other components) that belong to only that prefab. 
    * Characters - Player, controlled units, enemies, bosses
    * Environment - World building blocks
    * Mechanics - Misc parts, such as camera, triggers, projectiles, etc.
* Scripts - For scripts that either don't belong to a prefab, or are used by multiple prefabs.
* Scenes
    * Cutscenes
    * Levels
    * Menus - For main menu, settings menu, and other menus. 
    Note that the pause menu is not a scene, but an overlay on gameplay scenes.
    * Test Scenes
        * Individual Test Scenes - Personal folders for personal test scenes that you don't want others to touch
            * \[one folder for every member]
        * Mechanics - Scenes for testing specific mechanics

Known issues
* Empty directories are ignored by git, which causes issues if an ignored folder was created inside of Unity, which creates a *.meta* file for the folder (placed outside the folder) which will throw an error if the folder specified in the *.meta* file is missing
    * This error is mostly encountered if someone makes an empty folder in unity and uploads it to the git repo, causing everyone elso who downloads the commit to receive the error.
    * This can be avoided (if you really want to add an empty folder) by adding a placeholder object to the folder, such as an empty prefab, or an empty scene.
* "case sensetive file system" fatal unity error
    * Depending on what git GUI client or system terminal you use to clone the repo, you might get this error.
    * The only solution is to use a different way to clone it, either by downloading the zip with the repo from the web page, or by using the official "GitHub Desktop" application, which has been tested.