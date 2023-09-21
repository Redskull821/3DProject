using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp; // only accessible in this script instance
    public int hitPoints; // all other scripts can access this variable
    protected int health; // private, but can be accessed by children classes
    [SerializeField] int healthPoints; // allows varibales to show up in inspector
    [SerializeField] protected int healthPoints2; // viewable, but cannot be edited

    public float delayTimer = 5;
    public bool isTimerRunning = false;
    public bool canJump = true;
    public float displacement = 1f;
    public bool CRRunning = false;
    public float moveSpeed = 5;
    public Transform targetLocation;
    public GameObject target;
    public PlayerController targetData;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("MethodName", 0, 5);
        targetLocation.position = transform.position;
        target.transform.position = targetLocation.position;
        targetData.gameObject.transform.position = targetLocation.position;

        if (transform.GetComponent<Player>() != null)
        {
            target.GetComponent<Player>().MovePlayer();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (!CRRunning)
        {
            StartCoroutine(SendMessage());
        }
        for (int i =0; i < 10; i++)
        {
            Debug.Log("Hello");
        }
    }

    IEnumerator SendMessage()
    {
        CRRunning = true;
        Debug.Log("5");
        yield return new WaitForSeconds(delayTimer);
        Debug.Log("4");
        yield return new WaitForSeconds(delayTimer);
        Debug.Log("3");
        yield return new WaitForSeconds(delayTimer);
        Debug.Log("2");
        yield return new WaitForSeconds(delayTimer);
        Debug.Log("1");
        yield return new WaitForSeconds(delayTimer);
    }

    public void MovePlayer()
    {
        // transform.position += new Vector3(0, displacement, 0);
        // transform.Translate(new Vector3(0, displacement, 0));

        if (canJump)
        {


            //transform.Translate(Vector3.up * displacement, Space.Self);
            transform.Translate(new Vector3(1, 1, 0).normalized);
            transform.Translate(new Vector3(5, 2, 0).normalized);

            Vector3 directionTotarget = target.transform.position - transform.position;
            Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

            Vector3.Distance(target.transform.position, transform.position);
            // Vector3(4, 0, 0)
            // Vector3(10, 0, 0)
            // (6, 0, 0)

            canJump = false;
            isTimerRunning = true;
        }
        else
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                isTimerRunning = false;
                canJump = true;
                delayTimer = 5;
            }
        }
        // Vector3(0, 1, 0)
    }


}
