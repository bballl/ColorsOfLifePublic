using UnityEngine;
using Assets.Scripts.Mafias;
using Assets.Scripts.Paths;

namespace Assets.Scripts.Spawner
{
    public class MafiaSpawner : Spawner
    {
        [SerializeField] private Mafia[] mafiaPrefabs;
        [SerializeField] private Path[] paths;
        [SerializeField] private MafiaProperties mafiaProperties;

        protected override GameObject GenerateSpawnedEntity()
        {
            var e = Instantiate(mafiaPrefabs[Random.Range(0, mafiaPrefabs.Length)]);
            e.SetProperties(mafiaProperties);
            e.GetComponent<AIController>().SetProperties(mafiaProperties);

            var path = paths[Random.Range(0, paths.Length)];

            startArea = path.StartArea;

            e.GetComponent<AIController>().SetPath(path);

            return e.gameObject;
        }
    }
}
