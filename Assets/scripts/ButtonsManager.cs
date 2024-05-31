using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    int levelUnlock;
    public Button[] buttons;

    public void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels17", 1);
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = false;
        for (int i = 0; i < levelUnlock; i++)
            buttons[i].interactable = true;
    }
}
