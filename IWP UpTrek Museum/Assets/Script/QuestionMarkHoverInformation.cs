using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkHoverInformation : MonoBehaviour
{
    [SerializeField]
    private GameObject extraInformationPanel;
    // Start is called before the first frame update
    void Start()
    {
        extraInformationPanel.SetActive(false);
    }

    private void OnMouseEnter()
    {
        extraInformationPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        extraInformationPanel.SetActive(false);
    }
}
