using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoungeQueue : QueueSystem
{
    // Start is called before the first frame update
    public static LoungeQueue loungeInst;
    private void Awake() 
    { 
        Debug.Log("Awake of child lounge");
    // If there is an instance, and it's not me, delete myself.
    
        if (loungeInst != null && loungeInst != this) 
        { 
            Debug.Log("Already instance present of lounge");
            Destroy(this); 
        } 
        else 
        { 
            Debug.Log("New instance of lounge");
            loungeInst = this; 
        }
    }

    public void InitLounge()
    {
        
        Initialise();
        
        freeSpot.Enqueue(GameObject.Find("Seat1"));
        index[0] = GameObject.Find("Seat1");
        freeSpot.Enqueue(GameObject.Find("Seat2"));
        index[1] = GameObject.Find("Seat2");
        freeSpot.Enqueue(GameObject.Find("Seat3"));
        index[2] = GameObject.Find("Seat3");
        freeSpot.Enqueue(GameObject.Find("Seat4"));
        index[3] = GameObject.Find("Seat4");
        
    }
}
