using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour, IInputClickHandler {

    NavMeshAgent agent;

    // Renderer for path, coordinate list, route display
    NavMeshPath path = null;
    Vector3[] positions = new Vector3[9];
    public LineRenderer lr;
   // public GameObject cl;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    //    cl.SetActive(false);
        lr.enabled = false;
	}


    public void OnInputClicked(InputClickedEventData eventData)
    {
        Vector3 hitPos, hitNormal;
        RaycastHit hitInfo;
        //Vector3 UiRayCastOrigin = Camera.main.transform.position;
        //Vector3 UiRayCastDirection = Camera.main.transform.forward;
        //if(Physics.Raycast(UiRayCastOrigin, UiRayCastDirection, out hitInfo))
        //{
        //    if (!cl.activeSelf)
        //    {
        //        cl.SetActive(true);
        //        hitPos = hitInfo.point;
        //        hitNormal = hitInfo.normal;
        //        agent.transform.position = hitPos;
        //    }
        //}
        lr.enabled = true;

        var HeadPosition = Camera.main.transform.position;
        var GazeDirection = Camera.main.transform.forward;


        // destination setting 
        if (Physics.Raycast(HeadPosition, GazeDirection, out hitInfo))
        {
            agent.destination = hitInfo.point;
        }

        // path computation 
        path = new NavMeshPath();
        NavMesh.CalculatePath(agent.transform.position, agent.destination, NavMesh.AllAreas, path);
        positions = path.corners;

        // root drawing 
        lr.widthMultiplier = 0.2F;
        lr.positionCount = positions.Length;

        for (int i = 0; i < positions.Length; i++)
        {
            Debug.Log("point" + i + "=" + positions[i]);

            lr.SetPosition(i, positions[i]);
        }
    }
}
