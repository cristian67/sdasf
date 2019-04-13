using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{

    public float horizontal  { get; private set; }

    public bool  touch { get; private set; }
    public bool left { get; private set; }
    public bool right { get; private set; }
    public bool up { get; private set; }
    public bool down { get; private set; }

    // Update is called once per frame
    void Update()
    {
        left = Input.GetButtonDown("left");
        right = Input.GetButtonDown("right");
        up = Input.GetButtonDown("up");
        down = Input.GetButtonDown("down");
    }
}
