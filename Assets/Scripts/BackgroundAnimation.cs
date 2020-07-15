using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private WaitForSeconds _changePause;
    
    void Start()
    {
        StartCoroutine(ChangeAnimator());
    }

    private IEnumerator ChangeAnimator()
    {
        _changePause = new WaitForSeconds(Random.Range(60f, 180f));

        yield return _changePause;
        
        _animator.SetTrigger("change");
        
        _changePause = new WaitForSeconds(Random.Range(60f, 180f));

        yield return _changePause;
        
        _animator.SetTrigger("return");

        StartCoroutine(ChangeAnimator());
    }
}
