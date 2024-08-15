using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector cutsceneDirector; 
    public CinemachineVirtualCamera gameplayCamera; // Reference to the gameplay camera
    public PlayerController playerController; // Reference to the player controller
    public bool isCutscenePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        isCutscenePlaying = true;
        cutsceneDirector.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCutscenePlaying)
        {
            // Check for escape key press
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SkipCutscene();
            }
        }
    }

    void SkipCutscene()
    {
        cutsceneDirector.Stop();
        isCutscenePlaying = false;
        TransitionToGameplay();
    }

    void TransitionToGameplay()
    {
        // Activate gameplay camera
        gameplayCamera.Priority = 100; // Or any high priority value

        // Enable player control
        playerController.enabled = true;
    }
}
