using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour {

    public GameObject[] Vehicles = new GameObject[12];

    public GameObject[] StartingObjects = new GameObject[8];
    public GameObject[] TurningObjects = new GameObject[8];
    public GameObject[] TurnedObjects = new GameObject[8];
    public GameObject[] StoppingObjects = new GameObject[8];

    private int reachturn = 0;
    private int turn = 0;
    private int afterturn = 0;
    private int vehicleno;
    private int startingpoint;
    private int endingpoint;
	// Use this for initialization
	void Start () {
        if(ModeOnClick.automatic == true)
        {
            vehicleno = Random.Range(0, 11);
            startingpoint = Random.Range(0, 7);
            endingpoint = Random.Range(0, 7);
        }
        Vehicles[vehicleno].transform.position = StartingObjects[startingpoint].transform.position;
        Vehicles[vehicleno].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        
        if(reachturn == 0)
        {
            Vehicles[vehicleno].transform.position = Vehicles[vehicleno].transform.position + (TurningObjects[startingpoint].transform.position - StartingObjects[startingpoint].transform.position) * Time.deltaTime * 0.1f;
            Vehicles[vehicleno].transform.LookAt(TurningObjects[startingpoint].transform);
        }
        if(distance(Vehicles[vehicleno], TurningObjects[startingpoint]) < 0.08)
        {
            reachturn = 1;
        }
        if (reachturn == 1 && turn == 0)
        {
            Vehicles[vehicleno].transform.position = Vehicles[vehicleno].transform.position + (TurnedObjects[endingpoint].transform.position - TurningObjects[startingpoint].transform.position) * Time.deltaTime * 0.1f;
            Vehicles[vehicleno].transform.LookAt(TurnedObjects[endingpoint].transform);
        }
        if (distance(Vehicles[vehicleno], TurnedObjects[endingpoint]) < 0.08)
        {
            turn = 1;
        }
        if (reachturn == 1 && turn == 1 && afterturn == 0)
        {
            Vehicles[vehicleno].transform.position = Vehicles[vehicleno].transform.position + (StoppingObjects[endingpoint].transform.position - TurnedObjects[endingpoint].transform.position) * Time.deltaTime * 0.1f;
            Vehicles[vehicleno].transform.LookAt(StoppingObjects[endingpoint].transform);
        }
        if (distance(Vehicles[vehicleno], StoppingObjects[endingpoint]) < 0.08)
        {
            afterturn = 1;
        }
    }

    private float distance(GameObject a, GameObject b)
    {
        float x = a.transform.position.x - b.transform.position.x;
        float y = a.transform.position.y - b.transform.position.y;
        float z = a.transform.position.z - b.transform.position.z;

        return x * x + y * y + z * z;
    }
}
