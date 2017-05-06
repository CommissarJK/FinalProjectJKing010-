using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public InputField iField;

    void Start() {
        int rSeed = Random.Range(11111, 99999);
        iField.text = System.Convert.ToString(rSeed);
    }
    public void LoadByIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
        //int rSeed = Random.Range(0, 99999);
        //int rSeed = 2000;
        int rSeed = System.Convert.ToInt32(iField.text);
        PlayerPrefs.SetInt("rSeed",rSeed);
    }
}
