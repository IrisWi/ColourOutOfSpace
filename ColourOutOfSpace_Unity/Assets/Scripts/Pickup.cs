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
    public GameObject pickUpImage;
    public AudioSource pickUpSound;

    public GameObject inventoryFullText;

    private bool pickUpAllowed;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        itemText.SetActive(false);
        pickUpText.SetActive(false);
        pickUpImage.SetActive(false);
        pressEText.SetActive(false);
        inventoryFullText.SetActive(false);
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
                else if (inventory.isFull[1] == true)
                {
                    inventoryFullText.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
            }

        }
    }

    void DoSomethingElse()
    {
        pickUpSound.Play();
        pickUpText.SetActive(true);
        pickUpImage.SetActive(true);
        Destroy(pickUpText, 10f);
        Destroy(pickUpImage, 10f);
        itemText.SetActive(false);
        pressEText.SetActive(false);
    }
}
