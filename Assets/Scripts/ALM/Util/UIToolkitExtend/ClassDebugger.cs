using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    public class ClassDebugger : MonoBehaviour
    {
        VisualElement _root;

        [SerializeField]
        string _elementName;
        [SerializeField]
        string _className;

        void OnEnable()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
        }

        void Update()
        {
            var element = _root.Q(_elementName);
            if (element is null)
                return;

            if (Input.GetKeyDown(KeyCode.A))
            {
                element.AddToClassList(_className);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                element.RemoveFromClassList(_className);
            }
        }
    }

}
