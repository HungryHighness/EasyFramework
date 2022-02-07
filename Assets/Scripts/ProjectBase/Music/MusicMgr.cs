using System.Collections.Generic;
using ProjectBase.Mono;
using ProjectBase.Res;
using Scripts.ProjectBase.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectBase.Music
{
    public class MusicMgr : BaseManager<MusicMgr>
    {
        private AudioSource _bkMusic = null;
        private float _bkValue = 1f;
        private GameObject _soundObj = null;
        private List<AudioSource> _soundList = new List<AudioSource>();
        private float _soundValue = 1f;


        public MusicMgr()
        {
            MonoMgr.GetInstance().AddUpdateListener(Update);
        }

        private void Update()
        {
            for (var i = 0; i < _soundList.Count; i++)
            {
                if (!_soundList[i].isPlaying)
                {
                    GameObject.Destroy(_soundList[i]);
                    _soundList.RemoveAt(i);
                }
            }
        }

        public void PlayBkMusic(string name)
        {
            if (_bkMusic == null)
            {
                GameObject obj = new GameObject
                {
                    name = "BkMusic"
                };
                _bkMusic = obj.AddComponent<AudioSource>();
            }

            ResMgr.GetInstance()
                .LoadAsync<AudioClip>("Music/Bk/" + name, (bkMusicClip =>
                {
                    _bkMusic.clip = bkMusicClip;
                    _bkMusic.volume = _bkValue;
                    _bkMusic.loop = true;
                    _bkMusic.Play();
                }));
        }

        public void PauseBkMusic()
        {
            if (_bkMusic == null)
            {
                return;
            }

            _bkMusic.Pause();
        }

        public void StopBkMusic()
        {
            if (_bkMusic == null)
            {
                return;
            }

            _bkMusic.Stop();
        }

        public void ChangeBkValue(float v)
        {
            _bkValue = v;
            if (_bkMusic == null)
            {
                return;
            }

            _bkMusic.volume = _bkValue;
        }

        public void PlaySound(string name, bool isLoop = false, UnityAction<AudioSource> callback = null)
        {
            if (_soundObj == null)
            {
                _soundObj = new GameObject()
                {
                    name = "SoundMusic"
                };
            }

            ResMgr.GetInstance()
                .LoadAsync<AudioClip>("Music/Sound/" + name, (sourceClip =>
                {
                    var source = _soundObj.AddComponent<AudioSource>();
                    source.clip = sourceClip;
                    source.volume = _bkValue;
                    source.loop = isLoop;
                    source.Play();
                    _soundList.Add(source);
                    callback?.Invoke(source);
                }));
        }

        public void StopSound(AudioSource source)
        {
            if (_soundList.Contains(source))
            {
                _soundList.Remove(source);
                source.Stop();
                Object.Destroy(source);
            }
        }

        public void ChangeSoundValue(float v)
        {
            _soundValue = v;
            for (var i = 0; i < _soundList.Count; i++)
            {
                _soundList[i].volume = _soundValue;
            }
        }

    }
}