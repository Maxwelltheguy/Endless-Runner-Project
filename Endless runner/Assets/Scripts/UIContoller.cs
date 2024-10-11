using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIContoller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceTraveled;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI coinsCollected;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;

    public void ShowGameOverScreen()
    {
        sky.SetActive(false);
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        float roundedDistance = Mathf.Ceil(player.distanceTraveled);
        distanceTraveled.text = roundedDistance.ToString();
        coinsCollected.text = player.collectedCoins.ToString();
    }
    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner");
    }
}
