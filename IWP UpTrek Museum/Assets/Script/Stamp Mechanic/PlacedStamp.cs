using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedStamp : MonoBehaviour
{
    public int MyStampIndex;
    private string stampName;

    public CircleCollider2D circleCollider;


    //red circle mechanic
    private Vector3 mousePosition;
    private float rotationAngle;
    private bool StartRotating = false;



    // Start is called before the first frame update
    void Start()
    {
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartRotating)
        {
            RotateStamp();
            if (!Input.GetMouseButton(0))
            {
                StartRotating = false;
            }
        }
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public string GetStampName()
    {
        return stampName;
    }

    public void SetStampName(string name)
    {
        stampName = name;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StampGameManager stampManager = GameObject.Find("GameManager").GetComponent<StampGameManager>();
            stampManager.RemoveStamp(gameObject);
        }
    }
    private void OnMouseDown()
    {
        StartRotating = true;
    }

    private void RotateStamp()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        rotationAngle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
        
    }
}
