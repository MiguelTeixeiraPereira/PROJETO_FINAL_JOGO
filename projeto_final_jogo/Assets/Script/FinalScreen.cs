using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class FinalScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(VoltarMenu());
    }

    IEnumerator VoltarMenu()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(0); // Cena do menu
    }
}