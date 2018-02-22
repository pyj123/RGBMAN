using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlayer : MonoBehaviour
{

    //초기화할 정보들

    //3,2,1 띄워주기
    [SerializeField]
    private StartCounter counter;

    //이동 다시 켜주고 조금 밑으로 내리기
    [SerializeField]
    private RisingObject risingObject;

    //파워점프시켜주기
    [SerializeField]
    private CharacterJump characterJump;

    [SerializeField]
    private MaxHeightCalculator maxHeight;




    public void ReviveFunc()
    {
        if (counter != null)
            counter.gameObject.SetActive(true);

        if (risingObject != null)
            risingObject.ReviveAction();

        if (characterJump != null)
            characterJump.PowerJump(ItemData.PowerJumpPower-8f,false);

        if (maxHeight != null)
        {
            if (characterJump != null)
                characterJump.gameObject.transform.position = new Vector3(0, maxHeight.MaxHeight, 0);
        }

    }


}
