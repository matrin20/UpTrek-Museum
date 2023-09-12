using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateStamp : MonoBehaviour
{
    public GameObject StampTool;
    public static GameObject CurrentStamp;
    public StampGameManager GameManager;

    [SerializeField]
    private string stampName;

    private Vector3 originalScale;
    private float scaleFactor = 1.2f;


    private void Start()
    {
        originalScale = gameObject.transform.localScale;
    }

    //selecting the stamp to use (also instantiates on & follows the cursor)
    private void OnMouseDown()
    {
        SelectCurrentStamp();
    }

    private void SelectCurrentStamp()
    {
        if (CurrentStamp != null)
        {
            Destroy(CurrentStamp);
        }

        CurrentStamp = Instantiate(StampTool);
        CurrentStamp.AddComponent<Stamp>();
        CurrentStamp.GetComponent<Stamp>().SetStampName(stampName);
        GameManager.SetSelectedStamp(CurrentStamp);
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x * scaleFactor, transform.localScale.y * scaleFactor, transform.localScale.z * scaleFactor);
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }

}

