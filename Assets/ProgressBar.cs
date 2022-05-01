using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]

public class ProgressBar : MonoBehaviour
{
    public float maxXp;
    public float curXp;

    [SerializeField]
    private Image filledBar;
    [SerializeField]
    private Color filledBarColor;

    private RectTransform filledBarTransform;
    private float CurXpBarRatio
    {
        get
        {
            if (this.maxXp == 0)
            {
                return 0;
            }

            return this.curXp / this.maxXp;
        }
    }
    void Start()
    {
         this.filledBar.color = this.filledBarColor;
        this.filledBarTransform = this.filledBar.GetComponent<RectTransform>();
    
    }

    // Update is called once per frame
    void Update()
    {
        this.filledBar.color = this.filledBarColor;

        Vector3 newFilledBarScale = this.filledBarTransform.localScale;
        newFilledBarScale.x = this.CurXpBarRatio;

        this.filledBarTransform.localScale = newFilledBarScale; 
    }
}
