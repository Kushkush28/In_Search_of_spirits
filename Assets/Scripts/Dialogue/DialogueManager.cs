using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameDisplay;
    public string[] sentences;
    public string[] speakers;
    private int index=0;
    private bool isActive = false;
    private GameObject playerCollision;

    private void Start()
    {
  dialogueCanvas.SetActive(false);
    }
    private void Update()
    {
        if (isActive==true && Input.anyKeyDown) 
        { 
        NextSentence();
        
        }
    }
    // Start is called before the first frame update
    IEnumerator Type()
    {
        nameDisplay.text = speakers[index].ToString();
        playerCollision.GetComponent<PlayerController3>().enabled = false;
        

        isActive = true;
        foreach (char letter in sentences[index].ToCharArray()) 
        {

            textDisplay.text  += letter;
            yield return new WaitForSeconds(0.02f);
        }
    
    }
    public void NextSentence() 
    {
        if (index<sentences.Length-1)
        { 
            index++;
            textDisplay.text = "";
           
            StartCoroutine(Type());



        }
        else 
        {
            textDisplay.text ="";
            nameDisplay.text = "";
            isActive = false;
            dialogueCanvas.SetActive(false);
            playerCollision.GetComponent<PlayerController3>().enabled = true;
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            textDisplay.text = "";
            nameDisplay.text = "";
            dialogueCanvas.SetActive(true);
            playerCollision = collision.gameObject;
            StartCoroutine(Type());

        }
    }
}
