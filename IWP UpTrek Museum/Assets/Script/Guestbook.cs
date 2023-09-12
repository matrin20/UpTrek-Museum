using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guestbook : MonoBehaviour
{
    [SerializeField]
    private GameObject GuestbookPanel;
    private bool guestbookIsActive;
    [SerializeField]
    private TMP_Text[] feedbackFields;
    [SerializeField]
    private TMP_InputField feedbackInputField;
    private int numberOfFilledInFeedbackFields;
    [SerializeField]
    private string guestbookName;

    private Vector3 originalScale;
    private float scaleFactor = 1.2f;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(guestbookName + "numberOfFilledInFeedbackFields") > 0)
        {
            numberOfFilledInFeedbackFields = PlayerPrefs.GetInt(guestbookName + "numberOfFilledInFeedbackFields");
            LoadComments();
        }

        GuestbookPanel.SetActive(false);
        guestbookIsActive = false;

        originalScale = transform.localScale;
    }

    //deletes all entries in playerprefs, be careful
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteAll();
            numberOfFilledInFeedbackFields = 0;
        }
    }

    private void OnMouseDown()
    {
        //this allows the user to click on the guestbook icon to either open or close it
        if (guestbookIsActive)
        {
            CloseGuestbook();
            return;
        }

        OpenGuestbook();
    }

    private void OpenGuestbook()
    {
        //activate gameobject,lerp from below/above, instantiate, anything to spawn the guestbook
        GuestbookPanel.SetActive(true);
        guestbookIsActive = true;
    }

    //this function is also called from the X button on the panel
    public void CloseGuestbook()
    {
        GuestbookPanel.SetActive(false);
        guestbookIsActive = false;
    }

    public void AddComment()
    {
        if (numberOfFilledInFeedbackFields < 6)
        {
            //upload the input from the textfield into playerprefs
            PlayerPrefs.SetString(guestbookName + numberOfFilledInFeedbackFields.ToString(), feedbackInputField.text);
            numberOfFilledInFeedbackFields++;
            PlayerPrefs.SetInt(guestbookName + "numberOfFilledInFeedbackFields", numberOfFilledInFeedbackFields);

            LoadComments();
            feedbackInputField.text = "";
        } else
        {
            Debug.Log("All feedback fields are filled!");
        }
    }

    private void LoadComments()
    {
        //get the strings for the feedback fields from playerprefs
        for (int i=0; i<numberOfFilledInFeedbackFields; i++)
        {
            feedbackFields[i].text = PlayerPrefs.GetString(guestbookName + i.ToString());
        }
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
