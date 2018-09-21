using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class exitGame : MonoBehaviour
{
    public Button ExitGame;

//    void Start()
//    {
//        Button btn = ExitGame.GetComponent<Button>();
//        btn.onClick.AddListener(TaskOnClick);
//    }
//
//    void Update ()
//    {
//        TaskOnClick();
//    }
//
//    void TaskOnClick()
//    {
//        Application.Quit();
//    }

	void Start () 
	{
		GameObject btnObj = GameObject.Find("Button");//"Button"为你的Button的名称
		Button btn = btnObj.GetComponent<Button>();
		btn.onClick.AddListener(delegate ()
			{
				Application.Quit();
			});
	}

	// Update is called once per frame
	void Update()
	{
	}


}
