using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public GUISkin customSkin;

	// Use this for initialization
	void Start ()
    {
        GuiManager.InitGui();
        AddGui();
	}

    private void AddGui()
    {
        GuiElement btnExit = GuiManager.AddButton(0.9f, 0.9f, 10f);
        btnExit.SetTexture("closeBtn");
        btnExit.SetClickTexture("closeBtnClk");
        btnExit.Width = 0.075f;
        btnExit.Height = 0.075f;
        btnExit.OnClick = OnExitClicked;
    }

    private void OnExitClicked(OnClickParams prm)
    {
        Application.Quit();
    }

    private void Update()
    {
#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8)
        if (Input.touchCount > 0)
        {
            GuiManager.IsGuiMatterTouch();
        }
#else
        if (Input.GetMouseButtonDown(0))
        {
            GuiManager.IsGuiMatter();
        }
#endif
    }

    private void OnGUI()
    {
        if (customSkin == null || customSkin.customStyles[0] == null)
        {
            return;
        }

        GUI.Box(new Rect((Screen.width / 2) - Screen.width / 4, (Screen.height / 2) - (Screen.height / 4), Screen.width * 0.5f, Screen.height * 0.5f), "GAME MENU", customSkin.customStyles[0]);

        if (GUI.Button(new Rect((Screen.width / 2) - 80 , (Screen.height * 0.45f) - 20, 160, 40), "Play"))
        {
            Application.LoadLevel("GameScene");
        }

        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height * 0.2f, 100, 30), "", new GUIStyle() { fontSize = 30, alignment = TextAnchor.MiddleCenter });
    }
}
