using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP1 : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    public float lookAhead = 10.0f;
    GameObject tracker;

    //Para rastrear
    public Transform player;
    public float playerDetectionDistance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;

    }
   
    // Update is called once per frame
    void Update()
    {

        ProgressTracker();

        //this.transform.LookAt(waypoints[currentWP].transform);

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void ProgressTracker()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, player.position);

        if (distanceToPlayer < playerDetectionDistance)
        {
            currentWP = -1; // Reemplaza el -1 por cualquier valor que garantice que no siga waypoints.
            tracker.transform.LookAt(player);
            tracker.transform.Translate(0, 0, (speed + 2) * Time.deltaTime);
            return; // No sigue waypoints mientras ve al jugador.
        }

        // Resto del código para seguir waypoints (como lo tenías antes).
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
            currentWP++;
        if (currentWP >= waypoints.Length)
            currentWP = 0;
        tracker.transform.LookAt(waypoints[currentWP].transform);
        tracker.transform.Translate(0, 0, (speed + 2) * Time.deltaTime);
    }

}
