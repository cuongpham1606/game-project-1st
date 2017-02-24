using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level5DragPieces : MonoBehaviour {

    
    public Camera myCam;
    public Canvas frame;
    private Image piece;
    private Transform transformPanel;

    void Awake()
    {
        piece = GetComponent<Image>();
        transformPanel = transform.parent.transform;       
    }

    public void OnMouseDrag()
    {
        float xHalfSizeFrame = frame.GetComponent<RectTransform>().rect.width / 2;
        float yHalfSizeFrame = frame.GetComponent<RectTransform>().rect.height / 2;
        float xHalfSizePiece = piece.GetComponent<RectTransform>().rect.width / 2;
        float yHalfSizePiece = piece.GetComponent<RectTransform>().rect.height / 2;
        float boundaryX = xHalfSizeFrame - xHalfSizePiece;
        float boundaryY = yHalfSizeFrame - yHalfSizePiece;
        Vector3 worldPos = myCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 worldPosReal = transformPanel.InverseTransformPoint(worldPos);
        gameObject.transform.localPosition = new Vector3(Mathf.Clamp(worldPosReal.x, -boundaryX, boundaryX), Mathf.Clamp(worldPosReal.y, -boundaryY, boundaryY), 0.0f);
    }


}
