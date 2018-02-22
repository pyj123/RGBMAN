using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScaleEffect : MonoBehaviour
{
    private void OnEnable()
    {
        iTween.Stop(this.gameObject);

        this.gameObject.transform.localScale = Vector3.zero;   
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one, "time", 0.5f, "ignoretimescale",true));
    }

}
