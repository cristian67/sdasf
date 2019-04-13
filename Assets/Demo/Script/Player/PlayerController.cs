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


    public bool q1;
    public bool q2;
    public bool q3;
    public bool q4;

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

    private void OnTriggerStay(Collider Other)
    {
        SelectorQuadrantI(Other);
    }


    public void SelectorQuadrantI(Collider Other)
    {

        if (Other.gameObject.tag == "Q1")
        {
            q1 = true;
            q2 = false;
            q3 = false;
            q4 = false;

            //Debug.Log("Q1");
        }

        if (Other.gameObject.tag == "Q2")
        {
            q1 = false;
            q2 = true;
            q3 = false;
            q4 = false;

            //Debug.Log("Q2");

        }

        if (Other.gameObject.tag == "Q3")
        {
            q1 = false;
            q2 = false;
            q3 = true;
            q4 = false;

            //Debug.Log("Q3");

        }

        if (Other.gameObject.tag == "Q4")
        {
            q1 = false;
            q2 = false;
            q3 = false;
            q4 = true;

            //Debug.Log("Q4");

        }
    }     
}
