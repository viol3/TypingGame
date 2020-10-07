using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ali.Helper
{
    [ExecuteInEditMode]
    public class GradientRawImage : MonoBehaviour
    {
        [SerializeField] private Color _topColor;
        [SerializeField] private Color _bottomColor;

        private Texture2D backgroundTexture;
        private RawImage _image;

        private void OnValidate()
        {
            _image = GetComponent<RawImage>();
            backgroundTexture = new Texture2D(1, 2);
            backgroundTexture.wrapMode = TextureWrapMode.Clamp;
            backgroundTexture.filterMode = FilterMode.Bilinear;
            SetColor(_bottomColor, _topColor);
        }

        public void SetColor(Color color1, Color color2)
        {
            backgroundTexture.SetPixels(new Color[] { color1, color2 });
            backgroundTexture.Apply();
            _image.texture = backgroundTexture;
        }
    }
}