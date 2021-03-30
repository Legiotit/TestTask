using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public Level Level;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Move>())
        {
            Level.AddMoney();
            Destroy(gameObject, 0);
        } 
    }
}
