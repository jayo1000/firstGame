using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<MoneyManager>().UpdateMoney(true, 10);
        Debug.Log("Coin Touch");
        Die();
    }    

    public void Die()
    {
        Destroy(gameObject);
    }
}
