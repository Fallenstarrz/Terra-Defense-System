using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMeLater : MonoBehaviour
{
    [SerializeField]
    private float timeTillDestruction;
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeTillDestruction);
    }
}
