using HarmonyLib;

namespace SaveFolderEditor.Patches
{
    // TODO Review this file and update to your own requirements, or remove it altogether if not required

    /// <summary>
    /// Sample Harmony Patch class. Suggestion is to use one file per patched class
    /// though you can include multiple patch classes in one file.
    /// Below is included as an example, and should be replaced by classes and methods
    /// for your mod.
    /// </summary>
    [HarmonyPatch(typeof(Resource))]
    internal class ResourcePatch
    {
        /// <summary>
        /// Skip checking for old folder structure
        /// </summary>
        /// <param name="__result"></param>
        /// <returns></returns>
        [HarmonyPatch(typeof(MainMenuLogic), "IfUsingOldVersionOfDocumentsFolder")]
        [HarmonyPrefix]
        static bool IfUsingOldVersionOfDocumentsFolderPatch(ref bool __result)
        {
            __result = false;
            return false;
        }

        /// <summary>
        /// Skip deleting old folder structure
        /// </summary>
        /// <param name="__result"></param>
        /// <returns></returns>
        [HarmonyPatch(typeof(LevelSetsManager))]
        [HarmonyPatch(nameof(LevelSetsManager.DeleteOldDocumentsFilesAndFolders))]
        [HarmonyPrefix]
        static bool DeleteOldDocumentsFilesAndFoldersPatch(ref bool __result)
        {
            __result = false;
            return false;
        }

        /// <summary>
        /// Replace personal Distance directory with the new one
        /// </summary>
        /// <param name="___personalDistanceDirPath_"></param>
        [HarmonyPatch(nameof(Resource.GetLeaderboardsFolderForLevel))]
        [HarmonyPrefix]
        static void GetLeaderboardsFolderForLevelPatch(ref string ___personalDistanceDirPath_)
        {
            ___personalDistanceDirPath_ = SaveFolderEditorPlugin.fullDir;
        }

        /// <summary>
        /// Update color presets directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalColorPresetsDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalColorPresetsDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "ColorPresets/";
        }

        /// <summary>
        /// Update control schemes directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalControlSchemesDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalControlSchemesDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "ControlSchemes/";
        }

        /// <summary>
        /// Update custom objects directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalCustomObjectsDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalCustomObjectsDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "CustomObjects/";
        }

        /// <summary>
        /// Update editor config directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalEditorConfigDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalEditorConfigDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "EditorConfig/";
        }

        /// <summary>
        /// Update level playlists directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalLevelPlaylistsDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalLevelPlaylistsDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "LevelPlaylists/";
        }

        /// <summary>
        /// Update levels directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalLevelsDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalLevelsDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "Levels/";
        }

        /// <summary>
        /// Update level sets directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalLevelSetsDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalLevelSetsDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "LevelSets/";
        }

        /// <summary>
        /// Update local leaderboards directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalLocalLeaderboardsDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalLocalLeaderboardsDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "LocalLeaderboards/";
        }

        /// <summary>
        /// Update profiles directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalProfilesDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalProfilesDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "Profiles/";
        }

        /// <summary>
        /// Update settings directory with the new one
        /// </summary>
        /// <param name="__result"></param>
        [HarmonyPatch(nameof(Resource.PersonalSettingsDirPath_), MethodType.Getter)]
        [HarmonyPostfix]
        static void PersonalSettingsDirPath_Patch(ref string __result)
        {
            __result = SaveFolderEditorPlugin.fullDir + "Settings/";
        }
    }
}