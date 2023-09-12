using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("1. Start");
    }
    public void LoadIntroScene ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2. Intro");
    }

    public void LoadGalleryScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("2. Intro");
    }
    public void LoadCornerSelectScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("3. Corner Select");
    }
    public void LoadCornerScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("4. Corner");
    }
    public void LoadClosurePromptScene1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("5. Closure Prompt 1");
    }
    public void LoadClosurePromptScene2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("6. Closure Prompt 2");
    }
}
