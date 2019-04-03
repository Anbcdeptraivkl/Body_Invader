using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionSettings : MonoBehaviour
{
   public AudioMixer audioMixer;

   public void VolumeSLiding (float volume) {
       audioMixer.SetFloat("masterVolume", volume);
   }
}
