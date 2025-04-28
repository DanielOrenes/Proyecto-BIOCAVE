using UnityEngine;

public class ActivarParticulasPorDistancia : MonoBehaviour
{
    public Transform jugador; 
    public float distanciaActivacion = 5f;
    private ParticleSystem particulas;

    void Start()
    {
        particulas = GetComponent<ParticleSystem>();
        particulas.Stop();
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaActivacion)
        {
            //Activar las particulas si se esta a una distancia especifica
            if (!particulas.isPlaying)
                particulas.Play();
        }
        else
        {
            //Desactivar las particulas si se esta a una distancia especifica mayor
            if (particulas.isPlaying)
                particulas.Stop();
        }
    }
}
