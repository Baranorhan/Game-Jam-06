using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class RadioButton : MonoBehaviour
    {
        public Image selectedImage;
        public int index;
        
        private void OnEnable()
        {
            if (PlayerPrefs.GetInt("ColorIndex") == index)
            {
                selectedImage.enabled = true;
                return;
            }
            selectedImage.enabled = false;
            
        }

        public void Select()
        {
            selectedImage.enabled = true;
            PlayerPrefs.SetInt("ColorIndex", index);
        }
        public void Deselect()
        {
            selectedImage.enabled = false;
        }
    }
}
