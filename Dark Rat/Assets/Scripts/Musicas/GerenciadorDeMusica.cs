using UnityEngine;

public class GerenciadorDeMusica : MonoBehaviour
{
    public AudioClip[] trilhasSonoras;
    public AudioClip somDaChuva;

    public float volumeTrilhaSonora = 1.0f;
    public float volumeChuva = 0.5f;

    private AudioSource trilhaSonoraAudioSource;
    private AudioSource chuvaAudioSource;

    private int indiceAtual = 0;

    void Start()
    {
        trilhaSonoraAudioSource = gameObject.AddComponent<AudioSource>();
        chuvaAudioSource = gameObject.AddComponent<AudioSource>();

      
        chuvaAudioSource.clip = somDaChuva;
        chuvaAudioSource.loop = true;
        chuvaAudioSource.volume = volumeChuva;
        chuvaAudioSource.Play();

        TrocarTrilhaSonora();
    }

    void Update()
    {
        if (!trilhaSonoraAudioSource.isPlaying)
        {
            TrocarTrilhaSonora();
        }
    }

    void TrocarTrilhaSonora()
    {
        trilhaSonoraAudioSource.clip = trilhasSonoras[indiceAtual];
        trilhaSonoraAudioSource.volume = volumeTrilhaSonora;
        trilhaSonoraAudioSource.Play();

       
        indiceAtual = (indiceAtual + 1) % trilhasSonoras.Length;
    }
}
