# SaveFolderEditor

To use:

1. [Install BepInEx 5.x](https://docs.bepinex.dev/articles/user_guide/installation/index.html)
    * Do not use 6.0 prelease or bleeding edge.
	* Distance currently is 32-bit (x86).
2. Download the [latest release](https://github.com/Californ1a/SaveFolderEditor/releases/latest)
	* (Optional) Also download [BepInEx ConfigurationManager](https://github.com/BepInEx/BepInEx.ConfigurationManager)
3. Unzip it into Distance's root
4. Run the game
5. Edit the config to change the save folder name.
	* If using ConfigurationManager, hit F1 to open it and directly edit the save folder string while in-game.
	* Otherwise, close the game and manually edit the config file located in `<Distance install folder>\BepInEx\config\com.Californ1a.SaveFolderEditor.cfg`
6. The string put in will be appended to the folder name
	* Inputting `Test` will use the save folder `<Documents>\My Games\Distance-Test\`
	* Leaving the save folder blank will use the default folder location `<Documents>\My Games\Distance\`