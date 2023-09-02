using UnityEngine;

namespace SoulEater.Data
{
    public static class PlayerPrefsData
    {
        public static int GetSoulsCount()
        {
            if (!PlayerPrefs.HasKey("Souls"))
            {
                return 0;
            }

            return PlayerPrefs.GetInt("Souls");
        }
    
        public static void SetSoulsCount(int soulsCount)
        {
            PlayerPrefs.SetInt("Souls", soulsCount);
        }
    }
}
