using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerScript : MonoBehaviour
{
    BubbleScript[] bubbles; 
    GameObject[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
    }

    // Update is called once per frame
    void Update()
    {
        string i = Input.inputString; 
        bubbles = FindObjectsByType<BubbleScript>(FindObjectsSortMode.None);
        //print(i);
        if (bubbles.Length > 0)
        {
            //bool popped = false;
            //print(bubbles.Length);
            foreach(BubbleScript b in bubbles)
            {
                print(b.getButtonToPress());
                //while (!popped)
                //{
                    if (i == b.getButtonToPress().ToString())
                    {
                        b.Pop();
                        //popped = true;
                    }
               // }
                
            }
        }
        
        
    }

}
