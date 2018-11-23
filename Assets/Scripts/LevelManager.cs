using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void chargeGame(string nameGame)
    {
        SceneManager.LoadScene(nameGame);
    }
}
