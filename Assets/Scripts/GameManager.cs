using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject patientObject;
    Patient patient;
    int id = 0;
    bool isCoroutineRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        //ReceptionQueue.recInst.InitReception();
        LoungeQueue.loungeInst.InitLounge();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCoroutineRunning)
        {
            StartCoroutine(GeneratePatient());
        }
    }

    IEnumerator GeneratePatient()
    {
        isCoroutineRunning = true;
        //Debug.Log("Starting coroutine");
        yield return new WaitForSeconds(5);
        
        patientObject = (GameObject)Instantiate(Resources.Load("Patient"), new Vector2(0,-4), Quaternion.identity);
        patient = patientObject.GetComponent<Patient>();
        patient.EnterHospital(id++);
        //Debug.Log("Completed coroutine");
        isCoroutineRunning = false;

    }
}
