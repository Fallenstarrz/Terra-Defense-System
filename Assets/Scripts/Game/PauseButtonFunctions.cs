using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonFunctions : MonoBehaviour
{
    public void resetTime()
    {
        GameManager.instance.resetGameTime();
    }
    public void togglePaused()
    {
        GameManager.instance.togglePaused();
    }
}
