using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour

{
    public int pontos = 0;
    public int vidas = 3;

    public TextMeshProUGUI textPontos;
    public void AddPontos(int qtd)
    {
        pontos += qtd;
        Debug.Log("Pontos:" + pontos);
        if (pontos <= 0)
        {
            pontos = 0;
        }
        textPontos.text = "Pontos: " + pontos;


    }
    public void Perdervida(int vida)
    {
        vidas -= vida;
        Debug.Log("vidas:" + vidas);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().Reiniciar_posicao();
        if (vidas <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("GAME OVER");
        }
    }
}