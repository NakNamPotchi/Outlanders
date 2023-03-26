using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialStageCabinUnlock : MonoBehaviour
{
    public SceneFader fader;

    public Button cabinButton;

    private int CabinButtonInteract;

    void Start()
    {
        int CabinButtonInteract = PlayerPrefs.GetInt("CabinButtonInteract");

        if (CabinButtonInteract > 0)
            cabinButton.interactable = true;
        else
            cabinButton.interactable = false;
    }

    public void Select (string cabin)
    {
        fader.FadeTo(cabin);
    }
}
