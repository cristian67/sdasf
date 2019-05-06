using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject trap;

    [SerializeField]
    private float velocityDown;

    [SerializeField]
    private float velocityUp;


    private Rigidbody rgdb;

    // Start is called before the first frame update
    void Start()
    {

        rgdb = trap.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (trap.transform.position.y < -10)
        {
            trap.transform.position = new Vector3(trap.transform.position.x, -10, trap.transform.position.z);
        }
        if (trap.transform.position.y > 10)
        {
            trap.transform.position = new Vector3(trap.transform.position.x, 10, trap.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (trap.transform.position.y > 0)
            {
                rgdb.velocity = new Vector3(0, velocityDown, 0);
            }

            if (trap.transform.position.y < 0)
            {
                rgdb.velocity = new Vector3(0, velocityUp, 0);
            }
        }
    }
}
