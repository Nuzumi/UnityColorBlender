using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {

    private ColorPlace actualColorPlace;
    private GameController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameObject.SetActive(false);
    }

    public void Show(ColorPlace colorPlace)
    {
        controller.DisableClick();
        gameObject.SetActive(true);
        actualColorPlace = colorPlace;
    }

    public void ColorPicked(Helper.ColorEnum color)
    {
        actualColorPlace.ChangeColor(color);
        gameObject.SetActive(false);
        actualColorPlace = null;
        controller.EnableClick();
    }
}
