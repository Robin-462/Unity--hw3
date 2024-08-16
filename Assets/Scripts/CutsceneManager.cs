using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector cutsceneDirector; 
    public CinemachineVirtualCamera gameplayCamera; // Reference to the gameplay camera
    public CowboyController cowboyController; // Reference to the player controller
    public GameObject objectBGM;
    public bool isCutscenePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        cutsceneDirector.Play();
        isCutscenePlaying = true;

        cowboyController.enabled = false;
        objectBGM.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCutscenePlaying)
        {
            // Check for escape key press or end of cutscene
            if (Input.GetKeyDown(KeyCode.Escape) || cutsceneDirector.time >= cutsceneDirector.duration - 1f)
            {
                SkipCutscene();
            }

        }
    }

    void SkipCutscene()
    {
        cutsceneDirector.Stop();
        isCutscenePlaying = false;
        objectBGM.SetActive(true);
        TransitionToGameplay();
    }

    void TransitionToGameplay()
    {
        // Activate gameplay camera
        gameplayCamera.Priority = 100;

        // Enable player control
        cowboyController.enabled = true;
    }
}
