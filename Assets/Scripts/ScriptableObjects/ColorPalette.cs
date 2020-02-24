using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Color Palette Asset", menuName = "Custom/List/Color Palette", order = 0)]
    public class ColorPalette : ScriptableObject
    {
        public List<Color> colors;
    }
}
