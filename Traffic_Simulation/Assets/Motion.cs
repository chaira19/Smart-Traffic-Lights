using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour {

    public GameObject[] Vehicles = new GameObject[12];

    public GameObject[] StartingObjects = new GameObject[8];
    public GameObject[] TurningObjects = new GameObject[8];
    public GameObject[] TurnedObjects = new GameObject[8];
    public GameObject[] StoppingObjects = new GameObject[8];

    public float speed;

    private GameObject Vehicle;

    private int reachturn = 0;
    private int turn = 0;
    private int afterturn = 0;
    private int vehicleno;
    private int startingpoint;
    private int endingpoint;

    private static int A = 0;
    private static int B = 0;
    private static int C = 0;
    private static int D = 0;

    private static bool goA = true, goB = true, goC = true, goD = true;
    private bool move = true;

    public int threshold = 3;

	// Use this for initialization
	void Start () {
        if(ModeOnClick.automatic == true)
        {
            vehicleno = Random.Range(0, 11);
            startingpoint = Random.Range(0, 7);
            endingpoint = Random.Range(0, 7);
        }
        if(Vehicles[vehicleno].activeSelf == false)
        {
            Vehicle = Vehicles[vehicleno];
            Vehicle.SetActive(true);
        }
        else
        {
            Vehicle = Instantiate(Vehicles[vehicleno], (new Vector3((Random.Range(-9, 9)), 5, 0)), transform.rotation) as GameObject;
        }
        Vehicle.transform.position = StartingObjects[startingpoint].transform.position;

        if(startingpoint == 0 || startingpoint == 1)
        {
            A++;
            //move = goA;
        }
        else if(startingpoint == 2 || startingpoint == 3)
        {
            B++;
            //move = goB;
        }
        else if(startingpoint == 4 || startingpoint == 5)
        {
            C++;
            //move = goC;
        }
        else if(startingpoint == 6 || startingpoint == 7)
        {
            D++;
            //move = goD;
        }
    }

    // Update is called once per frame
    void Update () {

        
        if(reachturn == 0 && move == true)
        {
            Vehicle.transform.position = Vehicle.transform.position + (TurningObjects[startingpoint].transform.position - StartingObjects[startingpoint].transform.position) * Time.deltaTime * 0.1f*speed;
            Vehicle.transform.LookAt(TurningObjects[startingpoint].transform);
        }
        if(distance(Vehicle, TurningObjects[startingpoint]) < 0.08 && reachturn == 0)
        {
            reachturn = 1;
            if (startingpoint == 0 || startingpoint == 1)
            {
                A--;
            }
            else if (startingpoint == 2 || startingpoint == 3)
            {
                B--;
            }
            else if (startingpoint == 4 || startingpoint == 5)
            {
                C--;
            }
            else if (startingpoint == 6 || startingpoint == 7)
            {
                D--;
            }
        }
        if (reachturn == 1 && turn == 0)
        {
            Vehicle.transform.position = Vehicle.transform.position + (TurnedObjects[endingpoint].transform.position - TurningObjects[startingpoint].transform.position) * Time.deltaTime * 0.1f*speed;
            Vehicle.transform.LookAt(TurnedObjects[endingpoint].transform);
        }
        if (distance(Vehicle, TurnedObjects[endingpoint]) < 0.08 && turn == 0)
        {
            turn = 1;
            if (endingpoint == 0 || endingpoint == 1)
            {
                A++;
            }
            else if (endingpoint == 2 || endingpoint == 3)
            {
                B++;
            }
            else if (endingpoint == 4 || endingpoint == 5)
            {
                C++;
            }
            else if (endingpoint == 6 || endingpoint == 7)
            {
                D++;
            }
        }
        if (reachturn == 1 && turn == 1 && afterturn == 0)
        {
            Vehicle.transform.position = Vehicle.transform.position + (StoppingObjects[endingpoint].transform.position - TurnedObjects[endingpoint].transform.position) * Time.deltaTime * 0.1f*speed;
            Vehicle.transform.LookAt(StoppingObjects[endingpoint].transform);
        }
        if (distance(Vehicle, StoppingObjects[endingpoint]) < 0.4 && afterturn == 0)
        {
            afterturn = 1;
            if (endingpoint == 0 || endingpoint == 1)
            {
                A--;
            }
            else if (endingpoint == 2 || endingpoint == 3)
            {
                B--;
            }
            else if (endingpoint == 4 || endingpoint == 5)
            {
                C--;
            }
            else if (endingpoint == 6 || endingpoint == 7)
            {
                D--;
            }
            Vehicle.SetActive(false);
        }
        
        if(reachturn == 0)
        {
            if (startingpoint == 0 || startingpoint == 1)
            {
                move = goA;
            }
            else if (startingpoint == 2 || startingpoint == 3)
            {
                move = goB;
            }
            else if (startingpoint == 4 || startingpoint == 5)
            {
                move = goC;
            }
            else if (startingpoint == 6 || startingpoint == 7)
            {
                move = goD; 
            }
        }
        Debug.Log(A.ToString() + B.ToString() + C.ToString() + D.ToString());
        
        if (A < threshold && B < threshold && C < threshold && D < threshold)
        {
            goA = true;
            goB = true;
            goC = true;
            goD = true;
        }
        /* // First Algorithm
        else if(A>=threshold && B<threshold && C<threshold && D<threshold)
        {
            goA = true;
            goB = false;
            goC = false;
            goD = false;
        }
        else if (A < threshold && B >= threshold && C < threshold && D < threshold)
        {
            goA = false;
            goB = true;
            goC = false;
            goD = false;
        }
        else if (A < threshold && B < threshold && C >= threshold && D < threshold)
        {
            goA = false;
            goB = false;
            goC = true;
            goD = false;
        }
        else if (A < threshold && B < threshold && C < threshold && D >= threshold)
        {
            goA = false;
            goC = false;
            goB = false;
            goD = true;
        }*/

        // Second Algorithm

        else if (A >= B && A >= C && A >= D)
        {
            goA = true;
            goB = false;
            goC = false;
            goD = false;
        }
        else if (B >= A && B >= C && B >= D)
        {
            goA = false;
            goB = true;
            goC = false;
            goD = false;
        }
        else if (C >= A && C >= B && C >= D)
        {
            goA = false;
            goB = false;
            goC = true;
            goD = false;
        }
        else 
        {
            goA = false;
            goC = false;
            goB = false;
            goD = true;
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
