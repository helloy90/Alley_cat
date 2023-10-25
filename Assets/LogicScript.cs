using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int lifes;
    public Text lifes_left;
    public void Decrease() {
        lifes--;
        lifes_left.text = lifes.ToString();
    }
}
