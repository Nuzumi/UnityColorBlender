using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiningElement : ColorMixer {

    public Color winingColor;

    private new void ChangeColor()
    {
        Color color;
        int redCounter = 0;
        int greenCounter = 0;
        int blueCounter = 0;

        foreach (Tuple<GameObject, Helper.ColorEnum> t in coloredPlateList)
        {
            if (t.item2 == Helper.ColorEnum.Red)
            {
                redCounter++;
            }
            else
            {
                if (t.item2 == Helper.ColorEnum.Green)
                {
                    greenCounter++;
                }
                else
                {
                    if (t.item2 == Helper.ColorEnum.Blue)
                    {
                        blueCounter++;
                    }
                }
            }
        }

        if (redCounter > 1 || greenCounter > 1 || blueCounter > 1)
        {
            color = new Color((float)redCounter / coloredPlateList.Count, (float)greenCounter / coloredPlateList.Count, (float)blueCounter / coloredPlateList.Count);
        }
        else
        {
            color = new Color(redCounter, greenCounter, blueCounter);
        }

        spriteRenderer.color = color;
        if(color == winingColor)
        {
            Win();
        }

    }

    private void Win()
    {
        Debug.Log("Won");
    }
}
