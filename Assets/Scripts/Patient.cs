using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    private enum PatientState
    {
        Enter,
        Reception,
        Lounge,
        Doctor,
        Waiting,
        Exit
    }
    private int patientId;
    private float speed = 2.0f;
    private GameObject targetRec;
    private GameObject targetLounge;
    private Queue occupiedSeats;
    private int recepQueueIndex;
    private float step;
    private bool waitingDone = false;
    private bool isCoroutineRunning = false;
    private PatientState currentState;
    private GameObject doctor;
    private Vector2 docRoom;
    private bool enqueued;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Patient start");
        doctor = GameObject.Find("Doctor");

        currentState = PatientState.Lounge;
        if(LoungeQueue.loungeInst.isSeatFull())
        {
            currentState = PatientState.Exit;
            //transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Exit").transform.position, step);
        }
        //occupiedSeats = new Queue(4);
        //SeatSystem.seatSystemInst.Initialise();
        //docRoom = doctor.transform.position;
        Debug.Log("Calling free obj of recept");
        //targetRec = ReceptionQueue.recInst.GetFreeObject(); 
        //recepQueueIndex = ReceptionQueue.recInst.GetIndex(targetRec);

        Debug.Log("Calling free obj of lounge");
        targetLounge = LoungeQueue.loungeInst.GetFreeObject();

        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Queue count " + LoungeQueue.loungeInst.getCount());
        step = speed * Time.deltaTime;

        if (currentState == PatientState.Waiting)
        {
            if(doctor.GetComponent<Doctor>().doctorFree)
            {
                currentState = PatientState.Doctor;
                doctor.GetComponent<Doctor>().doctorFree = false;
            }
        }
        else if(currentState == PatientState.Doctor)
        {
            transform.position = Vector2.MoveTowards(transform.position, doctor.transform.position, step);
            
            if(!enqueued)
            {
                Debug.Log("Enqueueing " + targetLounge.tag);
                LoungeQueue.loungeInst.EnqueueFreeObject(targetLounge);
                enqueued = true;
            }
            if(Vector2.Distance(gameObject.transform.position, doctor.transform.position) == 0.0f && isCoroutineRunning == false)
            {
                Debug.Log("Consulting doctor");
                StartCoroutine(ConsultDoctor());    
            }
        }
        else if(currentState == PatientState.Lounge)
        {
            
            //Debug.Log("Going to lounge");
            //GoToLounge();
            transform.position = Vector2.MoveTowards(transform.position, targetLounge.transform.position, step);
            if (Vector2.Distance(gameObject.transform.position, targetLounge.transform.position) == 0.0f)
            {
                currentState = PatientState.Waiting;

            }
        }
        else if(currentState == PatientState.Exit)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Exit").transform.position, step);
            if (Vector2.Distance(gameObject.transform.position, GameObject.Find("Exit").transform.position) == 0.0f)
            {
                Debug.Log("Exiting!");
                Destroy(gameObject);
            }
        }

        
    }
    public void EnterHospital(int id)
    {
        patientId = id;
        Debug.Log("ID is " + patientId);
    }

    private IEnumerator ConsultDoctor()
    {
        
        isCoroutineRunning = true;
        Debug.Log("In coroutine for consulting");
        yield return new WaitForSeconds(2);
        Debug.Log("Consultation complete");
        currentState = PatientState.Exit;
        doctor.GetComponent<Doctor>().doctorFree = true;
        waitingDone = true;
        isCoroutineRunning = false;
    }

    private void GoToLounge()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetLounge.transform.position, step);
    }
    

}
