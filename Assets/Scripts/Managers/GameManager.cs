using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ReloadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void NextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void Quit() => Application.Quit();
    public void GoToMenu() => SceneManager.LoadScene(0);
}
