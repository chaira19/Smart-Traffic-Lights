using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multivehicles : MonoBehaviour {

    public GameObject onemotion;
    private float Timer = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            GameObject anothermotion;

            anothermotion = Instantiate(onemotion, (new Vector3((Random.Range(-9, 9)), 5, 0)), transform.rotation) as GameObject;
            
            Timer = 10;

        }
    }
}
