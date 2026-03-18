using System;

public class GitinityUI
{
    public static event Action OnSetup;
    public static event Action OnGetGitInfo;
    public static event Action OnGetFeatureInfo;
    public static event Action<bool> OnActivateAssetVCS;
    public static event Action<string, string> OnMerge;
    public static event Action<string> OnUnlockFile;
    public static event Action<string> OnStartFeature;
    public static event Action<string> OnLockFile;
    
    public static event Action<string> OnCommit;
    public static event Action OnPush;
    public static event Action OnPull;
    
    
    public static void FireOnSetup() => OnSetup?.Invoke();
    public static void FireOnGetGitInfo() => OnGetGitInfo?.Invoke();
    public static void FireOnActivateAssetVCS(bool setActive) => OnActivateAssetVCS?.Invoke(setActive);
    public static void FireOnMerge(string sourceBranch, string targetBranch) =>
        OnMerge?.Invoke(sourceBranch, targetBranch);
    public static void FireOnLockFile(string fileToLock) => OnLockFile?.Invoke(fileToLock);
    public static void FireOnUnlockFile(string fileToLock) => OnUnlockFile?.Invoke(fileToLock);
    public static void FireOnStartFeature(string featureName) => OnStartFeature?.Invoke(featureName);
    public static void FireOnGetFeatureInfo() => OnGetFeatureInfo?.Invoke();
    
    public static void FireOnCommit(string message) => OnCommit?.Invoke(message);
    public static void FireOnPush() => OnPush?.Invoke();
    public static void FireOnPull() => OnPull?.Invoke();
}
