using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public int noteType;
    private GameManager.judges judge;
    private KeyCode KeyCode;

    void Start()
    {
        if (noteType == 1) KeyCode = KeyCode.D;
        else if (noteType == 2) KeyCode = KeyCode.F;
        else if (noteType == 3) KeyCode = KeyCode.J;
        else if (noteType == 4) KeyCode = KeyCode.K;
    }

    public void Initialize()
    {
        judge = GameManager.judges.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * GameManager.instance.noteSpeed);

        if(Input.GetKey(KeyCode))
        {
            Debug.Log(judge);
            if (judge != GameManager.judges.NONE) gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bad Line")
        {
            judge = GameManager.judges.BAD;
        }
        else if(other.gameObject.tag == "Good Line")
        {
            judge = GameManager.judges.GOOD;
        }
        else if(other.gameObject.tag == "Perfact Line")
        {
            judge = GameManager.judges.PERFACT;
        }
        else if(other.gameObject.tag == "Miss line")
        {
            judge = GameManager.judges.MISS;
            gameObject.SetActive(false);
        }
    }
}
