using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class BasicGitUI : EditorWindow
{
    private TextField _commitMessageField;
    private Button _commitButton;
    private Button _pushButton;
    private Button _pullButton;
    private string _commitMessage;

    [MenuItem("Tools/Gitinity/Basic Git")]
    public static void ShowWindow()
    {
        BasicGitUI wnd = GetWindow<BasicGitUI>();
        wnd.titleContent = new GUIContent("Basic Git");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        VisualTreeAsset asset = Resources.Load<VisualTreeAsset>("BasicGitUI");
        asset.CloneTree(root);

        _commitMessageField = root.Q<TextField>("commit-message");
        _commitButton = root.Q<Button>("commit-btn");
        _pushButton = root.Q<Button>("push-btn");
        _pullButton = root.Q<Button>("pull-btn");

        _commitMessageField.RegisterValueChangedCallback(evt => _commitMessage = evt.newValue);

        _commitButton.clicked += () => {
            if (string.IsNullOrEmpty(_commitMessage))
            {
                EditorUtility.DisplayDialog("Error", "Please enter a commit message.", "Ok");
                return;
            }
            GitinityUI.FireOnCommit(_commitMessage);
            _commitMessageField.SetValueWithoutNotify("");
            _commitMessage = "";
        };

        _pushButton.clicked += () => GitinityUI.FireOnPush();
        _pullButton.clicked += () => GitinityUI.FireOnPull();
    }
}
