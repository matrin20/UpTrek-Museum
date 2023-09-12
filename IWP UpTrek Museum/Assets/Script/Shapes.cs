using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    private Vector2 deltaMousePos;
    public Vector2 initialMousePos;
    private Vector2 localMousePos;
    public GameObject CursorBucket;
    [SerializeField]
    private SaveFunction mySaveFunction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        localMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CursorBucket.gameObject.transform.position = new Vector2(localMousePos.x, localMousePos.y);
        transform.SetParent(CursorBucket.transform);
    }

    private void OnMouseDrag()
    {
        localMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CursorBucket.gameObject.transform.position = new Vector2(localMousePos.x, localMousePos.y);
    }
    private void OnMouseUp()
    {
        transform.parent = null;
        mySaveFunction.SaveState();
    }
}
