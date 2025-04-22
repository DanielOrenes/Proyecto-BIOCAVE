using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "AnimalData", menuName = "Scriptable Objects/AnimalData")]
public class AnimalData : ScriptableObject
{
    [Header("Información Básica")]
    public string nombreCientifico;
    public string filo;
    public string clase;
    public string orden;
    public string familia;

    [Header("Multimedia")]
    public Sprite imagen;
    public string videoURL;

    [Header("Descripción")]
    [TextArea(3, 5)]
    public string descripcion;
}
