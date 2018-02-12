using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour {

    public GameObject Vehicle;

    public GameObject StartingObject;
    public GameObject TurningObject;
    public GameObject TurnedObject;
    public GameObject StoppingObject;

    private int reachturn = 0;
    private int turn = 0;
    private int afterturn = 0;
	// Use this for initialization
	void Start () {
        Vehicle.transform.position = StartingObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(reachturn == 0)
        {
            Vehicle.transform.position = Vehicle.transform.position + (TurningObject.transform.position - StartingObject.transform.position) * Time.deltaTime * 0.1f;
        }
        if(Mathf.Abs(Vehicle.transform.position.x - TurningObject.transform.position.x) < 0.08)
        {
            reachturn = 1;
        }
        if (reachturn == 1 && turn == 0)
        {
            Vehicle.transform.position = Vehicle.transform.position + (TurnedObject.transform.position - TurningObject.transform.position) * Time.deltaTime * 0.1f;
        }
        if (Mathf.Abs(Vehicle.transform.position.z - TurnedObject.transform.position.z) < 0.08)
        {
            turn = 1;
        }
        if (reachturn == 1 && turn == 1 && afterturn == 0)
        {
            Vehicle.transform.position = Vehicle.transform.position + (StoppingObject.transform.position - TurnedObject.transform.position) * Time.deltaTime * 0.1f;
        }
        if (Mathf.Abs(Vehicle.transform.position.z - StoppingObject.transform.position.z) < 0.08)
        {
            afterturn = 1;
        }
    }
}
