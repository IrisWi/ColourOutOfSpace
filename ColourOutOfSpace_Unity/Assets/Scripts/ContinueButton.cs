using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{

    private Pickup pickUpText;
    private Pickup pickUpImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void destroyButton()
    {
        Destroy(pickUpText);
        Destroy(pickUpImage);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
