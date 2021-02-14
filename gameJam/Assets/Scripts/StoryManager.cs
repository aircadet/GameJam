using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoryManager : MonoBehaviour
{
    public Sprite[] storySprites;
    public GameObject storyPanel;
    public Image storyImageBox;
    public int[] StoryPages; // Eğer 1 bölümde 2 geçiş veya fazlası varsa, bitiş spriteları
    public int storyCounter = 0;
    public int currentPage = -1;
    bool isStoryOpen = false;
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0) && storyPanel.activeSelf)
        //{
        //    NextImage();
        //}
    }
    private void FixedUpdate()
    {

        if (storyPanel.activeSelf && !isStoryOpen) // Story her aktif olduğunda 1 defa çalışacak
        {
            storyImageBox.sprite = storySprites[currentPage + 1];
            currentPage++;
            isStoryOpen = true;
            print("control");
        }
        if (!storyPanel.activeSelf)
        {
            isStoryOpen = false;
        }
    }
    public void NextImage()
    {
        if (currentPage + 1 == StoryPages[storyCounter])
        {
            print(storyCounter);
            storyCounter++;
            // Hikaye bitimi eventler buraya yazılacak
            storyPanel.SetActive(false);
        }
        else if (storySprites[currentPage + 1] != null)
        {
            storyImageBox.sprite = storySprites[currentPage + 1];
            currentPage++;
        }
    }
}
