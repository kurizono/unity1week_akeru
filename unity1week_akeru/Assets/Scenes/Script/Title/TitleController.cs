using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    public GameObject FirstBoxes, Story, Setting1, Setting2, Arrow, LeftArrow;
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
    int settingnum = 0;

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
        Setting1.SetActive(false);
        Setting2.SetActive(false);
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
        switch (settingnum) {
            case 0:
                FirstBoxes.SetActive(false);
                Setting1.SetActive(true);
                Setting2.SetActive(false);
                Arrow.SetActive(true);
                LeftArrow.SetActive(true);
                Title.SetActive(false);
                SettingMesseage1.SetActive(true);
                SettingMesseage2.SetActive(false);
                nowstatus = titlestatus.Setting;
                break;
            case 1:
                Setting1.SetActive(false);
                Setting2.SetActive(true);
                SettingMesseage1.SetActive(false);
                SettingMesseage2.SetActive(true);
                break;
        } 
    }

    public void RightArrowClick()
    {
        if (movestatus == Move_byarrow.Stop)
        {
            Debug.Log(nowstatus);
            switch (nowstatus)
            {
                case titlestatus.Story:
                    movestatus = Move_byarrow.Move;
                    movetime = 0;
                    break;
                case titlestatus.Setting:
                    settingnum = (settingnum + 1) % 2;
                    SettingClick();
                    break;
            }
        }
    }
    public void LeftArrowClick()
    {
        switch (nowstatus)
        {
            case titlestatus.Setting:
                settingnum = (settingnum + 3) % 2;
                SettingClick();
                break;
        }
    }
}
