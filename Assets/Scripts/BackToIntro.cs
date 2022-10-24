using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToIntro : MonoBehaviour
{
    public string backToIntro;

    public void BackToIntroScreen()
    {
        SceneManager.LoadScene(backToIntro);
    }
}
