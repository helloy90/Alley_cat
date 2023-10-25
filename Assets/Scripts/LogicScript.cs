using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int lifes;
    public Text lifes_left;

    public GameObject game_over;
    public GameObject win;
    void Start() {
        lifes = 3;
        lifes_left.text = lifes.ToString();
    }

    public void Decrease() {
        lifes--;
        lifes_left.text = lifes.ToString();
        if (lifes == 0) {
            GameOver();
        }
    }

    public void Win() {
        win.SetActive(true);
    }

    public void GameOver() {
        game_over.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
