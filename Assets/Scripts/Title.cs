using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject SetumeiImage;
    public void Play()
    {
        SceneManager.LoadScene("ToDoScene");
    }

    public void ShowSetumei()
    {
        SetumeiImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetumeiImage.SetActive(false);
        }
    }
}
