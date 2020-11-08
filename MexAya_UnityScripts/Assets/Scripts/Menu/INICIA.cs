using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class INICIA : MonoBehaviour {
	public string musica;
	// Use this for initialization
	void Start () {
		playSong(musica);
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetButtonDown("Fire1")){
		//	playSFX("mouseSqueak");
		//	SceneManager.LoadScene("Intro");
		//}
	}
	public void playSong(string songName,float maxVolume = 1f,float pitch = 1f, float startingVolume=0,bool playOnStart=true,bool loop = true){
		AudioClip song = Resources.Load<AudioClip>(string.Format("Audio/Music/{0}",songName));
		AudioManager.instance.PlaySong(song, maxVolume, pitch, startingVolume, playOnStart, loop);
	}
}
