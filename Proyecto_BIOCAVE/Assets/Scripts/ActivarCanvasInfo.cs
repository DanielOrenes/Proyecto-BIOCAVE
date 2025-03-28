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
            animator.SetBool("IsVisible", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("User"))
        {
            Debug.Log("Chao");
            animator.SetBool("IsVisible", false);
            StartCoroutine(DisableCanvasAfterAnimation());
        }
    }

    private IEnumerator DisableCanvasAfterAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        canvas.SetActive(false);
    }
}
