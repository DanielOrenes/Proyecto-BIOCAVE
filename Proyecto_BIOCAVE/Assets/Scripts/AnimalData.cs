using UnityEngine;

[CreateAssetMenu(fileName = "AnimalData", menuName = "Scriptable Objects/AnimalData")]
public class AnimalData : ScriptableObject
{
    [Header("Información Básica")]
    public string nombreCientifico;
    public string filo;
    public string clase;
    public string orden;
    public string familia;

    [Header("Otros Datos")]
    [TextArea(3, 5)]
    public string descripcion;
    public Sprite imagen;
}
