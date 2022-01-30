using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Bullet : MonoBehaviour
{
    public int countBonune = 0;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            countBonune = countBonune + 1;
            if (countBonune == 3)
            {
                    Vector3 t = gameObject.transform.position;
                    Debug.Log(t);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TP(t);
                    Destroy(gameObject);
            }
        }
    }
}
