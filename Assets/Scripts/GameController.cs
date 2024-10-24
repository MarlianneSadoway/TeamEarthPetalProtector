using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Scene Prefabs")]
    public GameObject menu;
    public GameObject gameEasy;
    public GameObject gameHard;

    [Header("Camera")]
    public Camera camera;

    [Header("Screens")]
    public Transform screen1;
    public Transform screen2;
    public Transform screen3;

    // Game Instances
    private GameObject game1;
    private GameObject game2;
    private GameObject game3;


    // Start is called before the first frame update
    void Start()
    {
        // Assign Camera to required locations in the menu prefab
        // This will need to be done on anything with a canvas
        menu.transform.Find("Canvas").GetComponent<Canvas>().worldCamera = camera;
        menu.transform.Find("SelectDiff").GetComponent<Canvas>().worldCamera = camera;
        menu.transform.Find("Instruct").GetComponent<Canvas>().worldCamera = camera;

        // Create Game instances
        game1 = Instantiate(menu);
        game2 = Instantiate(menu);
        game3 = Instantiate(menu);

        //Set Screen Locations
        game1.transform.position = screen1.transform.position;
        game2.transform.position = screen2.transform.position;
        game3.transform.position = screen3.transform.position;

        // Resize Games as Necessary
        game1.transform.localScale = new Vector3(0.5f,0.5f,0f);
        game2.transform.localScale = new Vector3(0.5f,0.5f,0f);
        game3.transform.localScale = new Vector3(0.5f,0.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
