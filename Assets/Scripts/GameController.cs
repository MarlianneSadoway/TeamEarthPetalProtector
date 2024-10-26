using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    [Header("Scene Prefabs")]
    public GameObject menu;
    public GameObject gameEasy;
    public GameObject gameHard;

    [Header("Cameras")]
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    // Game Instances
    private GameObject[] games;

    // Start is called before the first frame update
    void Start()
    {
        games = new GameObject[3];
        // Create Game instances
        createMenu(0);
        createMenu(1);
        createMenu(2);

        // Resize Games as Necessary
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createMenu(int index)
    {
        Camera cam = camera1;
        switch (index)
        {
            case 1:
            cam = camera2;
                break;
            case 2:
            cam = camera3;
                break;
        }
        
        games[index] = Instantiate(menu, cam.transform);
        games[0].transform.Find("Canvas").GetComponent<Canvas>().worldCamera = cam;
        games[0].transform.Find("Instruct").GetComponent<Canvas>().worldCamera = cam;
        games[0].transform.Find("SelectDiff").GetComponent<Canvas>().worldCamera = cam;
    }

}
