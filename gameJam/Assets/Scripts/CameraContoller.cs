using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public Camera camera1;
    GameObject player;
    bool canMove = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {  if(camera1.transform.position.y - player.transform.position.y >= 1.5f)
        {
            Vector2 tempPosY = Vector2.Lerp(camera1.transform.position, player.transform.position, 0.03f);
            transform.position = new Vector3(transform.position.x , tempPosY.y, transform.position.z);
        }
        else if (camera1.transform.position.y - player.transform.position.y <= -1.5f)
        {
            Vector2 tempPosY = Vector2.Lerp(camera1.transform.position, player.transform.position, 0.03f);
            transform.position = new Vector3(transform.position.x, tempPosY.y, transform.position.z);
        }
        Vector3 screenPosPlayer = camera1.WorldToScreenPoint(player.transform.position);
        if(screenPosPlayer.x < 200)
        {
            canMove = true;
        }
        else if (screenPosPlayer.x > 1700)
        {
            canMove = true;
        }
        if(canMove)
        {
            Vector2 tempPos = Vector2.Lerp (camera1.transform.position ,player.transform.position, 0.01f);
            transform.position = new Vector3(tempPos.x, transform.position.y,transform.position.z);
            
        }
        if ((transform.position.x <=  player.transform.position.x+1 && transform.position.x >= player.transform.position.x )|| (transform.position.x >= player.transform.position.x - 1 && transform.position.x <= player.transform.position.x))
        {
            canMove = false;
        }
        

    }
}
