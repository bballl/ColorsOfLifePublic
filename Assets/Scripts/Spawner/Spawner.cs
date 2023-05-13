using UnityEngine;
using Assets.Scripts.Mafias;

namespace Assets.Scripts.Spawner
{
    public abstract class Spawner : MonoBehaviour
    {
        protected abstract GameObject GenerateSpawnedEntity();

        /// ����� ������ ��������: ��� ������ ��� ������������.
        public enum SpawnMode
        {
            Start,
            Loop
        }

        /// ����, � ������� ����� ��������.
        [SerializeField] protected CircleArea startArea;
        /// ������ �� SpawnMode
        [SerializeField] private SpawnMode spawnMode;
        /// ���������� �������.
        [SerializeField] private int numSpawns;
        /// ������� ���������� �������.
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

