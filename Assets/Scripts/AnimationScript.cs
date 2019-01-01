using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator)
        {
            if (GetComponent<Rigidbody>() != null)
            {
                animator.SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);
            }
        }
    }
}
