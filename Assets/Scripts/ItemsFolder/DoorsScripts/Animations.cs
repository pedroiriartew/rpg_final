using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (_animator != null)
        {
            _animator.SetBool("isOpen", !_animator.GetBool("isOpen"));
        }
    }
}
