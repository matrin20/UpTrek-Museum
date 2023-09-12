using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampGameManager : MonoBehaviour
{
    private GameObject selectedStamp;
    private Vector2 mousePos;
    private List<GameObject> PlacedStamps;

    [SerializeField]
    private GameObject circleShape;

    [SerializeField]
    private GameObject squareShape;

    [SerializeField]
    private GameObject triangleShape;


    private Dictionary<string, GameObject> nameShapeMapping;

    // Start is called before the first frame update
    void Start()
    {
        PlacedStamps = new List<GameObject>();
        nameShapeMapping = new Dictionary<string, GameObject>(){
            { "circle", circleShape},
            { "triangle", triangleShape},
            { "square", squareShape}
        };

        PlaceSavedStamps();
    }

    private void PlaceSavedStamps()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("stampCount"); i++)
        {
            string stampName = PlayerPrefs.GetString("stampShape" + i.ToString());
            float xPos = PlayerPrefs.GetFloat("xStamp" + i.ToString());
            float yPos = PlayerPrefs.GetFloat("yStamp" + i.ToString());
            float zRot = PlayerPrefs.GetFloat("zRotationStamp" + i.ToString());
            PlaceStamp(stampName, xPos, yPos, zRot);
        }
    }

    private void PlaceStamp(string stampName, float xPos, float yPos, float zRot)
    {
        GameObject stampClone = Instantiate(nameShapeMapping[stampName]);
        stampClone.AddComponent<BoxCollider2D>();
        stampClone.AddComponent<PlacedStamp>();
        stampClone.GetComponent<PlacedStamp>().SetStampName(stampName);
        stampClone.transform.position = new Vector3(xPos, yPos, -1f);
        stampClone.transform.Rotate(new Vector3(0f,0f,zRot));
        PlacedStamps.Add(stampClone);
    }


    //creating the stamps on the canvas
    private void OnMouseDown()
    {
        if (selectedStamp)
        {
            string stampName = selectedStamp.GetComponent<Stamp>().GetStampName();
            mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            PlaceStamp(stampName, mousePos.x, mousePos.y, 0f);
        }
    }

    public void SetSelectedStamp(GameObject stamp)
    {
        selectedStamp = stamp;
    }


    public void SaveStamps()
    {
        PlayerPrefs.SetInt("stampCount", PlacedStamps.Count);
        if (PlacedStamps.Count > 0)
        {
            for (int i = 0; i < PlacedStamps.Count; i++)
            {
                PlayerPrefs.SetFloat("xStamp" + i.ToString(), PlacedStamps[i].transform.position.x);
                PlayerPrefs.SetFloat("yStamp" + i.ToString(), PlacedStamps[i].transform.position.y);
                PlayerPrefs.SetString("stampShape" + i.ToString(), PlacedStamps[i].GetComponent<PlacedStamp>().GetStampName());
                PlayerPrefs.SetFloat("zRotationStamp" + i.ToString(), PlacedStamps[i].transform.localEulerAngles.z);
                Debug.Log(PlayerPrefs.GetFloat("zRotationStamp" + i.ToString()));
            }
        }
    }

    public void RemoveStamp(GameObject stamp)
    {
        PlacedStamps.Remove(stamp);
        Destroy(stamp);
    }
}
