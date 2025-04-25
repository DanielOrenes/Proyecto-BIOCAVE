using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class MostrarAnimal : MonoBehaviour
{
    public AnimalData animal;

    [Header("Textos")]
    public TMP_Text nombreText;
    public TMP_Text filoText;
    public TMP_Text claseText;
    public TMP_Text ordenText;
    public TMP_Text familiaText;
    public TMP_Text descripcionText;

    [Header("Imagen")]
    public Image imagenUI;

    [Header("Video")]
    public VideoPlayer videoPlayer;
    public RawImage rawImageVideo;

    [Header("Controles")]
    public GameObject controlesVideo;
    public Image iconoBotonPausa;
    public Sprite spritePausa;
    public Sprite spriteReanudar;
    public GameObject botonCerrar;

    private bool estaPausado = false;

    void Start()
    {
        if (animal != null)
        {
            nombreText.text = animal.nombreCientifico;
            filoText.text = "Filo: " + animal.filo;
            claseText.text = "Clase: " + animal.clase;
            ordenText.text = "Orden: " + animal.orden;
            familiaText.text = "Familia: " + animal.familia;
            descripcionText.text = animal.descripcion;

            if (animal.imagen != null)
                imagenUI.sprite = animal.imagen;

            rawImageVideo.gameObject.SetActive(false);
            videoPlayer.Stop();
        }
    }

    public void ReproducirVideo()
    {
        if (!string.IsNullOrEmpty(animal.videoURL))
        {
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = animal.videoURL;

            videoPlayer.prepareCompleted += OnVideoReady;
            videoPlayer.Prepare();
        }
    }

    void OnVideoReady(VideoPlayer vp)
    {
        rawImageVideo.gameObject.SetActive(true);
        controlesVideo.SetActive(true);

        estaPausado = false;
        iconoBotonPausa.sprite = spritePausa;
        vp.Play();
    }
    public void PausarReanudarVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            estaPausado = true;
            iconoBotonPausa.sprite = spriteReanudar;
        }
        else
        {
            videoPlayer.Play();
            estaPausado = false;
            iconoBotonPausa.sprite = spritePausa;
        }
    }

    public void CerrarVideo()
    {
        videoPlayer.Stop();
        rawImageVideo.gameObject.SetActive(false);
        controlesVideo.SetActive(false);
    }
}





