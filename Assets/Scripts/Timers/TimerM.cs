
namespace Assets.Scripts.Timers
{
    public class TimerM
    {
        public bool IsFinished => currentTime <= 0;

        private float currentTime;

        public TimerM(float startTime)
        {
            Start(startTime);
        }

        public void Start(float startTime)
        {
            currentTime = startTime;
        }

        public void RemoveTime(float deltaTime)
        {
            if (currentTime <= 0) return;

            currentTime -= deltaTime;
        }
    }
}
