using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    private InputData _inputData;
    public GameObject menu, saveMenu, finalMenu;
    public AudioSource engine;

    private bool menuOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        OpenCloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool buttonPressed)){
            if (buttonPressed == true){
                //Debug.Log("B PRESSED");
                OpenCloseMenu(); 
            }
            
        }
    }

    private void OpenCloseMenu(){
        if (menuOpen){
            menu.SetActive(false);
            menuOpen = false;
            Time.timeScale = 1;
            engine.UnPause();

            saveMenu.SetActive(false);
            finalMenu.SetActive(false);

        }
        else if (!menuOpen){
            menu.SetActive(true);
            menuOpen = true;
            Time.timeScale = 0;
            engine.Pause();
        }
        // if (menuOpen == false){
        //     menu.enabled = true;
        //     menuOpen = true;
        // }
        // else if (menuOpen == true){
        //     menu.enabled = false;
        //     menuOpen = false;
        // }
    }

    public void OpenSave(){

        //force close first menu para evitar erros
        menu.SetActive(false);
        menuOpen = false;

        saveMenu.SetActive(true);
    }

    public void OpenFinal(){
        saveMenu.SetActive(false);
        finalMenu.SetActive(true);
    }

    public void CloseMenu(){
        Time.timeScale = 1;
        finalMenu.SetActive(false);
    }

    public void GoBack(){
        menu.SetActive(true);
        menuOpen = true;
        saveMenu.SetActive(false);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void MainMenu(){
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(0);
    }
}
