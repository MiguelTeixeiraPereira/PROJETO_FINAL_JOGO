using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   // ← para Enemy acessar

    public int pontos = 0;
    public int vidas = 5;

    public TextMeshProUGUI TextPontos;
    public TextMeshProUGUI Textvidas;

    // NOVO — Contador de inimigos mortos
    public int inimigosMortos = 0;
    public int totalInimigos = 3; // Quantos inimigos existem

    void Awake()
    {
        instance = this; // Configura singleton
    }

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

    public void PerderVida(int vida)
    {
        vidas -= vida;
        Debug.Log("Vidas " + vidas);

        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().Reiniciar_posicao();

        Textvidas.text = "Vidas: " + vidas;

        if (vidas <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Cabo playboy, coloca mais ficha");
        }
    }

    // NOVO — Chamado quando um inimigo morre
    public void InimigoMorto()
    {
        inimigosMortos++;

        Debug.Log("Inimigos mortos: " + inimigosMortos);

        if (inimigosMortos >= totalInimigos)
        {
            // Carrega a cena de final
            SceneManager.LoadScene("FinalScene");
        }
    }
}