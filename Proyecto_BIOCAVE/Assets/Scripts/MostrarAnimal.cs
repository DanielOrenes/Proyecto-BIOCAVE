using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MostrarAnimal : MonoBehaviour
{
    public AnimalData animal;

    [Header("Referencias de UI")]
    public TMP_Text nombreText;
    public TMP_Text filoText;
    public TMP_Text claseText;
    public TMP_Text ordenText;
    public TMP_Text familiaText;
    public TMP_Text descripcionText;
    public Image imagenUI;

    void Start()
    {
        if (animal != null)
        {
            nombreText.text = animal.nombreCientifico;
            filoText.text = "Filo: " + animal.filo;
            claseText.text = "Clase: " + animal.clase;
            ordenText.text = "Orden: " + animal.orden;
            familiaText.text = "Familia: " + animal.familia;
            descripcionText.text = "Descripción: " + animal.descripcion;

            if (animal.imagen != null)
            {
                imagenUI.sprite = animal.imagen;
                imagenUI.gameObject.SetActive(true);
            }
            else
            {
                imagenUI.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("No se ha asignado un AnimalData en el inspector.");
        }
    }
}
