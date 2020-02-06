using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomContainer : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioMixerGroup output;
    public KeyCode keyToPress = KeyCode.Space;
    public float minPitch = 0.25f;
    public float maxPitch = 1.75f;

    //added
        //Debug select
    public KeyCode keyToPressS1 = KeyCode.Q;
    public KeyCode keyToPressS2 = KeyCode.W;
    public KeyCode keyToPressS3 = KeyCode.E;
    //added
        //Clips to Test
    public int S1 = 0;
    public int S2 = 1;
    public int S3 = 2;
    //added
        //If pitch is random
    public bool changePitch = true;
    //added
        //If pitch is set
    public bool setPitch = false;
    //added
        //set Pitch
    public float setPitchF = 1;
    //added
        //If Volume is set
    public bool setVolume = false;
    //added
        //set Volume
    public float setVolumeF = 1;
    //added
        //Between 0 and 1 (catch active)
    public float minVolume = 0.0f;
    public float maxVolume = 1.0f;
    //added
        //If Volume is random
    public bool changeVolume = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            //random array
            int randomClip = Random.Range(0, clips.Length);
            PlaySound(randomClip);
        }else
        if (Input.GetKeyDown(keyToPressS1) && clips.Length > S1)
        {
            PlaySound(S1);
        }else
        if (Input.GetKeyDown(keyToPressS2) && clips.Length > S2)
        {
            PlaySound(S2);
        }else
        if (Input.GetKeyDown(keyToPressS3) && clips.Length > S3)
        {
            PlaySound(S3);
        }
    }

    public void PlaySoundRandom()
    {
        int randomClip = Random.Range(0, clips.Length);
        PlaySound(randomClip);
    }

    public void SetSound(float NewPitch = 1, float NewVolume = 1)
    {
        setPitchF = NewPitch;
        setVolumeF = NewVolume;
    }
    public void SetSoundRange(float NewPitchMin = 0.25f, float NewPitchMax = 1.75f, float NewVolumeMin = 0, float NewVolumeMax = 1)
    {
        minPitch = NewPitchMin;
        maxPitch = NewPitchMax;
        minVolume = NewVolumeMin;
        maxVolume = NewVolumeMax;
    }
    public void PlaySound(int listNum = 0)
    {
        //Check
        if(clips[listNum] == null)
        {
            return;
        }

        //Audio Source
        AudioSource source = gameObject.AddComponent<AudioSource>();

        //load clip
        source.clip = clips[listNum];

        //set output
        source.outputAudioMixerGroup = output;

        //added
        if (changePitch)
        {
            //set pitch
            source.pitch = Random.Range(minPitch, maxPitch);
        }

        //added
        if (setPitch)
        {
            source.pitch = setPitchF;
        }

        //added
        if (changeVolume)
        {
            //Check
            if(minVolume < 0)
            {
                minVolume = 0;
            }
            if (maxVolume > 1)
            {
                minVolume = 1;
            }
            //added
            //Set Volume
            source.volume = Random.Range(minVolume, maxVolume);
        }

        //added
        if (setVolume)
        {
            if (setVolumeF > 1)
            {
                source.volume = 1.0f;
            }
            else
            if (setVolumeF < 0)
            {
                source.volume = 0.0f;
            }
            else
            {
                source.volume = setVolumeF;
            }
        }

        //Play clip
        source.Play();

        //"Clean" audio
        Destroy(source, clips[listNum].length);

    }
}
