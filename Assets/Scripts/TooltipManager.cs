using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class TooltipManager : MonoBehaviour
{

    public static TooltipManager _instance; // singleton pattern 

    public TextMeshProUGUI textComponent; // ref to our TooltipText 

    [SerializeField] List<int> maxChars;  

    private void Awake()
    {
        if(_instance != null && _instance!= this)
        {
            Destroy(this.gameObject); 
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        // make the cursor visible to the player
        Cursor.visible = true;
        // as default the tooltip isn't showing 
        gameObject.SetActive(false); // disabling the tooltip box
        
    }

    void Update()
    {
        // tooltip box follows our mouse position 
        transform.position = Input.mousePosition; 
    }

    // hide and show: (these methods will be called by the object the mouse is hovering over) 
    public void SetAndShowTooltip(string msg)
    {
        gameObject.SetActive(true);
        textComponent.text = FormatString(msg); 
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty; 
    }

    public string FormatString(string msg)
    {
        
        // we create a list of strings (= lines) and split the text we have into those 
        // we take the first n chars of the string and then delete them from the remainder of the string.
        // we *go back* starting from n chars from the beginning and split at the first space we find 
        List<string> lines = new List<string>();

        if (!maxChars.Any()) // if the list is empty, set a default max chars value 
        {
            maxChars.Add(27); 
        }

        foreach (int max in maxChars)
        {
            // create and add a new line to the list: 

            // check for string length
            if (msg.Length >= max) 
            {
                for (int idx = max - 1; idx >= 0; idx--) // go back until find a space to split at 
                {
                    if (msg[idx].ToString() == " ")
                    {
                        lines.Add(msg.Substring(0, idx)); 
                        msg = msg.Substring(idx + 1); // beginning at next character after idx (i.e. skipping the space) 
                        break;
                    }
                }

            }
            else
            {
                lines.Add(msg);
                msg = string.Empty;
                // add what remains to the final list 
            }

        }
        // if there are more lines than accounted for in the list of lengths: 
        if (msg != string.Empty) // if there is more text, just add it here 
        {
            int maxValue = maxChars.Max(); // we use maximum value given in the array for fitting 
            while (msg.Length > maxValue)
            {
                for (int idx = maxValue - 1; idx >= 0; idx--) // go back until find a space to split at 
                {
                    if (msg[idx].ToString() == " ")
                    {
                        lines.Add(msg.Substring(0, idx));
                        msg = msg.Substring(idx + 1);
                        break;
                    }
                }
            }
            lines.Add(msg);
        }


        string result = string.Join("\n", lines.ToArray());

        return result; 
    }

}
