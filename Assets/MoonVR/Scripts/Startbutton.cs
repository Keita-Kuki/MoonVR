using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startbutton : MonoBehaviour {

  void Update()
  {
      if (GvrControllerInput.AppButtonDown){
        SceneManager.LoadScene("Main");
      }
  }
}