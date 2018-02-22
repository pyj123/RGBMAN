using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonStyle
{
    PingPong
}

public class ButtonEffect : MonoBehaviour
{
    [SerializeField]
    private ButtonStyle buttonStyle;

    [SerializeField]
    private float moveValue = 0.1f;
    // Use this for initialization
    void Start ()
    {
        switch (buttonStyle)
        {
            case ButtonStyle.PingPong:
                {
                    iTween.ScaleTo(this.gameObject,
                        iTween.Hash
                        (
                        "time", 0.25f,
                        "scale", this.transform.localScale+Vector3.one* moveValue,
                        "loopType", iTween.LoopType.pingPong,
                        "easeType",iTween.EaseType.linear)
                        );
                } break;
        }
	}

}
