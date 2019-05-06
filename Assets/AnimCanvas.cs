using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCanvas : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void CanvasAnimDead()
    {
        _anim.SetBool("Death", true);
    }
}
