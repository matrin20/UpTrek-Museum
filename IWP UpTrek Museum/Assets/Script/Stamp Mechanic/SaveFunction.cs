using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFunction : MonoBehaviour
{
    //add all shape objects to this array to store them whenever you close the scene
    public GameObject[] Shapes;


    // Start is called before the first frame update
    void Start()
    {

        //loads where the player placed the shapes the last time they pressed exit
        for (int i=0; i<Shapes.Length; i++)
        {
            if (PlayerPrefs.GetFloat("xLocationClosurePrompt2Shape" + i.ToString()) != 0)
            {
                Shapes[i].transform.position = new Vector2(PlayerPrefs.GetFloat("xLocationClosurePrompt2Shape" + i.ToString()), PlayerPrefs.GetFloat("yLocationClosurePrompt2Shape" + i.ToString()));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveState()
    {
        for(int i = 0; i<Shapes.Length; i++)
        {
            PlayerPrefs.SetFloat("xLocationClosurePrompt2Shape" + i.ToString(), Shapes[i].transform.position.x);
            PlayerPrefs.SetFloat("yLocationClosurePrompt2Shape" + i.ToString(), Shapes[i].transform.position.y);
        }

    }
}
