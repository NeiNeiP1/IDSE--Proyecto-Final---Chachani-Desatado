using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float speed = 10.0f;
    private bool isChasing = false;

    public float chaseDistance = 10.0f;
    public GameObject comprobar;
    public GameObject comprobar2;
    public GameObject comprobar3;
    public GameObject comprobar4;
    public float wanderingRadius = 10.0f;
    public float wanderingTime = 5.0f;
    public float wanderingSpeed = 4.0f;
    public float chaseDuration = 5.0f;

    private Vector3 targetPosition;
    private float timer;
    private bool isCooldown = false;

    void Start()
    {
        timer = wanderingTime;
        SetNewRandomDestination();
    }

    void Update()
    {
        if (comprobarTrigger())
        {
            if (isChasing)
            {
                isChasing = false;
                comprobar.SetActive(false);
                StartCoroutine(StartChaseCooldown());
            }
            else if (timer <= 0 || Vector3.Distance(transform.position, targetPosition) < 1.0f)
            {
                SetNewRandomDestination();
            }
            else
            {
                timer -= Time.deltaTime;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, wanderingSpeed * Time.deltaTime);
            RotateTowards(targetPosition);
        }
        else if (isChasing)
        {
            if (!isCooldown)
            {
                StartCoroutine(StartChaseCooldown());
            }

            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
            RotateTowards(target.position);
        }
    }

    bool comprobarTrigger()
    {
        if (comprobar.transform.position.y < 0 || comprobar2.transform.position.y < 0 || comprobar3.transform.position.y < 0 || comprobar4.transform.position.y < 0)
        {
            isChasing = true;
            return false;
        }
        return true;
    }

    void SetNewRandomDestination()
    {
        Vector2 randomDirection = Random.insideUnitCircle * wanderingRadius;
        targetPosition = new Vector3(randomDirection.x, transform.position.y, randomDirection.y);
        timer = wanderingTime;
        isCooldown = false; // Reinicia la bandera de cooldown cuando cambias de destino
    }

    IEnumerator StartChaseCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(chaseDuration);
        isChasing = false;
        SetNewRandomDestination();
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
    }
}
