using System.Collections;
using UnityEngine;

public class ActivarCanvaInfo : MonoBehaviour
{
    public GameObject canvas;
    private Animator animator;

    void Start()
    {
        animator = canvas.GetComponent<Animator>();
        canvas.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("User"))
        {
            Debug.Log("Hola");
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("User"))
        {
            Debug.Log("Chao");
            animator.SetBool("IsOver", true);
            StartCoroutine(DisableCanvasAfterAnimation());
        }
    }
    private IEnumerator DisableCanvasAfterAnimation()
    {
        yield return new WaitForSeconds(2f); 
        canvas.SetActive(false);
        StopAllCoroutines();
    }

}
