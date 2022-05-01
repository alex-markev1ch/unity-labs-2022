using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    // this script is dragged onto objects that require a tooltip 
    public string message; // will be set in Editor 

    private void OnMouseEnter()
    {
        TooltipManager._instance.SetAndShowTooltip(message);
    }
    private void OnMouseExit()
    {
        TooltipManager._instance.HideTooltip(); 
    }
}
