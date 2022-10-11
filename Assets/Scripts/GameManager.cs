using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //these lists have all the dialogue for each phase of questions
    public List<string> phaseOneDialogue;
    public List<string> phaseTwoDialogue;
    public List<string> phaseThreeDialogue;
    public List<string> phaseFourDialogue;
    public List<string> phaseFiveDialogue;

    //holds the phase we're currently going through
    List<string> currentDialogue;

    //tracks the current phase and the line we're on in that phase
    int phaseIndex = 0;
    int dialogueIndex = 0;

    //game object for all buttons
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject choiceThree;
    public GameObject choiceFour;
    public GameObject choiceFive;
    public GameObject choiceSix;
    public GameObject choiceSeven;
    public GameObject choiceEight;
    public GameObject nextButton;

    //text component that is showing the dialogue
    public TMP_Text dialogueBox;

    //"score" for how much grunge girl likes you
    int sheLikesYou = 0;

    //text for results of the quiz
    public string aSecondDate;
    public string seeYou;

    //animator components for each face
    //public Animator grungeGirlAnim;

    // Start is called before the first frame update
    void Start()
    {
        //turn off the choice buttons
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
        choiceFour.SetActive(false);
        choiceFive.SetActive(false);
        choiceSix.SetActive(false);
        choiceSeven.SetActive(false);
        choiceEight.SetActive(false);

        //start the dialogue
        currentDialogue = phaseOneDialogue;
        dialogueBox.text = currentDialogue[dialogueIndex];
        //faceyAnim.SetTrigger("isTalking");
    }

    void SetDialogueText()
    {
        //if we haven't gotten our results yet
        if (phaseIndex < 5)
        {
            //set the dialogue component to show the line we're on
            dialogueBox.text = currentDialogue[dialogueIndex];
        }
    }

    public void AdvanceDialog()
    {
        //if we haven't gotten our results yet
        if (phaseIndex < 4)
        {
            //go to the next line
            dialogueIndex++;
            SetDialogueText();

            //if we're on the last line of dialogue
            if (dialogueIndex == currentDialogue.Count - 1)
            {
                if (phaseIndex == 0)
                {
                    FirstChoiceSetup();
                } else if (phaseIndex == 1)
                {
                    SecondChoiceSetup();
                } else if (phaseIndex == 2)
                {
                    ThirdChoiceSetup();
                } else if (phaseIndex == 3)
                {
                    FourthChoiceSetup();
                }

                //go to the next line
                dialogueIndex++;
                SetDialogueText();
            }
        }
        //if we've seen our results
        else
        {
            //go to the last scene
            SceneManager.LoadScene("Main");
        }
    }

    void FirstChoiceSetup()
    {
        dialogueIndex = 0;
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
        choiceThree.SetActive(false);
        choiceFour.SetActive(false);
        choiceFive.SetActive(false);
        choiceSix.SetActive(false);
        choiceSeven.SetActive(false);
        choiceEight.SetActive(false);
    }

    void SecondChoiceSetup()
    {
        dialogueIndex = 0;
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(true);
        choiceFour.SetActive(true);
        choiceFive.SetActive(false);
        choiceSix.SetActive(false);
        choiceSeven.SetActive(false);
        choiceEight.SetActive(false);
    }

    void ThirdChoiceSetup()
    {
        dialogueIndex = 0;
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
        choiceFour.SetActive(false);
        choiceFive.SetActive(true);
        choiceSix.SetActive(true);
        choiceSeven.SetActive(false);
        choiceEight.SetActive(false);
    }

    void FourthChoiceSetup()
    {
        dialogueIndex = 0;
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
        choiceFour.SetActive(false);
        choiceFive.SetActive(false);
        choiceSix.SetActive(false);
        choiceSeven.SetActive(true);
        choiceEight.SetActive(true);
    }

    public void ExpressiveChoice()
    {
        //only there for flavor; if we press either buttons, just go to
        //the next phase of questions
        GoToNextPhase();
    }

    public void JoChoice()
    {
        //if we press "yes," increase Jo's score and go to the next phase
        sheLikesYou++;
        GoToNextPhase();
    }

    public void NotAJoChoice()
    {
        //if we press "no," just go to the next phase
        GoToNextPhase();
    }

    public void WeakNarrativeChoice()
    {
        //a choice with no consequences to the date, but it makes you think there are going to be consequences
        //if either is pressed, go to next phase
        GoToNextPhase();
    }

    public void RightUnfairChoice()
    {
        //if we press this choice, increase Jo's score and go to the next phase
        sheLikesYou++;
        GoToNextPhase();
    }

    public void NotRightUnfairChoice()
    {
        //if we press this choice, does not harm score but go to the next phase
        GoToNextPhase();
    }

    void GoToNextPhase()
    {
        //turn on the next button and turn off the choice buttons
        nextButton.SetActive(true);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
        choiceFour.SetActive(false);
        choiceFive.SetActive(false);
        choiceSix.SetActive(false);
        choiceSeven.SetActive(false);
        choiceEight.SetActive(false);

        //reset the dialogue line counter
        dialogueIndex = 0;
        //depending on the phase
        //run an animation and determine what the next phase is
        switch (phaseIndex)
        {
            case 0:
                //faceyAnim.SetTrigger("isTalking");
                currentDialogue = phaseTwoDialogue;
                phaseIndex = 1;
                break;
            case 1:
                currentDialogue = phaseThreeDialogue;
                phaseIndex = 2;
                break;
            case 2:
                //clownyAnim.SetTrigger("isTalking");
                currentDialogue = phaseFourDialogue;
                phaseIndex = 3;
                break;
            case 3:
                //faceyAnim.SetTrigger("isTalking");
                currentDialogue= phaseFiveDialogue;
                phaseIndex = 4;
                break;
            case 4:
                GiveResults();
                break;
        }
        SetDialogueText();
    }

    void GiveResults()
    {
        //if the clown score is higher than 2, then u r a clown
        if (sheLikesYou == 2)
        {
            dialogueBox.text = aSecondDate;
        }
        else
        {
            dialogueBox.text = seeYou;
        }
    }

}