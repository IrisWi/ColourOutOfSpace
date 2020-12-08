using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;

public class TextAnimator : MonoBehaviour
{
    // Zeit die man für jeden Buchstaben braucht ( je kleiner, desto schneller kommen die Buchstaben) 
    public float letterPaused = 0.01f;
    //Message die bis zum Ende ausgegeben wird, buchstabe nach buchstabe 
    public string message;
    // Text damit die Message anzeigt wird 
    public GameObject wholeText;
    public GameObject animatedText;

    //public Text textComp;
    public TextMeshProUGUI tmpComp;

    // Use this for initialization
    void Start()
    {
        animatedText.SetActive(true);
        //Get text component
        tmpComp = GetComponent<TextMeshProUGUI>();
        //Message will display will be at Text
        message = tmpComp.text;
        //Set the text to be blank first
        tmpComp.text = "";
        //Call the function and expect yield to return
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        // Teilt jedes char in einen char array
        foreach (char letter in message.ToCharArray())
        {
            // Fügt 1 Buchstaben hinzu 
            tmpComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
    }

    public void skipText()
    {
        wholeText.SetActive(true);
        animatedText.SetActive(false);
    }
}