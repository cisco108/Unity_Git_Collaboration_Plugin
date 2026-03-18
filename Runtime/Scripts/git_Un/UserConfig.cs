using UnityEngine;
using UnityEditor;

public class UserConfig : ScriptableObject
{
    private static string assetName = "GitinityUserConfig";
    private const string AssetPath = "Assets/GitinityUserConfig.asset";

    private static UserConfig _instance;

    public static UserConfig instance
    {
        get
        {
            if (_instance != null) return _instance;

            _instance = AssetDatabase.LoadAssetAtPath<UserConfig>(AssetPath);
            if (_instance != null)
            {
                return _instance;
            }

            _instance = CreateInstance<UserConfig>();
            AssetDatabase.CreateAsset(_instance, AssetPath);
            AssetDatabase.SaveAssets();
            return _instance;
        }
    }

    public void Save()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }

    [HideInInspector] public string userEmail = "example@mail.com";
    [HideInInspector] public string logsFile = "logs.txt";
    [HideInInspector] public string lockedProtocolFile = "locked_files.json";
    [HideInInspector] public string diffPrefabsParentDirectory = "Assets/";
    [HideInInspector] public string diffPrefabsDirName = "DiffObjects_as_Prefabs/";
    [HideInInspector] public string versionControlledAssets = "Assets/VersionControlledAssets/";
    public string DiffPrefabsDirectory => diffPrefabsParentDirectory + diffPrefabsDirName;
    #if UNITY_EDITOR_WIN
    [HideInInspector] public string gitBashExe = @"C:\Program Files\Git\git-bash.exe";
#elif UNITY_EDITOR_LINUX
    [HideInInspector] public string gitBashExe = "/bin/bash";
#else
    [HideInInspector] public string gitBashExe = "bash";
#endif
    [HideInInspector] public string defaultBranchName = "master";
    [HideInInspector] public string remoteUrl = "Paste the http link for your empty repository.";
    [HideInInspector] public string allowCommitFile = ".allow_commit";
    [HideInInspector] public string setupGitHookFile = "setup_git_hook_asset_validation.sh";

    [HideInInspector] public bool useFileLocking = false;
    [HideInInspector] public bool useAssetVCS = false;
    // public string fileToLockName = "This file will the locked!";
}
