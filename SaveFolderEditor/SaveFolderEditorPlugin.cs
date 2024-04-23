using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SaveFolderEditor.Properties;
using SaveFolderEditor.Utils;

namespace SaveFolderEditor
{
    [BepInPlugin(ModInfo.MyGUID, ModInfo.PluginName, ModInfo.Version)]
    public class SaveFolderEditorPlugin : BaseUnityPlugin
    {
        public const string initialDir = "My Games/Distance";
        public static string initialSaveDirName = "";
        public static bool dirCahnged = false;
        public static string fullDir = "";

        // Config entry key strings
        // These will appear in the config file created by BepInEx and can also be used
        // by the OnSettingsChange event to determine which setting has changed.
        public static string SaveDirKey = "Save Dir";

        // Configuration entries. Static, so can be accessed directly elsewhere in code via
        // e.g.
        // float myFloat = PLUGINCLASS.FloatExample.Value;
        public static ConfigEntry<string> SaveDir;

        private readonly Debouncer debouncer = new Debouncer();


        private static readonly Harmony Harmony = new Harmony(ModInfo.MyGUID);
        internal static ManualLogSource Log;

        /// <summary>
        /// Initialise the configuration settings and patch methods
        /// </summary>
        private void Awake()
        {

            fullDir = Resource.personalDirPath_;
            Log = BepInEx.Logging.Logger.CreateLogSource(ModInfo.PluginName);

            // SaveDir configuration setting
            SaveDir = Config.Bind("General",    // The section under which the option is shown
                SaveDirKey,                            // The key of the configuration option
                "",                            // The default value
                "Extra text to add after the Distance folder name to use as a different save folder.");         // Description that appears in Configuration Manager

            // Add listeners methods to run if and when settings are changed by the player.
            SaveDir.SettingChanged += ConfigSettingChanged;

            // Apply all of our patches
            Log.LogInfo("Start loading...");

            ModUtils.SetDirName(SaveDir.Value);
            Harmony.PatchAll();

            Log.LogInfo("Done loading");

        }

        public static void SaveDirChanged()
        {
            Log.LogInfo("Save folder config changed: " + SaveDir.Value);
            if (SaveDir.Value == initialSaveDirName) return;

            G.Sys.MenuPanelManager_.ShowYesNo(
                "Game save folder changed, restart to take effect.\n\nQuit now?\n(No will revert change)",
                "Save Folder Updated",
                G.Sys.GameManager_.QuitGame,
                ModUtils.UndoSaveDirChange);
        }

        /// <summary>
        /// Method to handle changes to configuration made by the player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigSettingChanged(object sender, System.EventArgs e)
        {
            SettingChangedEventArgs settingChangedEventArgs = e as SettingChangedEventArgs;

            // Check if null and return
            if (settingChangedEventArgs == null) return;

            // SaveDir setting changed handler
            if (settingChangedEventArgs.ChangedSetting.Definition.Key == SaveDirKey)
            {
                debouncer.Debounce(SaveDirChanged, 500);
            }
        }
    }
}
