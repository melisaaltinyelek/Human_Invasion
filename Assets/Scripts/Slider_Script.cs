using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Slider_Script : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSouls (int souls)
    {
        // Set maximum amount of haelth
        slider.maxValue = souls;
        // Slider starts at maximum amount of health
        slider.value = souls;

    }
    public void SetSouls(int souls)
    {   
        //  Slider adjusts values on the life bar
        slider.value = souls;
    }
}
