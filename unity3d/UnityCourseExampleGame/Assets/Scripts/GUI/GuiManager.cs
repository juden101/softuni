using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class GuiManager
{
    private static List<GuiElement> allGuiElements;

    public static void InitGui()
    {
        allGuiElements = new List<GuiElement>();
    }

    //IsGuiMatterTouch and Normal could be merged into one but for clarity sake will be left two..
    public static bool IsGuiMatter()
    {
        if (allGuiElements == null || allGuiElements.Count == 0)
        {
            return false;
        }

        for (int i = 0; i < allGuiElements.Count; i++)
        {
            GuiElement btn = allGuiElements[i];

            if (btn.isUsingRaycast)
            {
                return false;
            }
            
            if (btn.Boundries.Contains(Camera.main.ScreenToViewportPoint(Input.mousePosition)))
            {
                //Debug.Log("Click");
                ExecuteClick(btn);
                return true;
            }
        }

        return false;
    }

    public static bool IsGuiMatterTouch()
    {
        if (allGuiElements == null || allGuiElements.Count == 0 || Input.touchCount == 0)
        {
            return false;
        }

        for (int i = 0; i < allGuiElements.Count; i++)
        {
            GuiElement btn = allGuiElements[i];

            if (btn.isUsingRaycast)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 20f);

                if (hit.collider != null || hit.collider.name == btn.name)
                {
                    ExecuteClick(btn);
                    return true;
                }

            }
            else if (btn.Boundries.Contains(Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position)))
            {
                //Debug.Log("Click");
                ExecuteClick(btn);
                return true;
            }

            return false;
        }
        return false;
    }

    private static void ExecuteClick(GuiElement btn)
    {
        if (btn.OnClick != null && btn.onClickParams != null)
        {
            btn.OnClick(btn.onClickParams);
        }

        if (btn.textureClickedName != string.Empty)
        {
            btn.ApplyClickTexture();
            btn.isClicked = true;
        }
    }

    public static GuiElement AddButton(float x, float y, float zOrder, bool isUsingRaycast = false, string name = "GuiButton")
    {
        //you could also make prefab and instantiate it..
        GameObject btnGameObject = new GameObject();
        btnGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        btnGameObject.gameObject.SetActive(true);
        GuiElement guiBtn = btnGameObject.AddComponent<GuiElement>();
        guiBtn.InitGuiElement();
        guiBtn.SetDefaultTexture();
        guiBtn.zOrder = 10f;
        guiBtn.X = x;
        guiBtn.Y = y;
        guiBtn.isUsingRaycast = isUsingRaycast;
        if (isUsingRaycast)
        {
            btnGameObject.AddComponent<BoxCollider2D>();
        }

        allGuiElements.Add(guiBtn);


        return guiBtn;

    }

}
