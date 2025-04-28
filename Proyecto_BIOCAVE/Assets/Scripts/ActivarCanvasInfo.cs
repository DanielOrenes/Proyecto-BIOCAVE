using System.Collections;
using UnityEngine;

public class ActivarCanvaInfo : MonoBehaviour
{
    public GameObject canvas;
    private Animator animator;
    public Transform jugador;
    public float distanciaActivacion = 5f;
    private bool isDisabling = false;

    void Start()
    {
        animator = canvas.GetComponent<Animator>();
        canvas.SetActive(false); 
    }
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaActivacion)
        {
            if (!canvas.activeSelf)
            {
                Debug.Log("Activar");
                canvas.SetActive(true);
                animator.SetBool("IsOver", false);
                isDisabling = false;
            }
        }
        else
        {
            if (canvas.activeSelf && !isDisabling)
            {
                animator.SetBool("IsOver", true);
                StartCoroutine(DisableCanvasAfterAnimation());
            }
        }
    }
    
    private IEnumerator DisableCanvasAfterAnimation()
    {
        isDisabling = true;
        yield return new WaitForSeconds(2f); 
        canvas.SetActive(false);
        isDisabling = false;
    }

}
