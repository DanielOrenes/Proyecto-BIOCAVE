using UnityEngine;

public class ParticulasDeMicrofono : MonoBehaviour
{
    public AudioSource source;
    public ParticleSystem particulas;
    public ParticleSystem burst;
    public DetectorDeAudio detector;
    public float sensitividad = 100;
    public float rango = 2f;

    public GameObject cubito;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float volumen = detector.obtenerVolumenMicro() * sensitividad;
        

        if(volumen <= rango && particulas.isPlaying == true)
        {
            particulas.Stop();
            burst.Play();
            cubito.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else if(volumen > rango && particulas.isStopped == true)
        {
            //cuando el micro detecta audio, activo las particulas de burbujas y desactivo las del burst
            particulas.Play();
            burst.Stop();
            cubito.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
    }

    private void OnDisable()
    {
        particulas.Stop();
    }
}
