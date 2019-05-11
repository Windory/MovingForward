using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private List<IsometricController> characters = new List<IsometricController>(4); // List with all characters
    private List<IsometricController> charactersEnd = new List<IsometricController>(3); // List with the characters who reached the end
    private List<IsometricController> charactersDead = new List<IsometricController>(3); // List with the dead characters
    private int cha = 0; // Current index of the characters list (active character)
    private float h, v = 0.0f;
    private static PlayerController instance;
    private bool canMove = true;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GetCharacters();
    }

    public void GetCharacters()
    {
        string[] tags = { "Velma", "Fred", "Dapne", "Dog" };
        for (int i = 0; i < 4; ++i)
        {
            characters.Add(GameObject.Find(tags[i]).GetComponent<IsometricController>());
        }
        GameManager.getInstance().CameraFollowObject(characters[cha].gameObject);
        characters[cha].Go();
    }

    public void ResetList()
    {
        foreach(IsometricController chara in charactersDead)
        {
            chara.gameObject.SetActive(true);
            characters.Add(chara);
        }
    }

    public static PlayerController GetInstance()
    {
        return instance;
    }

    private void FixedUpdate()
    {
        if (canMove)
            ProcessMove();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
       
        ProcessInteract();
        ProcessSwitch();
        ProcessRetry();
    }

    // Switch the current character to the next one in the list
    private void Switch()
    {
        characters[cha].Stop();
        ++cha;
        if (cha == characters.Count)
            cha = 0;
        GameManager.getInstance().CameraFollowObject(characters[cha].gameObject);
        characters[cha].Go();
        AudioSource audio = characters[cha].gameObject.GetComponent<AudioSource>();
        if (audio)
        {
            audio.Play();
        }
    }

    private void Retry()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (audio)
        {
            audio.Play();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ProcessMove()
    {
        characters[cha].Move(h, v);
    }

    private void ProcessInteract()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characters[cha].Interact();
        }
    }

    private void ProcessSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Switch();
        }
    }

    private void ProcessRetry()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Retry();
        }
    }

    public void CharacterExit()
    {
        canMove = false;
        characters[cha].Stop();
        int chaEnd = cha;
        charactersEnd.Add(characters[chaEnd]);
        characters[chaEnd].gameObject.SetActive(false);
        characters.RemoveAt(chaEnd);
        if (cha == characters.Count)
            cha = 0;

        if (characters.Count == 1)
        {
            charactersDead.Add(characters[0]);
            characters[0].gameObject.SetActive(false);
            characters.RemoveAt(0);
            for (int i = 0; i < charactersEnd.Count; ++i)
            {
                characters.Add(charactersEnd[i]);
                characters[i].gameObject.SetActive(true);
            }
            charactersEnd.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        GameManager.getInstance().CameraFollowObject(characters[cha].gameObject);
        characters[cha].Go();
        canMove = true;
    }
}