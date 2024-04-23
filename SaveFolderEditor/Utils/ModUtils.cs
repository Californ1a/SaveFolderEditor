namespace SaveFolderEditor.Utils
{
    /// <summary>
    /// Static utilities class for common functions and properties to be used within your mod code
    /// </summary>
    internal static class ModUtils
    {
        public static void SetDirName(string name)
        {
            if (SaveFolderEditorPlugin.dirCahnged) return;

            SaveFolderEditorPlugin.initialSaveDirName = SaveFolderEditorPlugin.SaveDir.Value;
            if (!string.IsNullOrEmpty(name))
            {
                SaveFolderEditorPlugin.Log.LogInfo("Setting dir name: " + name);
                name = "-" + name;
            }
            string editedDir = SaveFolderEditorPlugin.initialDir + name + "/";
            SaveFolderEditorPlugin.Log.LogInfo("Using /" + editedDir);
            SaveFolderEditorPlugin.fullDir += editedDir;
            SaveFolderEditorPlugin.Log.LogInfo("Full path: " + SaveFolderEditorPlugin.fullDir);
        }

        public static void UndoSaveDirChange()
        {
            SaveFolderEditorPlugin.SaveDir.BoxedValue = SaveFolderEditorPlugin.initialSaveDirName;
        }
    }
}