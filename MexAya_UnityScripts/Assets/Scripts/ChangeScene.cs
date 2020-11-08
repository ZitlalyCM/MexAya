using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changeScene(string escena){
        SceneManager.LoadScene(escena);
    }
    public void playSFX(string sfxName){
        float _volume = 2f;
        float _pitch = 1f;
		AudioClip sfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/{0}",sfxName));
		AudioManager.instance.PlaySFX(sfx, _volume, _pitch);
	}
}
