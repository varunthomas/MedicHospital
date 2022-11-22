using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatSystem : MonoBehaviour
{
    private Queue freeSeats;
    public static SeatSystem seatSystemInst;
    private void Awake() 
    { 
    // If there is an instance, and it's not me, delete myself.
    
        if (seatSystemInst != null && seatSystemInst != this) 
        { 
            Debug.Log("Already instance present");
            Destroy(this); 
        } 
        else 
        { 
            Debug.Log("New instance");
            seatSystemInst = this; 
        } 
    }

    public void Initialise()
    {
        freeSeats = new Queue(4);
    
        freeSeats.Enqueue(GameObject.Find("Seat1"));
        freeSeats.Enqueue(GameObject.Find("Seat2"));
        freeSeats.Enqueue(GameObject.Find("Seat3"));
        freeSeats.Enqueue(GameObject.Find("Seat4"));
    }

    public Vector2 GetFreeSeatPosition()
    {
        GameObject seat;
        if(freeSeats.Count != 0)
        {
            seat = (GameObject)freeSeats.Dequeue();
            Debug.Log("Seat loc is " + seat.transform.position);
            return seat.transform.position;
        }
        return new Vector2(9f, -3.0f);   
    }

    public bool isSeatFull()
    {
        if(freeSeats.Count == 0)
            return true;
        else
            return false;
    }
}
