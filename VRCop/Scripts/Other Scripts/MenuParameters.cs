using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuParameters : MonoBehaviour
{

    float aggroSliderValue;
    float fearSliderValue;  
    float exitSliderValue;

    void Start(){
        aggroSliderValue = GameObject.Find("AggroSlider").GetComponent<Slider>().value;
        fearSliderValue = GameObject.Find("FearSlider").GetComponent<Slider>().value;
        exitSliderValue = GameObject.Find("ExitSlider").GetComponent<Slider>().value;
    }
    public void SetParameters(){
        Constants.agression = aggroSliderValue;
        Constants.fear = fearSliderValue;
        Constants.chanceOfExiting = exitSliderValue;
    }
}
