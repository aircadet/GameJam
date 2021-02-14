using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ayasofyaText, sceneManager;
    public GameObject playerBlood;
    public int nextLevel;
    public int healt = 100;
    public int diamondCounter = 0;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ayasofya"))
        {
            ayasofyaText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ayasofya"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                sceneManager.GetComponent<LoadSceneManager>().NextLevel(nextLevel);
            }
        }
        if (collision.CompareTag("item"))
        {
            Destroy(collision.gameObject);
            diamondCounter += 1;
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
        if (collision.gameObject.CompareTag("oldman"))
        {
            if (diamondCounter == 3)
            {
                SceneManager.LoadScene(3);
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Diken")
        {
            playerBlood.SetActive(false);
        }
    }
    public void GetDamage()
    {
        healt -= 15;

        if (healt <= 0)
        {
            SceneManager.LoadScene(0); //menü ye atar
        }
    }

}

