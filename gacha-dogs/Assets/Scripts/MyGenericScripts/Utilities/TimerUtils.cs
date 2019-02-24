using UnityEngine;

namespace MyGameScripts
{
    public class TimerUtils
    {
        private readonly float _interval;
        private readonly float _decay;
        private readonly bool _loop;
        private float _currentTime;

        public TimerUtils(float interval, float decay, bool loop)
        {
            _currentTime = interval;
            _interval = interval;
            _decay = decay;
            _loop = loop;
        }

        public TimerUtils(float interval, bool loop)
            : this(interval, 1f, loop)
        { }

        public TimerUtils(float interval)
            : this(interval, 1f, false)
        { }

        /// <summary>
        /// Returns true when the time of this timer reachs to zero.
        /// </summary>
        public bool Tick()
        {
            _currentTime -= _decay * Time.deltaTime;
            if (_currentTime < 0f)
            {
                if (_loop)
                    Loop();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Reset the timer to its initial values.
        /// </summary>
        public void Resetting()
        {
            _currentTime = _interval;
        }

        /// <summary>
        /// Change the time to the next loop
        /// </summary>
        private void Loop()
        {
           
        }
    }
}
