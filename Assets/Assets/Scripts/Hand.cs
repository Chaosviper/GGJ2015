using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hand : MonoBehaviour {

    public bool left;
    public GameObject otherHand;
    public GameObject mosquito;

    private bool smashAnimation;
    private float smashAnimationTimer;
    private int animationState;         // 0: andata, 1: fermo, 2: ritorno
    private float smashDistance;
    private float finishPosition;
    private float startPosition;

    public GameObject mosquitoDead;

    public GameObject fuckYou;

    public Text text;

    private int points = 0;

    private float score = 1000;

    private float timeToNextPoint = 0.0f;

    private int clapTimes = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
    void Update()
    {

        text.text = "" + (int)(score);

        score -= Constants.decreaseScoreVelocity * Time.deltaTime;
        if (score <= 0.0f) score = 0.0f;
             
        float horizontal;
        float vertical;
        bool smash;

        if (left)
        {
            horizontal = Input.GetAxis("Horizontal1");
            vertical = Input.GetAxis("Vertical1");
            smash = Input.GetButtonDown("LB");
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal2");
            vertical = Input.GetAxis("Vertical2");
            smash = Input.GetButtonDown("RB");
        }

        if (smash && !smashAnimation)
        {
            smashAnimation = true;
            animationState = 0;
            smashAnimationTimer = Constants.smashAnimationDuration;
            finishPosition = (transform.position.x + otherHand.transform.position.x) / 2.0f;
            smashDistance = (otherHand.transform.position.x - transform.position.x) /2.0f;
            startPosition = transform.position.x;
        }

        if (!smashAnimation)
        {

            float horizontalMovement = horizontal * Constants.HandMovementSpeed * Time.deltaTime;
            float verticalMovement = vertical * Constants.HandMovementSpeed * Time.deltaTime;

            if (transform.position.x + horizontalMovement <= -Constants.maxPosX && horizontal < 0)
            {
                horizontalMovement = 0;
            }
            else if (transform.position.x + horizontalMovement >= Constants.maxPosX && horizontal > 0)
            {
                horizontalMovement = 0;
            }

            if (transform.position.y + verticalMovement <= -Constants.maxPosY && vertical < 0)
            {
                verticalMovement = 0;
            }
            else if (transform.position.y + verticalMovement >= Constants.maxPosY && vertical > 0)
            {
                verticalMovement = 0;
            }


            if (!checkHandsInversion(horizontalMovement))
                horizontalMovement = 0;

            transform.Translate(new Vector3(horizontalMovement, verticalMovement, 0));

        }
        else
        {
            doSmashAnimation();
            if (verifyPickFly() && timeToNextPoint <= 0.0f)
            {
                points++;
                Debug.Log("Punti");
                timeToNextPoint = 1.0f;
                if (mosquito.transform.position.x >= 0)
                mosquito.transform.position = new Vector3(-4.5f, 4.0f, 0.0f);
                else mosquito.transform.position = new Vector3(4.5f, 4.0f, 0.0f);

                mosquito.audio.Stop();
                mosquitoDead.audio.Play();
                mosquito.audio.Play();
            }
            else if (verifyClap() && timeToNextPoint <= 0)
            {
                if (left) 
                {

                    clapTimes++;

                    if (clapTimes%100 != 0)
                    {
                        audio.Play();
                    }
                    else
                    {
                        audio.Play();
                        fuckYou.audio.Play();
                    }

                }
            }

            if (points >= Constants.maxPointsToWin)
            {
				GameManager.IncrementScore((int) score);
				GameManager.DoneAnotherScene();
				Application.LoadLevel(2);
                //Debug.Log("VINTO!");
            }
        }

        timeToNextPoint -= Time.deltaTime;
        if (timeToNextPoint < 0.0f)
            timeToNextPoint = 0.0f;


    }

    bool checkHandsInversion(float horizontalMovement)
    {
        if (left)
        {
            if (transform.position.x + horizontalMovement + Constants.maxHandDistance >= otherHand.transform.position.x)
            {
                return false;
            }
            else return true;
       }
        else
        {
            if (transform.position.x + horizontalMovement - Constants.maxHandDistance <= otherHand.transform.position.x)
            {
                return false;
            }
            else return true;
        }
    }

    void doSmashAnimation()
    {
        if (left)
        {

            float timeToArrive = (Constants.smashAnimationDuration - Constants.smashAnimationStopDuration) / 2.0f;  //and time to go

            if (animationState == 0)
            {

                transform.Translate(40.0f * Time.deltaTime, 0.0f, 0.0f);

                if (transform.position.x >= finishPosition)
                {
                    transform.position = new Vector3(finishPosition, transform.position.y, transform.position.z);
                    animationState++;
                }

            }
            else if (animationState == 1)
            {
                if (smashAnimationTimer <= Constants.smashAnimationDuration - timeToArrive - Constants.smashAnimationStopDuration)
                {
                    animationState++;
                }
            }
            else if (animationState == 2)
            {
                transform.Translate(-40.0f * Time.deltaTime, 0.0f, 0.0f);

                if (transform.position.x <= startPosition)
                {
                    transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
                    animationState = 0;
                    smashAnimation = false;
                }
            }

        }
        else
        {
            float timeToArrive = (Constants.smashAnimationDuration - Constants.smashAnimationStopDuration) / 2.0f;  //and time to go

            if (animationState == 0)
            {

                transform.Translate(-40.0f * Time.deltaTime, 0.0f, 0.0f);

                if (transform.position.x <= finishPosition)
                {
                    transform.position = new Vector3(finishPosition, transform.position.y, transform.position.z);
                    animationState++;
                }

            }
            else if (animationState == 1)
            {
                if (smashAnimationTimer <= Constants.smashAnimationDuration - timeToArrive - Constants.smashAnimationStopDuration)
                {
                    animationState++;
                }
            }
            else if (animationState == 2)
            {
                transform.Translate(+40.0f * Time.deltaTime, 0.0f, 0.0f);

                if (transform.position.x >= startPosition)
                {
                    transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
                    animationState = 0;
                    smashAnimation = false;
                }
            }
        }

        smashAnimationTimer -= Time.deltaTime;

        if (smashAnimationTimer < 0)
        {
            smashAnimation = false;
        }
    }

    bool verifyPickFly(){
        
        if(left){
            if (Vector3.Distance(transform.position, otherHand.transform.position) < Constants.checkDistance)
            {

                if (Vector3.Distance(transform.position, mosquito.transform.position) < Constants.checkDistance)
                {
                    return true;
                }
            }
        }

        return false;

    }

    bool verifyClap()
    {
        if (left)
        {
            if (Vector3.Distance(transform.position, otherHand.transform.position) < Constants.checkDistance)
            {
                return true;
            }
        }

        return false;
    }

}
