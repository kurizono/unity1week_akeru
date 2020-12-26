using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    public GameObject FirstBoxes, Story, Setting, Arrow, LeftArrow;
    public GameObject Title, SettingMesseage1, SettingMesseage2;

    private enum titlestatus
    {
        Normal,
        Story,
        Explain,
        Credit,
        Setting
    }
    titlestatus nowstatus;

    private enum Move_byarrow
    {
        Stop,
        Move
    }
    Move_byarrow movestatus;

    float movetime;
    float Rotatetime = 1;

    void Start()
    {
        First();
    }

    // Update is called once per frame
    void Update()
    {
        if (movestatus == Move_byarrow.Move)
        {
            movetime += Time.deltaTime;
            float movedistance;
            if (movetime < Rotatetime)
            {
                movedistance = Time.deltaTime;
            }
            else
            {
                movedistance = movetime - Rotatetime;
                movestatus = Move_byarrow.Stop;
            }
            switch (nowstatus)
            {
                case titlestatus.Story:
                    Story.transform.Rotate(0, movedistance * 90 / Rotatetime, 0);
                    break;
            }
        }
    }

    private void First()
    {
        FirstBoxes.SetActive(true);
        Story.SetActive(false);
        Setting.SetActive(false);
        Arrow.SetActive(false);
        LeftArrow.SetActive(false);
        Title.SetActive(true);
        SettingMesseage1.SetActive(false);
        SettingMesseage2.SetActive(false);
        nowstatus = titlestatus.Normal;
        movestatus = Move_byarrow.Stop;
    }

    public void StoryClick()
    {
        FirstBoxes.SetActive(false);
        Title.SetActive(false);
        Story.SetActive(true);
        Arrow.SetActive(true);
        nowstatus = titlestatus.Story;
    }

    public void ExplainClick()
    {
        nowstatus = titlestatus.Explain;
    }

    public void CreditClick()
    {
        nowstatus = titlestatus.Credit;
    }

    public void SettingClick()
    {
        FirstBoxes.SetActive(false);
        Setting.SetActive(true);
        Arrow.SetActive(true);
        LeftArrow.SetActive(true);
        Title.SetActive(false);
        SettingMesseage1.SetActive(true);
        nowstatus = titlestatus.Setting;
    }

    public void RightArrowClick()
    {
        if (movestatus == Move_byarrow.Stop)
        {
            switch (nowstatus)
            {
                case titlestatus.Story:
                    movestatus = Move_byarrow.Move;
                    movetime = 0;
                    break;
                case titlestatus.Setting:
                    break;
            }
        }
    }
    public void LeftArrowClick()
    {

    }
}
