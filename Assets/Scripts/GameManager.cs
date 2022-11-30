using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int numIdols=0;
    public int maxNumIdols;
    public TextMeshProUGUI idolText;
    // Start is called before the first frame update
    void Start()
    {
        idolText.text =numIdols.ToString()+"/"+maxNumIdols.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CollectIdol()
    {
        numIdols++;
        idolText.text = numIdols.ToString() + "/" + maxNumIdols.ToString();

    }
}
