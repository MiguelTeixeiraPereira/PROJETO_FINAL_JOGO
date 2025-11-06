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

        TextPontos.text = "Pontos: " + pontos;

        Debug.Log("Pontos: " + pontos);


    }

    public TextMeshProUGUI Textvidas;
    public void PerderVida(int vida)
    {
        vidas -= vida;
        Debug.Log("PSidas" + vidas);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().Reiniciar_posicao();
        Textvidas.text = "Vidas: " + vidas;

        if (vidas == 0)
        {
            Time.timeScale = 0;
            Debug.Log("Cabo playboy, coloca mais ficha");
        }

    }
    



}