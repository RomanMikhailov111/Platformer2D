using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        [Range(1, 30)]
        private int _frameRate = 10;
        [SerializeField]
        private UnityEvent<string> _onComplete;
        [SerializeField]
        private SpriteAnimationClip[] _clips;

        private float _secondPerFrame;
        private float _nextFrameTime;
        private int _currentFrame;
        private int _currentClip;
        private bool _isPlaying = true;


        // Use this for initialization
        void Start()
        {
            _secondPerFrame = 1f / _frameRate;
            StartAnimation();
        }

        private void OnEnable()
        {
            _nextFrameTime = Time.time;
        }

        private void OnBecameVisible()
        {
            enabled = _isPlaying;
        }

        private void OnBecameInvisible()
        {
            enabled = false;
        }

        void Update()
        {
            if (_nextFrameTime > Time.time)
            {
                return;
            }

            SpriteAnimationClip clip = _clips[_currentClip];

            if (_currentFrame >= clip.Sprites.Length)
            {
                if (clip.Loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    enabled = _isPlaying = clip.AllowNextClip;

                    clip.OnComplete?.Invoke();
                    _onComplete?.Invoke(clip.Name);

                    if (clip.AllowNextClip)
                    {
                        _currentFrame = 0;

                        _currentClip = (int)Mathf.Repeat(_currentClip + 1, _clips.Length);
                    }
                }
                return;
            }

            _spriteRenderer.sprite = clip.Sprites[_currentFrame];
            _nextFrameTime += _secondPerFrame;
            _currentFrame++;
        }
        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            enabled = _isPlaying = true;
            _currentFrame = 0;
        }
    }

    
    [Serializable]
    public class SpriteAnimationClip
    {
        public string Name;
        public Sprite[] Sprites;
        public bool Loop;
        public bool AllowNextClip;
        public UnityEvent OnComplete;
    }
}