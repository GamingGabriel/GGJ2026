using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    [SerializeField]
    BubbleScript[] bubbleScripts; 
    [SerializeField]
    GameObject[] spawnPoints;
    [SerializeField]
    GameObject[] bubbles;
    
    [Header("Game State")]
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private bool gameOver;
    [SerializeField]
    private float lastSpawn;

    [SerializeField]
    private float stressRate;

    [SerializeField]
    private float stressReduction;
    
    [SerializeField]
    private float difficulty;
    
    [SerializeField]
    private float DIFFICULTY_SCALAR;

    [Header("UI")]

    [SerializeField]
    Image stressBar;

    [SerializeField]
    float stress;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        lastSpawn = 0;
        stress = 0;
        stressBar.fillAmount = stress;
        gameOver = false;
        difficulty = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Time.time);
        if (!gameOver)
        {  
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
                        if (i == b.getButtonToPress().ToString())
                        {
                            if (!popped)
                            b.Pop();
                            stress -= stressReduction;
                            if (stress < 0)
                            {
                                stress = 0;
                            }
                            popped = true;
                        }
                    
                }
            }
            if (Time.time - lastSpawn > spawnRate)
            {
                GameObject chosenSpawn = spawnPoints[(int)Random.Range(0, spawnPoints.Length -1)];
                if (chosenSpawn.transform.childCount == 0)
                {
                    GameObject chosenBubble = bubbles[(int)Random.Range(0, bubbles.Length -1)];
                    print(chosenSpawn);
                    Instantiate(chosenBubble, chosenSpawn.transform);
                    lastSpawn = Time.time;
                }
            } 
            stress += stressRate * bubbleScripts.Length * Time.deltaTime;
            stressBar.fillAmount = stress;
            if (spawnRate > 1)
            {
                spawnRate -= DIFFICULTY_SCALAR;
            }
            if (stress >= 1)
            {
                gameOver = true; 
            }
        }
    }

}
