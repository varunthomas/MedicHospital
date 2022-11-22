using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    private int patientId;
    private float speed = 1.0f;
    private Vector2 target;
    private Queue occupiedSeats;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Patient start");
        occupiedSeats = new Queue(4);
        //SeatSystem.seatSystemInst.Initialise();
        target = SeatSystem.seatSystemInst.GetFreeSeatPosition(); 
        

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if (Vector2.Distance(gameObject.transform.position, new Vector2(9f,-3f)) == 0.0f)
        {
            Debug.Log("Exiting!");
            Destroy(gameObject);
        }
    }
    public void EnterHospital(int id)
    {
        patientId = id;
        Debug.Log("ID is " + patientId);
    }

    

}
