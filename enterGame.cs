using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enterGame : MonoBehaviour
{
//    public Button EnterGame;
//
//    void Start()
//    {
//        Button btn = EnterGame.GetComponent<Button>();
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
//		SceneManager.LoadScene ("mainscene");
//    }


	void Start () 
	{
		GameObject btnObj = GameObject.Find("Button");//"Button"为你的Button的名称
		Button btn = btnObj.GetComponent<Button>();
		btn.onClick.AddListener(delegate ()
			{
				this.GoNextScene(btnObj);
			});
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void GoNextScene(GameObject NScene)
	{
		Application.LoadLevel("startscene");//切换到场景Scene_2
	}

}
