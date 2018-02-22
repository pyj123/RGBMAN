using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField]
    private Transform otherColumn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            if (otherColumn != null)
            {
                MoveToOtherColumn(collision.transform);

            }
        }
      
    }

    private void MoveToOtherColumn(Transform tr)
    {
        if (otherColumn == null) return;
        if (tr == null) return;

        tr.transform.position = new Vector3(otherColumn.transform.position.x, tr.transform.position.y, 0);
        
    }

}
