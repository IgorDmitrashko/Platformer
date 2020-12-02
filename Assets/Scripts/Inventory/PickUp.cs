using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Inventory inventory;
    public GameObject slottButton;

    void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }   

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if(!inventory.isFull[i])
                {
                    Instantiate(slottButton,inventory.slots[i].transform);
                    inventory.isFull[i] = true;
                    //Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
