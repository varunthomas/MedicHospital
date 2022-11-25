using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    public GameObject spotPrefab;
    protected Queue freeSpot;
    int maxQueueSize = 20;
    protected GameObject[] index;

    int row = 0, col = 0;
    int currentRowSize = 1;
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
        freeSpot = new Queue(maxQueueSize);
        for(;row<currentRowSize;row++)
        {
	        for(;col<4;col++)
	        {
                freeSpot.Enqueue(Instantiate(spotPrefab, new Vector2(row*1.5f,col*1.5f), Quaternion.identity));
	        }
        }
        //freeSpot.Enqueue(Instantiate(spotPrefab, new Vector2(row*1.5f,col*1.5f), Quaternion.identity)); //(0,0)
        //col++;
        //freeSpot.Enqueue(Instantiate(spotPrefab, new Vector2(row*1.5f,col*1.5f), Quaternion.identity)); //(0,1)
        //col++;
        //index = new GameObject[4];
    
        
    }

    public void IncreaseQueueSize()
    {
        col = 0;
        Debug.Log("IncreaseQueueSize");
        currentRowSize++;
        for(;row<currentRowSize;row++)
        {
            Debug.Log("row is " + row + " current row size " + currentRowSize +" col is " + col);
	        for(;col<4;col++)
	        {
                Debug.Log("Adding seats");
                freeSpot.Enqueue(Instantiate(spotPrefab, new Vector2(row*1.5f,col*1.5f), Quaternion.identity));
	        }
        }
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

    /*public int GetIndex(GameObject obj)
    {
        for(int i=0;i <4;i++)
        {
            if(GameObject.ReferenceEquals( index[i], obj))
            {
                return i;
            }
        }
        return -1;
    }*/

    public int getCount()
    {
        return freeSpot.Count;
    }
}
