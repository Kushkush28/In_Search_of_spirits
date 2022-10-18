using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject[] playerCharacters;
    public int current=0;
    // Start is called before the first frame update
    void Start()
    {
        SwitchCharacters();
        playerCharacters[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        updateLocations();
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            SwitchCharacters();
            playerCharacters[0].SetActive(true);
            playerCharacters[0].transform.position = playerCharacters[current].transform.position;
            current = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCharacters();
            playerCharacters[1].SetActive(true);
            playerCharacters[1].transform.position = playerCharacters[current].transform.position;
            current = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            SwitchCharacters();
            playerCharacters[2].SetActive(true);
            playerCharacters[2].transform.position = playerCharacters[current].transform.position;
            current = 2;
        }

    }
    void SwitchCharacters() 
    {
        playerCharacters[0].SetActive(false);
        playerCharacters[1].SetActive(false);
        playerCharacters[2].SetActive(false);
    
    }
    void updateLocations() 
    {
        for (int i=0;i<playerCharacters.Length;i++) 
        {
            if (i!=current) 
            {
                playerCharacters[i].transform.position = playerCharacters[current].transform.position;
            }
                
        }
    }
}
