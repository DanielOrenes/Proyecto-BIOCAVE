using UnityEngine;

public class ActivarCanvaInfo : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {

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
            canvas.SetActive(false); 
        }
    }
}
