using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class KeyReader : MonoBehaviour
{
    public char? pieceToMove { get; private set; }
    void Start()
    {
        pieceToMove = null;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pieceToMove = '1';
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pieceToMove = '2';
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pieceToMove = '3';
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            pieceToMove = '4';
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            pieceToMove = '5';
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            pieceToMove = '6';
        }
        else if (Input.GetMouseButtonDown(0))
        {
          
            RaycastHit2D rayhit = Physics2D.GetRayIntersection
                (Camera.main.ScreenPointToRay(Input.mousePosition));
            if(rayhit.collider != null)
            {
                PointObjectReader(rayhit.transform.gameObject);
            }
        }else
        {
            pieceToMove = null;
        }
        
    }
    public void PointObjectReader(GameObject pointObject)
    {
        switch(pointObject.transform.GetChild(0).GetChild(0).
            GetComponent<TextMeshProUGUI>().text[0])
        {
            case '1':
                pieceToMove = '1';
                break;
            case '2':
                pieceToMove = '2';
                break;
            case '3':
                pieceToMove = '3';
                break;
            case '4':
                pieceToMove = '4';
                break;
            case '5':
                pieceToMove = '5';
                break;
            case '6':
                pieceToMove = '6';
                break;
            default:
                break;
        }
    }
}
