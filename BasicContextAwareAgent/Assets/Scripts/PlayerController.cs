using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    // voice commands
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public GameObject cl;
    [SerializeField]
    int zoffset = 1;


    void Start()
    {
        cam = Camera.main;
        agent.updateRotation = false;

        // voice commands
        actions.Add("Hey Jinn", Appear);
        actions.Add("Come back", ComeBack);
        actions.Add("Hey Kid", Kid);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        cl.SetActive(false);
    }

    // Recognized speech. Voice command methods.
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Appear()
    {
        Vector3 hitPos, hitNormal;
        RaycastHit hitInfo;
        Vector3 UiRayCastOrigin = Camera.main.transform.position;
        Vector3 UiRayCastDirection = Camera.main.transform.forward;
       if (Physics.Raycast(UiRayCastOrigin, UiRayCastDirection, out hitInfo))
        {
            if (!cl.activeSelf)
            {
                cl.SetActive(true);
                hitPos = hitInfo.point;
                hitNormal = hitInfo.normal;
                agent.transform.position = hitPos;
                Debug.Log("called voice command");
            }
        }

    }
    private void Kid()
    {
        Vector3 hitPos, hitNormal;
        RaycastHit hitInfo;
        Vector3 UiRayCastOrigin = Camera.main.transform.position;
        Vector3 UiRayCastDirection = Camera.main.transform.forward;
        if (Physics.Raycast(UiRayCastOrigin, UiRayCastDirection, out hitInfo))
        {
            if (!cl.activeSelf)
            {
                cl.SetActive(true);
                hitPos = hitInfo.point;
                hitNormal = hitInfo.normal;
                agent.transform.position = hitPos;
                Debug.Log("called voice command");
            }
        }

    }

    private void ComeBack()
    {
        Vector3 offset = new Vector3(0, 0, zoffset);
        Vector3 camPos = Camera.main.transform.position + offset;
        agent.SetDestination(camPos);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                // Move Agent
                agent.SetDestination(hit.point);
            }
        }
        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);

        } else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
