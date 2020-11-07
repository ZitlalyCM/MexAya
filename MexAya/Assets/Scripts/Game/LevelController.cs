using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
	public int nSaltos = 2;
	public GameObject letrero;
	//public Character arian;
	public bool playerEnable=true;
	public bool muerto;
	bool win=false;
    public string musica01;
	string[] _script= new string[]{
		"«¡¡Muy bien!!... frustraste el ataque sopresa enemigo»",
	};
	int final = -1;

	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		playSong(musica01);
		//arian = CharacterManager.instance.GetCharacter("Arian",enableOnStart:false);
	}
	
	// Update is called once per frame
	void Update () {

		if(final != -1){
			if(Input.GetButtonDown("Fire1")){
					SceneManager.LoadScene("Game");
			}
            if(Input.GetKeyDown(KeyCode.Escape)){
					SceneManager.LoadScene("Game");
			}
		}
	}

	public void playSong(string songName,float maxVolume = 1f,float pitch = 1f, float startingVolume=0,bool playOnStart=true,bool loop = true){
		AudioClip song = Resources.Load<AudioClip>(string.Format("Audio/Music/{0}",songName));
		AudioManager.instance.PlaySong(song, maxVolume, pitch, startingVolume, playOnStart, loop);
	}

	public void playSFX(string sfxName, float _volume = 1f, float _pitch = 1f){
		AudioClip sfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/{0}",sfxName));
		AudioManager.instance.PlaySFX(sfx, _volume, _pitch);
	}
}
