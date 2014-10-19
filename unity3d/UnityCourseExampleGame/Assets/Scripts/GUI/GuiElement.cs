using UnityEngine;
using System;
using System.Collections;

public class GuiElement : MonoBehaviour 
{
    Camera camera;
    public SpriteRenderer spriteRender;
    public float zOrder = 0f;
    float width;
    float height;
    public bool isClicked;
    public bool isUsingRaycast;

    public float X
    {
        get
        {
            return camera.WorldToViewportPoint(new Vector3(this.transform.position.x, this.transform.position.y, zOrder)).x; 
        }
        set
        {
            this.transform.position = camera.ViewportToWorldPoint(new Vector3(value, Y, zOrder));
        }
    }

    public float Y
    {
        get
        {
            return camera.WorldToViewportPoint(new Vector3(this.transform.position.x, this.transform.position.y, zOrder)).y;
        }
        set
        {
            this.transform.position = camera.ViewportToWorldPoint(new Vector3(X, value, zOrder));
        }
    }

    public float Width
    {
        get
        {
            //Debug.Log(string.Format("Width {0} {1}", this.transform.renderer.bounds.size.x, this.transform.localScale.x));
            width = this.transform.renderer.bounds.size.x;// spriteRender.sprite.bounds.size.x;
            double worldScreenHeight = Camera.main.orthographicSize * 2.0;
            double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
            return (float)(width / worldScreenWidth);

           
        }
        set
        {
            width = spriteRender.sprite.bounds.size.x;
            double worldScreenHeight = Camera.main.orthographicSize * 2.0;
            double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
            transform.localScale = new Vector3((float)(worldScreenWidth * value / width), transform.localScale.y, transform.localScale.z);
        }
    }

    public float Height
    {
        get
        {
            //Debug.Log(string.Format("Height {0} {1}", this.transform.renderer.bounds.size.y, this.transform.localScale.y));
            height = this.transform.renderer.bounds.size.y;
            double worldScreenHeight = Camera.main.orthographicSize * 2.0;
            double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            return (float)(height / worldScreenHeight);
        }
        set
        {
            height = spriteRender.sprite.bounds.size.y;
            double worldScreenHeight = Camera.main.orthographicSize * 2.0;
            double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
            transform.localScale = new Vector3(transform.localScale.x, (float)(worldScreenHeight * value / height), transform.localScale.z);
        }
    }

    public void InitGuiElement()
    {
        spriteRender = this.gameObject.AddComponent<SpriteRenderer>();
        spriteRender.sprite = new Sprite();
        camera = Camera.main;
        onClickParams = new OnClickParams() { buttonSender = this };
    }

    public void SetDefaultTexture()
    {
        spriteRender.sprite = Resources.Load("defaultBtn", typeof(Sprite)) as Sprite;
        spriteRender.sortingLayerID = 5;
    }

    string textureName = string.Empty;
    public void SetTexture(string value)
    {
        try
        {
            spriteRender.sprite = Resources.Load(value, typeof(Sprite)) as Sprite;
            spriteRender.sortingLayerID = 5;
            textureName = value;

        }
        catch(Exception ex)
        {
            SetDefaultTexture();
            Debug.Log("Unable to assign texture to button.Default texture set.Error : " + ex.ToString());
        }
    }

    public string textureClickedName = string.Empty;
    public void SetClickTexture(string value)
    {
        textureClickedName = value; 
    }

    public void ApplyClickTexture()
    {
        try
        {
            spriteRender.sprite = Resources.Load(textureClickedName, typeof(Sprite)) as Sprite;
            spriteRender.sortingLayerID = 5;
        }
        catch (Exception ex)
        {
            SetDefaultTexture();
            Debug.Log("Unable to assign texture to button.Default texture set.Error : " + ex.ToString());
        }
    }

    public OnClickParams onClickParams;

    public Action<OnClickParams> OnClick;

    public Rect Boundries
    {
        get
        {
            float tempWidth = Width;
            float tempHeight = Height;
            return new Rect(X - (tempWidth / 2), Y - (tempHeight / 2), tempWidth, tempHeight);
        }
    }

    private void OnMouseDown()
    {
        if (!isUsingRaycast)
        {
            return;
        }

    }

    public float clickTimer = 0.1f;
    private float clickTimerCounter = 0f;
    private void FixedUpdate()
    {
        if (!isClicked)
        {
            return; 
        }

        clickTimerCounter += Time.fixedDeltaTime;

        if (clickTimerCounter >= clickTimer)
        {
            clickTimerCounter = 0f;
            isClicked = false;
            if (textureName != string.Empty)
            {
                SetTexture(textureName);
            }
            else
            {
                SetDefaultTexture();
            }
        }
    }

}

public class OnClickParams
{
    public object customDataOne;
    public object customDataTwo;
    public GuiElement buttonSender;
}
