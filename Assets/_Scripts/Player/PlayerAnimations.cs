using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Update()
    {
        if (GameInput.Instance.GetHorizontalInput() > 0)
        {
            animator.Play("ShipRotationRight");
        }
        else if (GameInput.Instance.GetHorizontalInput() < 0)
        {
            animator.Play("ShipRotationLeft");
        }
    }
}
