using UnityEngine;

public class AparecerVideo : MonoBehaviour
{
    public GameObject objetoAActivar;  

    public void Activar()
    {
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }
    }
    public void Desactivar()
    {
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(false);
        }
    }
}
