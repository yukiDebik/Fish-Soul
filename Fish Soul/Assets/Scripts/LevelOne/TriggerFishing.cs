using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerFishing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You have entered the fishing area.");
        SceneManager.LoadScene("FishingMinigame", LoadSceneMode.Additive);
        //object.GetComponent<PlayerMovement>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("You embroidered from the fishing zone.");
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
    }

}
