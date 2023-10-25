using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private LogicScript logic_script;

    void Start()
    {
        logic_script = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicScript>();
    }
    void Update()
    {

    }
}
