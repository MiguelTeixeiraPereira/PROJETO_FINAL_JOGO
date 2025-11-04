using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameManager GameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Player"))
        {
            GameManager.AddPontos(10);
            Destroy(gameObject);
        }



    }
}