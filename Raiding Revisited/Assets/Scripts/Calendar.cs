using UnityEngine;

namespace Assets.Scripts
{
    public class Calendar : MonoBehaviour
    {
        public enum Month {March, April, May, June, July, August, September, October, November, December, January, February, Enduary }
        public enum Season {Spring, Summer, Autumn, Winter}

        public Season currentSeason;
    }
}