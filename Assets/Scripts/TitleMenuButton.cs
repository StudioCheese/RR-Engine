using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenuButton : MonoBehaviour
{
    public bool awakePlay;
    Animator anim;
    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    void OnEnable()
    {
        if (awakePlay)
        {
            OpenMenu();
        }
    }
    public void OpenMenu()
    {
        anim.Play("MenuComeIn", 0);
        List<Button> buttons = new List<Button>();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void FadeMenu()
    {
        anim.Play("MenuFade", 0);
        List<Button> buttons = new List<Button>();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = false;
        }
    }
}
