using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour {

    public List<GameObject> connectedColorPlatesList;
    public List<GameObject> connectedMixersAndWiningElements;

    protected SpriteRenderer spriteRenderer;
    protected List<Tuple<GameObject, Helper.ColorEnum>> coloredPlateList;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coloredPlateList = new List<Tuple<GameObject, Helper.ColorEnum>>();
        foreach(GameObject go in connectedColorPlatesList)
        {
            coloredPlateList.Add(new Tuple<GameObject, Helper.ColorEnum>(go, Helper.ColorEnum.non));
        }
    }

    public void SetColor(GameObject gameObject,Helper.ColorEnum color)
    {
        foreach(Tuple<GameObject,Helper.ColorEnum> t in coloredPlateList)
        {
            if(t.item1 == gameObject)
            {
                t.item2 = color;
                break;
            }
        }
        ChangeColor();
    }

    public void SetColor(GameObject gameObject, Color color)
    {

    }

    protected void ChangeColor()
    {
        Color color;
        int redCounter = 0;
        int greenCounter = 0;
        int blueCounter = 0;

        foreach(Tuple<GameObject, Helper.ColorEnum> t in coloredPlateList)
        {
            if(t.item2 == Helper.ColorEnum.Red)
            {
                redCounter++;
            }
            else
            {
                if(t.item2 == Helper.ColorEnum.Green)
                {
                    greenCounter++;
                }
                else
                {
                    if(t.item2 == Helper.ColorEnum.Blue)
                    {
                        blueCounter++;
                    }
                }
            }
        }

        if(redCounter>1 || greenCounter>1 || blueCounter > 1)
        {
            color = new Color((float)redCounter / coloredPlateList.Count,(float) greenCounter / coloredPlateList.Count, (float)blueCounter / coloredPlateList.Count);
        }
        else
        {
            color = new Color(redCounter, greenCounter, blueCounter);
        }

        spriteRenderer.color = color;
        foreach(GameObject go in connectedMixersAndWiningElements)
        {
            go.GetComponent<ColorMixer>().ChangeColor()
        }
    }
}
