using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject itemText;
    public GameObject pickUpText;
    public GameObject pressEText;
    public AudioSource pickUpSound;

    private bool pickUpAllowed;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        itemText.SetActive(false);
        pickUpText.SetActive(false);
        pressEText.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            pickItUp();
    }

    void OnTriggerEnter(Collider other)
    {
        pickUpAllowed = true;
        itemText.SetActive(true);
        pressEText.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        pickUpAllowed = false;
        itemText.SetActive(false);
        pressEText.SetActive(false);
    }

    void pickItUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //ITEM CAN BE ADDED TO INVENTORY
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    DoSomethingElse();
                    break;
                }
                //if (inventory.isFull[i] == true)
                //{
                //    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

                //}
            }

        }
    }

    void DoSomethingElse()
    {
        pickUpSound.Play();
        pickUpText.SetActive(true);
        Destroy(pickUpText, 5f);
        itemText.SetActive(false);
        pressEText.SetActive(false);
    }
}
