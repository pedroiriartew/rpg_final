using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool _isInRange = false;
    [SerializeField] private KeyCode _key;
    [SerializeField] private UnityEvent _interactAction;

    private void Update()
    {
        if (_isInRange)
        {
            if (Input.GetKeyDown(_key))
            {
                _interactAction?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInRange = false;
        }
    }
}
