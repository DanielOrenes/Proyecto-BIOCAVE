using UnityEngine;

public class ParticulasDeMicrofono : MonoBehaviour
{
    public AudioSource source;
    public ParticleSystem particulas;
    public DetectorDeAudio detector;
    public float sensitividad = 100;
    public float rango = 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float volumen = detector.VolumenAudio(source.timeSamples, source.clip) * sensitividad;

        if(volumen <= rango && particulas.isPlaying == true)
        {
            particulas.Stop();
        }
        else if(volumen > rango && particulas.isStopped == true)
        {
            particulas.Play();
        }
    }

    private void OnDisable()
    {
        particulas.Stop();
    }
}
