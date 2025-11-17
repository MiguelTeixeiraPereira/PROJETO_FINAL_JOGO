using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    private bool isMuted = false;

    void Start()
    {
        // Carrega o estado salvo
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        AplicarEstado();
    }

    public void LigarSom()
    {
        isMuted = false;
        PlayerPrefs.SetInt("Muted", 0);
        AplicarEstado();
    }

    public void MutarSom()
    {
        isMuted = true;
        PlayerPrefs.SetInt("Muted", 1);
        AplicarEstado();
    }

    private void AplicarEstado()
    {
        AudioListener.volume = isMuted ? 0f : 1f;
    }
}