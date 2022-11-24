using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionQueue : QueueSystem
{

   /* public static ReceptionQueue recInst;
    private void Awake() 
    { 
        Debug.Log("Awake of child");
    // If there is an instance, and it's not me, delete myself.
    
        if (recInst != null && recInst != this) 
        { 
            Debug.Log("Already instance present of recept");
            Destroy(this); 
        } 
        else 
        { 
            Debug.Log("New instance of recept");
            recInst = this; 
        }
    }

    public void InitReception()
    {
        
        Initialise();
        
        freeSpot.Enqueue(GameObject.Find("FirstRecQueue"));
        index[0] = GameObject.Find("FirstRecQueue");
        freeSpot.Enqueue(GameObject.Find("RecQueue2"));
        index[1] = GameObject.Find("RecQueue2");
        freeSpot.Enqueue(GameObject.Find("RecQueue3"));
        index[2] = GameObject.Find("RecQueue3");
        freeSpot.Enqueue(GameObject.Find("RecQueue4"));
        index[3] = GameObject.Find("RecQueue4");
    }*/

}
