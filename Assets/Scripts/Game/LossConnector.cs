using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossConnector : MonoBehaviour
{
    public GameObject lossMenu;
    // Use this for initialization
    void Start()
    {
        GameManager.instance.youLose = lossMenu;
    }
}
