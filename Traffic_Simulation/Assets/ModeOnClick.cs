using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeOnClick : MonoBehaviour {

    public static bool automatic = true;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changemode()
    {
        automatic = !automatic;
        if(automatic == true)
        {
            gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = "Click for Manual Mode";
        }
        else
        {
            gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = "Click for Automatic Mode";
        }
    }
}
