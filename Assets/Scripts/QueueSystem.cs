using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    protected Queue freeSpot;
    protected GameObject[] index;
    //public static QueueSystem queueSystemInst;
    /*private void Awake() 
    { 
        Debug.Log("Awake of parent called");
    // If there is an instance, and it's not me, delete myself.
    
        if (queueSystemInst != null && queueSystemInst != this) 
        { 
            Debug.Log("Already instance present");
            Destroy(this); 
        } 
        else 
        { 
            Debug.Log("New instance");
            queueSystemInst = this; 
        } 
    }*/

    public void Initialise()
    {
        freeSpot = new Queue(4);
        index = new GameObject[4];
    
        
    }

    public GameObject GetFreeObject()
    {
        GameObject seat;
        if(freeSpot.Count != 0)
        {

            seat = (GameObject)freeSpot.Dequeue();
            Debug.Log("Seat loc is " + seat.transform.position + "tag " + seat.tag);
            return seat;
        }
        return null;   
    }

    public void EnqueueFreeObject(GameObject seat)
    {
        freeSpot.Enqueue(seat);
    }

    public bool isSeatFull()
    {
        if(freeSpot.Count == 0)
            return true;
        else
            return false;
    }

    public int GetIndex(GameObject obj)
    {
        for(int i=0;i <4;i++)
        {
            if(GameObject.ReferenceEquals( index[i], obj))
            {
                return i;
            }
        }
        return -1;
    }

    public int getCount()
    {
        return freeSpot.Count;
    }
}
