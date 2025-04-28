using System.Collections;
using UnityEngine;

public class ActivarCanvaInfo : MonoBehaviour
{
    public GameObject canvas;
    private Animator animator;
    public Transform jugador;
    public float distanciaActivacion = 5f;
    private Coroutine canvasAnimCorroutine = null;

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
            if (!canvas.activeSelf && canvasAnimCorroutine == null)
                canvasAnimCorroutine = StartCoroutine(CanvasAnimation(true));
        }
        else
        {
            if (canvas.activeSelf && canvasAnimCorroutine == null)
                canvasAnimCorroutine = StartCoroutine(CanvasAnimation(false));
        }
    }

    private IEnumerator CanvasAnimation(bool activar)
    {
        if (activar)
        {
            Debug.Log("Activando canvas");
            canvas.SetActive(true);
            animator.SetBool("IsOver", false);
            yield return null;
        }
        else
        {
            Debug.Log("Desactivando canvas");
            animator.SetBool("IsOver", true);
            yield return new WaitForSeconds(2);
            canvas.SetActive(false);
        }
        canvasAnimCorroutine = null;
        Debug.Log("Fin de corrutina");
    }
}
