using UnityCommon.UI;
using UnityEngine;

namespace Roro.UnityCommon.Scripts.Runtime.UI
{
    [RequireComponent(typeof(TextMesh))]
    public class TextMeshSetter : MonoBehaviour
    {
        [TextArea]
        [SerializeField] private string format = "";
        
        //private TEXTMESH]
        
        public void SetText(float val) => SetTextObject(val);
        public void SetText(int val) => SetTextObject(val);
        public void SetText(string val) => SetTextObject(val);
        public void SetText(bool val) => SetTextObject(val);

        private void SetTextObject(object val)
        {
            string value;
            if (format == "")
            {
                value = val.ToString();
            }
            else
            {
                value = string.Format(format, val);
            }

            //uiElement.text = value;


        }


    }
}
