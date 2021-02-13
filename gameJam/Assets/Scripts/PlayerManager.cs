using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject ayasofyaText, sceneManager;
    public GameObject playerBlood;
    public int nextLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ayasofya"))
        {
            ayasofyaText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      if(collision.CompareTag("Ayasofya"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                sceneManager.GetComponent<LoadSceneManager>().NextLevel(nextLevel);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ayasofya"))
        {
            ayasofyaText.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Diken")
        {
            playerBlood.SetActive(true);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Diken")
        {
            playerBlood.SetActive(false);
        }
    }


}

