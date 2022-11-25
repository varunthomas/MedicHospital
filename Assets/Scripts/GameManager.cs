using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameInst;
    public GameObject patientObject;
    public Text cashValue;
    Patient patient;
    int id = 0;
    bool isCoroutineRunning = false;
    int value = 0;
    // Start is called before the first frame update
    void Start()
    {
        //ReceptionQueue.recInst.InitReception();
        LoungeQueue.loungeInst.InitLounge();
    }

    void Awake()
    {
        if(gameInst == null)
        {
            gameInst = this;
        }
        else
        {
            Destroy(this);
        }
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

    public void UpdateCash()
    {
        value+=100;
        cashValue.text = value.ToString();
    }
}
