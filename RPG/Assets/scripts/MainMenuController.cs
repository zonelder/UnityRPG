using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private Cooldown _hideMenuTimer;
    private VisualElement _mainMenu;
    private VisualElement _exitMenu;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _mainMenu = root.Q<VisualElement>("mainMenu");
        _exitMenu = root.Q<VisualElement>("askForExit");

        root.Q<Button>("startButton").clicked+= StartButtonPressed;
        root.Q<Button>("settingButton").clicked+= SettingButtonPressed;
        root.Q<Button>("exitButton").clicked += ExitButtonPressed;

        root.Q<Button>("yesButton").clicked+=ExitConfirmed;
        root.Q<Button>("noButton").clicked += ExitDeny;

    }
    private void StartButtonPressed()
    {
        SceneManager.LoadScene("Test level");
    }
    private void SettingButtonPressed()
    {
        throw new System.NotImplementedException();
    }
    private void ExitButtonPressed()
    {
        // Without asking now
        _mainMenu.visible = false;
        _exitMenu.visible = true;
        Debug.Log("exit");
    }
    private void ExitConfirmed()
    {
        Application.Quit();
    }
    private void ExitDeny()
    {
        _mainMenu.visible = true;
        _exitMenu.visible = false;
    }
}
