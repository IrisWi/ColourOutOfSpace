using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectCounter : MonoBehaviour
{
    public GameObject scoreText;
    //public int theScore;
    //public GameObject itemTypeText;
    public GameObject itemStoryText;
    public AudioSource collectSound;

    [SerializeField]
    public GameObject pickUpText;
    private bool pickUpAllowed;

    public GameObject itemDisplayText;

    public List<string> items;

    //----- ON PRESSING E KEY -------
    private void Start()
    {
        items = new List<string>();
        itemDisplayText.SetActive(false);
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            itemDisplayText.SetActive(true);
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            //itemTypeText.gameObject.SetActive(false);
            pickUpAllowed = false;
            itemDisplayText.SetActive(false);
        }
    }

    private void PickUp()
    {
        collectSound.Play();

        string itemType = gameObject.GetComponent<ItemScript>().itemType;
        //itemTypeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Du hast eine " + itemType + " gefunden.";
        //print("Du hast eine " + itemType + "gefunden.");
        //Destroy(itemTypeText, 3f);
        itemStoryText.SetActive(true);
        string itemStory = gameObject.GetComponent<ItemScript>().itemStory;
        itemStoryText.GetComponent<TMPro.TextMeshProUGUI>().text = itemStory;
        //print(itemStory);
        Destroy(itemStoryText, 10f);

        items.Add(itemType);
        //print("Inventory length: " + items.Count);
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Gesammelte Hinweise: " + items.Count;

        pickUpText.gameObject.SetActive(false);
        //Destroy(gameObject);
        Destroy(itemDisplayText);

        //Wenn Anzahl von items gefunden wurde, dann:
        //        if (items.Count == 10)
        //        {
        //            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        //        }
    }



    // ------- ON COLLISION -------
    //void OnTriggerEnter(Collider collision)
    //{
    //    collectSound.Play();
    //    //theScore += 1;
    //    //scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Gesammelte Hinweise: " + theScore;

    //    if (collision.CompareTag("CollectItem"))
    //    {
    //        string itemType = collision.gameObject.GetComponent<ItemScript>().itemType;
    //        string itemStory = collision.gameObject.GetComponent<ItemScript>().itemStory;

    //        itemTypeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Du hast eine " + itemType + " gefunden.";
    //        //print("Du hast eine " + itemType + "gefunden.");
    //        Destroy(itemTypeText, 3f);

    //        itemStoryText.GetComponent<TMPro.TextMeshProUGUI>().text = itemStory;
    //        //print(itemStory);
    //        Destroy(itemStoryText, 10f);

    //        items.Add(itemType);
    //        print("Inventory length: " + items.Count);
    //        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Gesammelte Hinweise: " + items.Count;

    //        Destroy(collision.gameObject);


    //        //Wenn Anzahl von items gefunden wurde, dann:
    //        if (items.Count == 10)
    //        {
    //            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    //        }
    //    }
    //}
}
