using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScene : MonoBehaviour
{
    public GameObject exitSceneObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("End1", LoadSceneMode.Single);
    }

    void OnTriggerExit(Collider other)
    {
    }
}
