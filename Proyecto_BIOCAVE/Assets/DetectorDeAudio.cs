using UnityEngine;

public class DetectorDeAudio : MonoBehaviour
{
    public int ventanaMuestreo = 64;
    private AudioClip clipMicro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DetectarAudioMicro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectarAudioMicro()
    {
        string nombreMicro = Microphone.devices[0];
        clipMicro = Microphone.Start(nombreMicro, true, 20, AudioSettings.outputSampleRate);
    }

    public float obtenerVolumenMicro()
    {
        return VolumenAudio(Microphone.GetPosition(Microphone.devices[0]), clipMicro);
    }
    public float VolumenAudio(int posicionClip, AudioClip clip)
    {
        int posicionInical = posicionClip - ventanaMuestreo;
        float[] waveData = new float[ventanaMuestreo];
        clip.GetData(waveData, posicionInical);

        if(posicionInical < 0)
        {
            return 0;
        }

        float volumenTotal = 0;
        for (int i = 0; i < ventanaMuestreo; i++)
        {
            volumenTotal += Mathf.Abs(waveData[i]);
        }

        return volumenTotal / ventanaMuestreo;
    }
}
