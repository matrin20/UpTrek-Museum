using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectUI : MonoBehaviour
{
    private Vector3 originalScale;
    private float scaleFactor = 1.1f;
    [SerializeField]
    private SceneLoader sceneLoader;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x * scaleFactor, transform.localScale.y * scaleFactor, transform.localScale.z * scaleFactor);
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }

    private void OnMouseDown()
    {
        sceneLoader.LoadCornerScene();
    }
}
