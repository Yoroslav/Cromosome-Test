using UnityEngine;

public class PlayMusicBG : MonoBehaviour
{
    public GameObject BGMusic;
    private AudioSource audioSrc;
    public GameObject[] objestsSouns;

    void Awake()
    {
        objestsSouns = GameObject.FindGameObjectsWithTag("Sound");
        if (objestsSouns.Length == 0)
        {
            BGMusic = Instantiate(BGMusic);
            BGMusic.name = "BGMusic";
            DontDestroyOnLoad(BGMusic.gameObject);
        }
        else
        {
            BGMusic = GameObject.Find("BGMusic");
        }
    }
    void Start()
    {
        audioSrc = BGMusic.GetComponent<AudioSource>();
    }
}
