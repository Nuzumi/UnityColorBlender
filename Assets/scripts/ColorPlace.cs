using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlace : MonoBehaviour {

    public GameObject colorMixer;
    public Shader shader;

    private bool isOn;
    private GameObject colorPicker;
    private SpriteRenderer spriteRenderer;
    private GameObject line;
    private Helper.ColorEnum PlateColor;

    void Start()
    {
        isOn = true;
        colorPicker = GameObject.FindGameObjectWithTag("ColorPicker");
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        DrawLine(transform.position, colorMixer.transform.position, Color.gray);
    }

    private void OnMouseDown()
    {
        if (isOn)
        {
            colorPicker.GetComponent<ColorPicker>().Show(this);
        }
    }

    public void ChangeColor(Helper.ColorEnum color)
    {
        ColorMixer mixer = colorMixer.GetComponent<ColorMixer>();
        mixer.SetColor(gameObject, color);
        PlateColor = color;
        switch (color)
        {
            case Helper.ColorEnum.Red:
                spriteRenderer.color = Color.red;
                Destroy(line);
                DrawLine(transform.position, colorMixer.transform.position, Color.red);
                break;

            case Helper.ColorEnum.Green:
                spriteRenderer.color = Color.green;
                Destroy(line);
                DrawLine(transform.position, colorMixer.transform.position, Color.green);
                break;

            case Helper.ColorEnum.Blue:
                spriteRenderer.color = Color.blue;
                Destroy(line);
                DrawLine(transform.position, colorMixer.transform.position, Color.blue);
                break;
        }
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, bool fade = false)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.material = new Material(shader);
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.08f;
        lr.endWidth = 0.08f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        if (fade)
        {
            Destroy(myLine, 1.5f);
        }
        line = myLine;
    }

    public void Disable()
    {
        isOn = false;
    }

    public void Enable()
    {
        isOn = true;
    }
}
