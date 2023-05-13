using UnityEngine;
using Assets.Scripts.Mafias;

namespace Assets.Scripts.Spawner
{
    public abstract class Spawner : MonoBehaviour
    {
        protected abstract GameObject GenerateSpawnedEntity();

        /// Режим работы спавнера: при старте или переодически.
        public enum SpawnMode
        {
            Start,
            Loop
        }

        /// Зона, в которой можно спавнить.
        [SerializeField] protected CircleArea startArea;
        /// Ссылка на SpawnMode
        [SerializeField] private SpawnMode spawnMode;
        /// Количество спавнов.
        [SerializeField] private int numSpawns;
        /// Частота обновления таймера.
        [SerializeField] private float respawnTime;

        private float timer;

        public CircleArea StartArea => startArea;

        private void Start()
        {
            SpawnEntity();
            timer = respawnTime;
        }

        private void Update()
        {
            CheckingTimer();
        }

        private void CheckingTimer()
        {
            if (timer > 0)
                timer -= Time.deltaTime;

            if (spawnMode == SpawnMode.Loop && timer < 0)
            {
                SpawnEntity();
                timer = respawnTime;
            }
        }

        private void SpawnEntity()
        {
            for (int i = 0; i < numSpawns; i++)
            {
                var mafia = GenerateSpawnedEntity();
                mafia.transform.position = startArea.GetRandomInsideZone();
            }
        }
    }
}

