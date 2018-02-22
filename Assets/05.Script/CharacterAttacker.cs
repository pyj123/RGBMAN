using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAttacker : MonoBehaviour
{
    [SerializeField]
    private UnityEvent jumpFunc;

   // [SerializeField]
  //  private ColorFrame colorFrame;

    [SerializeField]
    private CharacterView characterView;

    private RGBType nowRGBType;
    public RGBType NowRGBType
    {
        get
        {
            return nowRGBType;
        }
    }

    private void Start()
    {
     //   if (colorFrame != null)
         //   colorFrame.SetColor(RGBType.All);

        
    }

    public void R_ButtonClick()
    {
        nowRGBType = RGBType.Red;

        this.gameObject.layer = LayerMask.NameToLayer(LayerName.Red);

       // if (colorFrame != null)
           // colorFrame.SetColor(RGBType.Red);

        if (jumpFunc != null)
            jumpFunc.Invoke();

        if(characterView!=null)
            characterView.ChangeColor(Color.red);
    }

    public void G_ButtonClick()
    {
        nowRGBType = RGBType.Green;

        this.gameObject.layer = LayerMask.NameToLayer(LayerName.Green);

      //  if (colorFrame != null)
         //   colorFrame.SetColor(RGBType.Green);

        if (jumpFunc != null)
            jumpFunc.Invoke();

        if (characterView != null)
            characterView.ChangeColor(Color.green);
    }

    public void B_ButtonClick()
    {
        nowRGBType = RGBType.Blue;

        this.gameObject.layer = LayerMask.NameToLayer(LayerName.Blue);

       // if (colorFrame != null)
          //  colorFrame.SetColor(RGBType.Blue);

        if (jumpFunc != null)
            jumpFunc.Invoke();

        if (characterView != null)
            characterView.ChangeColor(Color.blue);
    }
	
}
