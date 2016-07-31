///
/// A module that deal with animation of control
/// Auther: Exoticknight
/// Last edited: 2013/5/28
/// 

/// List of available static functions:
/// ------------------------------------------------------
/// void HorizontalMove
/// (
///     System.Windows.Forms.Control control,
///     int endLeft,
///     int lastTime,
///     AnimationType animationType
/// )
/// Horizontally move control until control.Left == [endLeft] in given [lastTime], using [animationType]
/// ------------------------------------------------------


using System;

namespace Animation
{
    #region about type of animation
    /// <summary>
    /// a set of type of animation
    /// </summary>
    public enum AnimationType
    {
        /// <summary>
        /// move at one speed
        /// </summary>
        Liner,
        /// <summary>
        /// gradually slow down
        /// </summary>
        Ease,
        /// <summary>
        /// speed up and apeed down
        /// </summary>
        Ball,
        /// <summary>
        /// act like elastic thing
        /// </summary>
        Resilience
    }
    #endregion about type of animation

    public class ControlAnimation
    {
        private static double CalculateValue(AnimationType animationType, double x)
        {
            double _y = 1;
            switch (animationType)
            {
                case AnimationType.Liner:
                    _y = x;
                    break;
                case AnimationType.Ease:
                    _y = Math.Sqrt(x);
                    break;
                case AnimationType.Ball:
                    _y = Math.Sqrt(1.0 - Math.Pow(x - 1, 2));
                    break;
                case AnimationType.Resilience:
                    _y = -10.0 / 6.0 * x * (x - 1.6);
                    break;
            }
            return _y;
        }

        /// <summary>
        /// A class that store a set of animation of the control
        /// </summary>
        class AnimationStatus
        {
            AnimationType _animationType;
            string _attribute;
            int _initValue;
            int _endValue;
            int _totalValue;
            int _totalFrames;
            int _currentFrames;

            /// <summary>
            /// type of the animation, such as liner, Ease...
            /// </summary>
            public AnimationType AnimationType
            {
                get { return _animationType; }
            }
            /// <summary>
            /// attribute of control that the contrl will change
            /// </summary>
            public string Attribute
            {
                get { return _attribute; }
            }
            /// <summary>
            /// current value of the attribute that is ready to change
            /// </summary>
            public int InitValue
            {
                get { return _initValue; }
            }
            /// <summary>
            /// final value of the attribute that is ready to change
            /// </summary>
            public int EndValue
            {
                get { return _endValue; }
            }
            /// <summary>
            /// total value that changed
            /// </summary>
            public int TotalValue
            {
                get { return _totalValue; }
            }
            /// <summary>
            /// total frames the animation should play, READONLY
            /// </summary>
            public int TotalFrames
            {
                get { return _totalFrames; }
            }
            /// <summary>
            /// current frames the animation has played
            /// </summary>
            public int CurrentFrames
            {
                get { return _currentFrames; }
                set { _currentFrames = value; }
            }

            // contructor
            public AnimationStatus(string attribute, int initValue, int endValue, int totalFrames, AnimationType animationType)
            {
                this._attribute = attribute;
                this._animationType = animationType;
                this._initValue = initValue;
                this._endValue = endValue;
                this._totalValue = Math.Abs(this._endValue - this._initValue);
                this._totalFrames = totalFrames;
                this._currentFrames = 1;
            }
        }

        /// <summary>
        /// common function of moving control
        /// </summary>
        /// <param name="contorl">the control to be moved</param>
        /// <param name="timer">the timer that control the time of animation</param>
        /// <param name="animationStatue">current statue of animation</param>
        private static void Animate(System.Windows.Forms.Control contorl, System.Windows.Forms.Timer timer, AnimationStatus animationStatue)
        {
            if (contorl == null
                || contorl.IsDisposed
                || animationStatue.CurrentFrames > animationStatue.TotalFrames)
            {
                timer.Enabled = false;
                return;
            }
            // perform animation
            Type _tp = contorl.GetType();
            System.Reflection.PropertyInfo _pi = _tp.GetProperty(animationStatue.Attribute);
            if (_pi != null)
            {
                double _progress = (double)animationStatue.CurrentFrames / (double)animationStatue.TotalFrames;
                int _newValue =
                    animationStatue.InitValue < animationStatue.EndValue ?
                    animationStatue.InitValue + Convert.ToInt32(Math.Round(animationStatue.TotalValue * CalculateValue(animationStatue.AnimationType, _progress))) :
                    animationStatue.InitValue - Convert.ToInt32(Math.Round(animationStatue.TotalValue * CalculateValue(animationStatue.AnimationType, _progress)));
                _pi.SetValue(contorl, _newValue, null);
            }
            else
            {
                timer.Enabled = false;
                return;
            }
            animationStatue.CurrentFrames++;
        }

        public static void HorizontalMove(System.Windows.Forms.Control control, int endLeft, int lastTime, AnimationType animationType)
        {
            System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 15; // CAUSION, this value may not work for you
            int _frames = lastTime % _timer.Interval > 0 ? lastTime / _timer.Interval + 1 : lastTime / _timer.Interval;
            AnimationStatus animationStatue = new AnimationStatus("Left", control.Left, endLeft, _frames, animationType);
            _timer.Tick += delegate { Animate(control, _timer, animationStatue); };
            _timer.Enabled = true;
            _timer.Start();
        }
    }
}