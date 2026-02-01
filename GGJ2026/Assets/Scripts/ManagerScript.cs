using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerScript : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    BubbleScript[] bubbleScripts; 
    [SerializeField]
    GameObject[] spawnPoints;
    [SerializeField]
    GameObject[] bubbles;
    [SerializeField]
    private float lastSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        lastSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print(Time.time);
        string i = Input.inputString; 
        bubbleScripts = FindObjectsByType<BubbleScript>(FindObjectsSortMode.None);
        //print(i);
        if (bubbleScripts.Length > 0)
        {
            bool popped = false;
            //print(bubbles.Length);
            foreach(BubbleScript b in bubbleScripts)
            {
                print(b.getButtonToPress());
                //while (!popped)
                //{
                    if (i == b.getButtonToPress().ToString())
                    {
                        if (!popped)
                        b.Pop();
                        popped = true;
                    }
               // }
                
            }
        }
        if (Time.time - lastSpawn > spawnRate)
        {
            GameObject chosenSpawn = spawnPoints[(int)Random.Range(0, spawnPoints.Length -1)];
            GameObject chosenBubble = bubbles[(int)Random.Range(0, bubbles.Length -1)];
            print(chosenSpawn);
            Instantiate(chosenBubble, chosenSpawn.transform);
            lastSpawn = Time.time;
        } 
    }

}
