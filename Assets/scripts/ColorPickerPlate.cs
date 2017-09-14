using UnityEngine;

public class ColorPickerPlate : MonoBehaviour {

    public Helper.ColorEnum color;

    private GameObject colorPicker;

    private void Start()
    {
        colorPicker = transform.parent.gameObject;
    }

    private void OnMouseDown()
    {
        colorPicker.GetComponent<ColorPicker>().ColorPicked(color);
    }


}
