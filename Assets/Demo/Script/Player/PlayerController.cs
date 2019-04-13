using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputPlayer _inputPlayer;
    private Rigidbody _rgb3d;
    private Transform _transform;


    private int NumPortalRange;
    private int[] numbersIndexPortal;

    public GameObject targetRed;
    public List<GameObject> portalBlue = new List<GameObject>();
    public GameObject targetGreen;


    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _inputPlayer = GetComponent<InputPlayer>();
        _rgb3d       = GetComponent<Rigidbody>();
        _transform   = GetComponent<Transform>();

        _transform.position = new Vector3(0,0,0);
    }

    private void FixedUpdate()
    {

        //_rgb3d.velocity = new Vector3(0, 0, speed);

    }

    // Update is called once per frame
    void Update()
    {
        MovementHorizontal();
        MovementVertical();
    }

    private void MovementVertical()
    {
        if (_transform.position.x < -1.7 || _transform.position.x > 3.5)
        {

            if (_inputPlayer.up)
            {
                _transform.position += new Vector3(0, 1.6f);
            }
            if (_inputPlayer.down)
            {
                _transform.position -= new Vector3(0, 1.6f);
            }
        }
    }

    private void MovementHorizontal()
    {
        if (_transform.position.x > -1.7 && _transform.position.x < 3.5)
        {
            if (_inputPlayer.right)
            {
                _transform.position += new Vector3(1.6f, 0);
            }
            if (_inputPlayer.left)
            {
                _transform.position -= new Vector3(1.6f, 0);
            }
        }
    }

    public void Teleport(Vector3 position)
    {
        Debug.Log(position);
        _transform.position = position;
    }

    private void OnTriggerStay(Collider other)
    {
        SelectorQuadrant(other);
    }

    private void SelectorQuadrant(Collider other)
    {
        if (other.gameObject.tag == "Q1")
        {
            //Debug.Log("Estas en el Q1");
            NumPortalRange = Random.Range(1, 3);
        }

        if (other.gameObject.tag == "Q2")
        {
            //numbersIndexPortal = new int[] { 0, 2, 3 };
            Debug.Log("Estas en el Q2");
            NumPortalRange = numbersIndexPortal[Random.Range(0, numbersIndexPortal.Length)];

        }

        if (other.gameObject.tag == "Q3")
        {
            numbersIndexPortal = new int[] { 0, 1, 3 };
            //Debug.Log("Estas en el Q3");
            NumPortalRange = numbersIndexPortal[Random.Range(0, numbersIndexPortal.Length)];
        }

        if (other.gameObject.tag == "Q4")
        {
            //Debug.Log("Estas en el Q4");
            NumPortalRange = Random.Range(0, 2);

        }
    }
}
