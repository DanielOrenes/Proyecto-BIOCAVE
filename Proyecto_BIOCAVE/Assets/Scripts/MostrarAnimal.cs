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
            //Colocas toda la informacion del scriptable object en los diferentes apartados del canvas
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
            // Al clicar el boton asigna la URL del scriptable object y llama a la funcion OnVideoReady
            videoPlayer.Stop();
            videoPlayer.url = animal.videoURL;
            videoPlayer.source = VideoSource.Url;

            videoPlayer.prepareCompleted -= OnVideoReady;
            videoPlayer.prepareCompleted += OnVideoReady;

            videoPlayer.Prepare();
        }
    }

    private void OnVideoReady(VideoPlayer vp)
    {
        // Activa los controladores y es reproductor, si el video se ha pausado lo despausa y el icono que aparece es el de pausar
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
            // Pausa el video y cambia el icono al de reanudar
            videoPlayer.Pause();
            estaPausado = true;
            iconoBotonPausa.sprite = spriteReanudar;
        }
        else
        {
            // Reproduce el video y cambia el icono al de pausar
            videoPlayer.Play();
            estaPausado = false;
            iconoBotonPausa.sprite = spritePausa;
        }
    }

    public void CerrarVideo()
    {
        // Cierra el video, lo pausa, resetea la URL y desactiva los controladores y el video
        videoPlayer.Stop();
        videoPlayer.prepareCompleted -= OnVideoReady;
        videoPlayer.url = "";
        rawImageVideo.gameObject.SetActive(false);
        controlesVideo.SetActive(false);
    }
}






