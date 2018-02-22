using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectLists;

    private int nowIndex = 0;

    private void OnEnable()
    {
        nowIndex = 0;
        ChangeTutorial(nowIndex);
    }
 
   

    public void LeftButtonClick()
    {
        if (nowIndex > 0)
        {
            nowIndex--;
            ChangeTutorial(nowIndex);
        }
        else
        {
            return;
        }

        SoundManager.Instance.PlaySoundEffect("Button");

    }
    public void RightButtonClick()
    {
        if (nowIndex < objectLists.Count-1)
        {
            nowIndex++;
            ChangeTutorial(nowIndex);
        }
        else
        {
            return;
        }

        SoundManager.Instance.PlaySoundEffect("Button");
    }

    private void ChangeTutorial(int index)
    {
        if (objectLists == null) return;

        for(int i=0;i< objectLists.Count; i++)
        {
            if (i == index)
            {
                objectLists[i].gameObject.SetActive(true);
            }
            else
            {
                objectLists[i].gameObject.SetActive(false);
            }
        }
    }
}
