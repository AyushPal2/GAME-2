using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
          Debug.Log("We Escaped");
          Application.Quit();
      }  
    }
}
