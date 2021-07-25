using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using PathCreation.Examples;
using UnityEngine;
using Helper;

public enum SoundEffectsName
{
    Walking,
    RollerCoaster,
    Crash,
    Hit1,
    Hit2,
    Hit3
}
public class SoundManager : MonoBehaviour
{
    public SerializableDictionaryBase<SoundEffectsName, AudioSource> SoundEffects = new SerializableDictionaryBase<SoundEffectsName, AudioSource>();

    private PathFollower _cartControlScript;

    private void Start()
    {
        _cartControlScript = FindObjectOfType<PathFollower>();
    }

    private void FixedUpdate()
    {
        ChangeRollerCoasterAudioSpeed(_cartControlScript.speed);
    }
    public void PlaySound(SoundEffectsName effectName)
    {
        if (!SoundEffects[effectName].isPlaying) SoundEffects[effectName].Play();
    }
    public void PlayCrashSound()
    {
        if (SoundEffects[SoundEffectsName.RollerCoaster].isPlaying) SoundEffects[SoundEffectsName.RollerCoaster].Stop();
        if (!SoundEffects[SoundEffectsName.Crash].isPlaying) SoundEffects[SoundEffectsName.Crash].Play();
    }
    public void StopSound(SoundEffectsName effectName)
    {
        if (SoundEffects[effectName].isPlaying) SoundEffects[effectName].Stop();
    }
    public void ChangeRollerCoasterAudioSpeed(float targetSpeed)
    {
        SoundEffects[SoundEffectsName.RollerCoaster].pitch = targetSpeed.Remap(0, 40, 1, 1.7f);
    }
    
    

}
