using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject pickupPanel;
    public GameObject itemText;
    public GameObject pressEText;
    public AudioSource pickUpSound;
    public AudioSource congratsSound;

    public GameObject inventoryFullText;
    public GameObject exitObject;

    private bool pickUpAllowed;
    private bool pickedUp;
    private GameObject pickedUpItem;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        itemText.SetActive(false);
        pickupPanel.SetActive(false);
        pressEText.SetActive(false);
        inventoryFullText.SetActive(false);
        exitObject.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)) {
            addInventory();
            DoSomethingElse();
        }
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

    void addInventory()
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
                    break;
                }
                else if (inventory.isFull[5] == true)
                {
                    congratsEnd();
                }
            }

        }
    }

    void DoSomethingElse()
    {
        pickUpSound.Play();
        pickupPanel.SetActive(true);
        //Destroy(pickupPanel, 8f);
        itemText.SetActive(false);
        pressEText.SetActive(false);
    }

    void congratsEnd()
    {
        inventoryFullText.SetActive(true);
        exitObject.SetActive(true);
        congratsSound.Play();
    }
}
