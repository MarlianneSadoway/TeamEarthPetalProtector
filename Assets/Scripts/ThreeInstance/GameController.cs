using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    // Prefabs for each scene
    [Header("Scene Prefabs")]
    public GameObject menu;
    public GameObject gameEasy;
    public GameObject gameHard;

    // Camera for each game
    [Header("Cameras")]
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    [Header("Music")]
    public List<AudioClip> playlist;
    private AudioSource stereo;
    private int currentSong = 0;
    // Game Instances
    private GameObject[] games;

    // Start is called before the first frame update
    void Start()
    {   
        stereo = GetComponent<AudioSource>();
        stereo.PlayOneShot(playlist[currentSong]);
        games = new GameObject[3];
        // Create Menu instances
        createMenu(0);
        createMenu(1);
        createMenu(2);
    }

    void Update()
    {
        if (!stereo.isPlaying)
        {
            currentSong ++;
            if (currentSong >= playlist.Count)
            {
                currentSong = 0;
            }
            stereo.PlayOneShot(playlist[currentSong]);
        }
    }

    private void createMenu(int index)
    {
        // Destroy Game at current index
        Destroy(games[index]);
        // Set default camera to camera 1
        Camera cam = camera1;
        // swap camera if to appropriate index
        switch (index)
        {
            case 1:
            cam = camera2;
                break;
            case 2:
            cam = camera3;
                break;
        }
        
        // Instantiate Prefab as child of camera
        games[index] = Instantiate(menu, cam.transform);
        // Assign camera to canvases
        games[index].transform.Find("Canvas").GetComponent<Canvas>().worldCamera = cam;
        games[index].transform.Find("Instruct").GetComponent<Canvas>().worldCamera = cam;
        games[index].transform.Find("SelectDiff").GetComponent<Canvas>().worldCamera = cam;
        // Assign self to prefabs root object and assign index
        games[index].transform.GetComponent<GameIndex>().gameController = gameObject.GetComponent<GameController>();
        games[index].transform.GetComponent<GameIndex>().index = index;
    }

    private void createEasy(int index)
    {
        // Destroy Game at current index
        Destroy(games[index]);
        // Set default camera to camera 1
        Camera cam = camera1;
        // swap camera if to appropriate index
        switch (index)
        {
            case 1:
            cam = camera2;
                break;
            case 2:
            cam = camera3;
                break;
        }
        // Instantiate Prefab as child of camera
        games[index] = Instantiate(gameEasy, cam.transform);
        // Assign camera to canvases
        games[index].transform.Find("Canvas").GetComponent<Canvas>().worldCamera = cam;
        games[index].transform.Find("GameWonVisuals").GetComponent<Canvas>().worldCamera = cam;
        games[index].transform.Find("GameOver").GetComponent<Canvas>().worldCamera = cam;
        // Assign self to prefabs root object and assign index
        games[index].transform.GetComponent<GameIndex>().gameController = gameObject.GetComponent<GameController>();
        games[index].transform.GetComponent<GameIndex>().index = index;
    }

    // Callable function to swap from menu to easy
    public void menuToEasy(int index)
    {
        createEasy(index);
    }

    // Callable function to swap from game to menu
    public void gameToMenu(int index)
    {
        createMenu(index);
    }

}
