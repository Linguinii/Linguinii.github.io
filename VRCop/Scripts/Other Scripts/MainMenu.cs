using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject panel, setupPanel, replayPanel, currentPanel, previousPanel;
    private MenuParameters menuParameters;

    void Start()
    {
        DeactivatePanels();
    }

    public void OpenSetup(){
        panel.SetActive(false);
        setupPanel.SetActive(true);
        currentPanel = setupPanel;
        previousPanel = panel;
    }

    public void OpenReplays(){
        panel.SetActive(false);
        replayPanel.SetActive(true);
        currentPanel = replayPanel;
        previousPanel = panel;
    }
    
    public void Back(){
        currentPanel.SetActive(false);
        previousPanel.SetActive(true);
    }

    public void StartSim(){
        menuParameters.SetParameters();
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(1);
        Debug.Log("Agression: "         + Constants.agression + "\n" +
                  "Fear: "              + Constants.fear + "\n" +
                  "Chance Of Exiting: " + Constants.agression + "\n");
    }

    void DeactivatePanels(){
        //panel.SetActive(false);
        setupPanel.SetActive(false);
        replayPanel.SetActive(false);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
