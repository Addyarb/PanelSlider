using System;
using UnityEngine;

[Serializable]
public class PanelMover : UIManager
{
    public Canvas canvas;
    public RectTransform[] panels;
    public  bool canNavigate = true;
    public int index;
    float panelWidth;

    void Start()
    {
        Init(canvas.GetComponent<RectTransform>().sizeDelta);
    }

    public void Init(Vector2 canvasSize)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].anchorMin = panels[i].anchorMax = panels[i].pivot = Vector2.one * 0.5f;
            panels[i].sizeDelta = new Vector2(panels[i].sizeDelta.x, canvasSize.y);
            panels[i].gameObject.SetActive(i == index);
        }

        panelWidth = panels[0].sizeDelta.x;
        panels[2].anchoredPosition = Vector2.zero;
    }

    public void NavigateToPanel(int fromPanel, int toPanel)
    {
        var isMovingLeft = true;

        for (int i = 0; i < panels.Length; i++)
            panels[i].gameObject.SetActive(i == fromPanel || i == toPanel);

        if (fromPanel < toPanel || fromPanel == 4 && toPanel == 0)
            isMovingLeft = false;

        if (fromPanel == 0 && toPanel == 4)
            isMovingLeft = true;

        var toPanelStartPos = (isMovingLeft) ? panelWidth : -panelWidth;

        StartCoroutine(MoveAnchorPositionX(panels[toPanel], toPanelStartPos, 0));
        StartCoroutine(MoveAnchorPositionX(panels[toPanel], 0, 0.35f));
        StartCoroutine(MoveAnchorPositionX(panels[fromPanel], toPanelStartPos, 0.35f, () =>
                {
                    panels[fromPanel].gameObject.SetActive(false);
                    canNavigate = true;
                }));


        // panels[toPanel].DOAnchorPosX(toPanelStartPos, 0);
        // panels[fromPanel].DOAnchorPosX(isMovingLeft ? -panelWidth : panelWidth, AnimationSpeeds.fast).OnComplete(() =>
        //   {
        //      panels[fromPanel].gameObject.SetActive(false);
        //      canNavigate = true;
        //  });
        //  panels[toPanel].DOAnchorPosX(0, AnimationSpeeds.fast);
    }

}
