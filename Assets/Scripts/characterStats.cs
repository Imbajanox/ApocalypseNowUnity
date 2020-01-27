using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterStats : MonoBehaviour
{
    public Text myText;
    public Text myLevelText;
    public long expCurrent;
    public int money;
    public int levelCurrent;
    public int nextLevel;
    // Start is called before the first frame update
    void Start()
    {

        levelCurrent = 1;
        expCurrent = 0;
        ExpText();
        LevelText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            getEXP(20);
            ExpText();
            LevelText();
            Debug.Log(expCurrent);
            Debug.Log(levelCurrent);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            getEXP(200);
            ExpText();
            LevelText();
            Debug.Log(expCurrent);
            Debug.Log(levelCurrent);
        }

        levelUp();
    }

    void levelUp()
    {
        while (expCurrent >= expNeeded(levelCurrent))
        {
            expCurrent -= expNeeded(levelCurrent);
            levelCurrent++;
            ExpText();
            LevelText();
        }
    }
    void getEXP(long xp)
    {
        expCurrent += xp;
    }
    long expNeeded(int level)
    {
        long newEXP = ((25 * level) * (1 + level));
        return newEXP;
    }

    public void ExpText()
    {
        //myText = GameObject.FindGameObjectWithTag("ExpText").GetComponent<Text>();
        // here the variable myText reference to the game Object MainText

        myText.text = expCurrent.ToString() + " / " + expNeeded(levelCurrent) + " Exp";

    }

    public void LevelText()
    {
        //myLevelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        // here the variable myText reference to the game Object MainText

        myLevelText.text = " Level: " + levelCurrent;

    }

}
