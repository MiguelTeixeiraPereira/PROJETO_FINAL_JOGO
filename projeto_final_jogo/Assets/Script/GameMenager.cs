using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int pontos = 0;
    public int vidas = 3;
    

    public TextMeshProUGUI TextPontos;

    public void AddPontos(int qtd)
    {
        pontos += qtd;

        if (pontos < 0)
        {
            pontos = 0;
        }

        TextPontos.text = "pontos: " + pontos;

        Debug.Log("pontos: " + pontos);


    }
    public void PerderVida(int vida)
    {
        vidas -= vida;
        Debug.Log("vidas" + vidas);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().Reiniciar_posicao();

        if (vidas == 0)
        {
            Time.timeScale = 0;
            Debug.Log("Cabo playboy, coloca mais ficha");
        }

    }

}