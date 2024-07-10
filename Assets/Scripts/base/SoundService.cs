using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    public enum SoundType
    {
        none = 0,
        sound_bg = 1,
        sound_fire_1 = 2,
        sound_explosion = 3,
    }

    public class SoundService : SingletonMono<SoundService>
    {
        [SerializeField]
        private AudioSource bgMusic;

        [SerializeField]
        private AudioSource sound;

        private SoundType _bgMusicName;

        private Dictionary<int, float> _startTimes;

        private const float MIN_INTERVAL = 0.1f;

        private bool _fadeInning;

        private bool _fadeOuting;

        private float _fadeInOutTimeMax = 1f;

        private float _fadeInOutTime;

        private IEnumerator _orderBgm;

        private float _volume;

        private void Start()
        {
            _startTimes = new Dictionary<int, float>();

            //this.Sub(MessageId.change_setting_music, _ => OnMusicChanged());

            _volume = 1;
        }

        private void Update()
        {
            if (_fadeOuting)
            {
                _fadeInning = false;
                _fadeInOutTime += Time.deltaTime;
                if (_fadeInOutTime >= _fadeInOutTimeMax)
                {
                    _fadeOuting = false;
                    bgMusic.volume = 0f;
                    bgMusic.Stop();
                }
                else
                {
                    bgMusic.volume = _volume - _fadeInOutTime / _fadeInOutTimeMax;
                }
            }
            if (_fadeInning)
            {
                _fadeInOutTime += Time.deltaTime;
                if (_fadeInOutTime >= _fadeInOutTimeMax)
                {
                    _fadeInning = false;
                    bgMusic.volume = _volume;
                }
                else
                {
                    bgMusic.volume = _fadeInOutTime / _fadeInOutTimeMax;
                }
            }
        }
    

        private void OnMusicChanged()
        {
            var changeValue = true/* PlayerService.SettingService.GetPlayerSetting(SettingType.music)*/;
        
            if (changeValue)
            {
                ResumeBackgroundMusic();
            }
            else
            {
                StopBackgroundMusic();
            }
        }

        public void PlayBackgroundMusic(SoundType soundType, bool loop = true, bool overrideMode = true)
        {
            if (overrideMode)
            {
                StopOrderedBgm();
            }
            bool flag = true;
            if (_bgMusicName != soundType)
            {
                bgMusic.clip = LoadAudioClip(soundType);
            }
            else if (bgMusic.isPlaying)
            {
                flag = false;
            }
            if (_fadeOuting)
            {
                _fadeOuting = false;
                _fadeInOutTime = 0f;
                flag = true;
            }
            _bgMusicName = soundType;
            bgMusic.loop = loop;
            if (flag /*&& PlayerService.SettingService.GetPlayerSetting(SettingType.music)*/)
            {
                bgMusic.Play();
                _fadeInning = true;
                _fadeInOutTime = 0f;
                bgMusic.volume = 0f;
            }
        }

        public void StopBackgroundMusic()
        {
            if (!_fadeOuting && bgMusic.isPlaying)
            {
                _fadeOuting = true;
                _fadeInOutTime = 0f;
                bgMusic.volume = _volume;
            }
        }

        public void ResumeBackgroundMusic()
        {
            _fadeOuting = false;
            PlayBackgroundMusic(_bgMusicName, bgMusic.loop);
        }

        public void SetBackgroundVolume(float vol)
        {
            if (bgMusic != null)
            {
                bgMusic.volume = vol;
            }
        }

        public float GetBackgroundVolume()
        {
            return (!(bgMusic == null)) ? bgMusic.volume : 0f;
        }

        public void PlayOrderedBgm(params SoundType[] music)
        {
            StopOrderedBgm();
            _orderBgm = DoPlayOrderedBgm(music);
            StartCoroutine(_orderBgm);
        }

        private void StopOrderedBgm()
        {
            if (_orderBgm != null)
            {
                StopCoroutine(_orderBgm);
                _orderBgm = null;
            }
        }

        private IEnumerator DoPlayOrderedBgm(params SoundType[] music)
        {
            for (int i = 0; i < music.Length; i++)
            {
                if (i == music.Length - 1)
                {
                    PlayBackgroundMusic(music[i], loop: true, overrideMode: false);
                    continue;
                }
                PlayBackgroundMusic(music[i], loop: false, overrideMode: false);
                yield return new WaitForSeconds(bgMusic.clip.length);
            }
        }


        public void PlaySound(SoundType soundType, bool loop = false, float delay = 0f, float volumeScale = 1f)
        {
            AudioClip audioClip = LoadAudioClip(soundType);
        
            if (audioClip != null)
            {
                PlaySound(audioClip, loop, delay, volumeScale);
            }
        }

        private void PlaySound(AudioClip clip, bool loop = false, float delay = 0f, float volumeScale = 1f)
        {
            if ( true/*PlayerService.SettingService.GetPlayerSetting(SettingType.sound)*/)
            {
                if (!(clip == null))
                {
                    sound.loop = loop;
                    if (delay > 0f)
                    {
                        StartCoroutine(PlaySoundDelay(clip, delay, volumeScale));
                    }
                    else if (SetStartTime(clip.GetInstanceID()))
                    {
                        if (!loop)
                        {
                            sound.PlayOneShot(clip, volumeScale);
                        }
                        else
                        {
                            sound.clip = clip;
                            sound.Play();
                        }
                    }
                }
            }
        }

        private IEnumerator PlaySoundDelay(AudioClip clip, float delay = 0f, float volumeScale = 1f)
        {
            yield return new WaitForSecondsRealtime(delay);
            PlaySound(clip, false, 0f, volumeScale);
        }

        private bool SetStartTime(int audio)
        {
            if (!_startTimes.ContainsKey(audio))
            {
                _startTimes[audio] = 0f;
            }
            if (Time.time - _startTimes[audio] > 0.1f)
            {
                _startTimes[audio] = Time.time;
                return true;
            }
            return false;
        }
        
        private AudioClip LoadAudioClip(SoundType soundType)
        {
            return Resources.Load<AudioClip>($"Sound/{soundType.ToString()}"); 
        }
    }
}
