using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    private Vector2 mousePos;

    private string stampName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Move()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetStampName(string name){
        stampName = name;
    }

    public string GetStampName()
    {
        return this.stampName;
    }
}
