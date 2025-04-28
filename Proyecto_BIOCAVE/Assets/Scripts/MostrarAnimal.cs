using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class MostrarAnimal : MonoBehaviour
{
    public AnimalData animal;

    [Header("UI Campos")]
    public TMP_Text nombreText;
    public TMP_Text filoText;
    public TMP_Text claseText;
    public TMP_Text ordenText;
    public TMP_Text familiaText;
    public TMP_Text descripcionText;

    [Header("Imagenes")]
    public Image imagenUI;
    public RawImage rawImageVideo;

    [Header("Video")]
    public VideoPlayer videoPlayer;
    public GameObject controlesVideo;
    public Image iconoBotonPausa;
    public Sprite spritePausa;
    public Sprite spriteReanudar;

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
        }

        // Asegurar que esté todo apagado al inicio
        rawImageVideo.gameObject.SetActive(false);
        controlesVideo.SetActive(false);
        videoPlayer.Stop();
    }

    public void ReproducirVideo()
    {
        if (!string.IsNullOrEmpty(animal.videoURL))
        {
            videoPlayer.Stop();
            videoPlayer.url = animal.videoURL;
            videoPlayer.source = VideoSource.Url;

            // MUY IMPORTANTE: limpiar eventos viejos
            videoPlayer.prepareCompleted -= OnVideoReady;
            videoPlayer.prepareCompleted += OnVideoReady;

            videoPlayer.Prepare();
        }
    }

    private void OnVideoReady(VideoPlayer vp)
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
        videoPlayer.prepareCompleted -= OnVideoReady;
        videoPlayer.url = "";
        rawImageVideo.gameObject.SetActive(false);
        controlesVideo.SetActive(false);
    }
}






