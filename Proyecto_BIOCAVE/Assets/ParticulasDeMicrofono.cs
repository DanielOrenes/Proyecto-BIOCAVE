using UnityEngine;

public class ParticulasDeMicrofono : MonoBehaviour
{
    public AudioSource source;
    public ParticleSystem particulas;
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
        Debug.Log(volumen);

        if(volumen <= rango && particulas.isPlaying == true)
        {
            particulas.Stop();

            cubito.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else if(volumen > rango && particulas.isStopped == true)
        {
            particulas.Play();
            cubito.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
    }

    private void OnDisable()
    {
        particulas.Stop();
    }
}
