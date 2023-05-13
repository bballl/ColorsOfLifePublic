using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    internal class LoadData
    {
        public int GetIntData(string name)
        {
            if (PlayerPrefs.HasKey(name))
                return PlayerPrefs.GetInt(name);
            else
                return default(int);
        }

        public float GetFloatData(string name, float defaultValue = 0)
        {
            return PlayerPrefs.GetFloat(name, defaultValue);
        }

        public string GetStringData(string name)
        {
            return PlayerPrefs.GetString(name);
        }
    }
}
