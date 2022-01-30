using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPObject : MonoBehaviour
{

    public void TP(Vector3 bullet)
    {
        gameObject.transform.position = bullet;
    }
}
