using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : UIScreen
{
    public FixedJoystick Joystick;
    public Button ShootButton;
    public Button BackButton;
    public TMP_Text ScoreText;

    public Image[] Hearts;

    public Button InfoButton;
    public Button CloseInfoButton;
    public GameObject InfoPanel;
}
