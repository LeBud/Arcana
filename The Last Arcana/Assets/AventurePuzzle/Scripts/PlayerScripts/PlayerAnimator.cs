using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [HideInInspector]
    public Animator _animator;
    private PlayerController _playerController;
    private InputsBrain _inputsBrain;
    
    [SerializeField] private GameObject _mesh;

    private void Awake()
    {
        if  (_mesh == null)
        {
            Debug.LogError("Mesh not referenced in " + gameObject.name);
            return;
        }
        
        if (_mesh.TryGetComponent(out Animator animator))
        {
            _animator = animator;
        }
        else Debug.LogError("No Animator component found on " + _mesh.name);
        
    }

    private void Start()
    {
        
        /*if  (_mesh == null)
        {
            Debug.LogError("Mesh not referenced in " + gameObject.name);
            return;
        }
        
        if (_mesh.TryGetComponent(out Animator animator))
        {
            _animator = animator;
        }
        else Debug.LogError("No Animator component found on " + _mesh.name);*/
        
        
        if (TryGetComponent(out PlayerController playerController))
        {
            _playerController = playerController;
        }
        else Debug.LogError("No PlayerController component found on " + gameObject.name);
        
        if (TryGetComponent(out InputsBrain inputsBrain))
        {
            _inputsBrain = inputsBrain;
        }
        else Debug.LogError("No InputsBrain component found on " + gameObject.name);
    }


    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    public void AlternativeIdle()
    {
        _animator.SetBool("AlternativeIdle", true);
    }

    public void SetFall(bool fall)
    {
        if (fall)
            _animator.SetBool("grounded", false);
        else
            _animator.SetBool("grounded", true);
    }
}
