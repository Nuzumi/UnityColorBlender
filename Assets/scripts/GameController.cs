using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    List<GameObject> ColorPlacesList;
    
	void Start ()
    {
        ColorPlacesList = new List<GameObject>(GameObject.FindGameObjectsWithTag("ColorPlace"));
	}
	
    public void DisableClick()
    {
        foreach(GameObject o in ColorPlacesList)
        {
            o.GetComponent<ColorPlace>().Disable();
        }
    }

    public void EnableClick()
    {
        foreach (GameObject o in ColorPlacesList)
        {
            o.GetComponent<ColorPlace>().Enable();
        }
    }
}
