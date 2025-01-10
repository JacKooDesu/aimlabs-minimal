using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend.Elements
{
    [UxmlElement]
    public partial class FileInputElement : BaseField<FileIO._File>
    {
        const string BROWSE_BTN = "BrowseBtn";
        const string FILE_NAME_FIELD = "FileName";

        Button _button;
        Button _fileNameField;
        public event Action<ClickEvent> OnClickBrowseBtn;
        public Func<string, FileIO._File> FileProcessor;
        // public Func<string, string> PathProcessor;
        public string DefaultRootPath { get; set; }

        public override FileIO._File value
        {
            get => base.value;
            set
            {
                base.value = value;
                _fileNameField.text = value.path;
            }
        }

        public FileInputElement() : base("File", Container()) => new FileInputElement("File");
        public FileInputElement(string label) : base(label, Container())
        {
            _button = this.Q<Button>(BROWSE_BTN);
            _fileNameField = this.Q<Button>(FILE_NAME_FIELD);

            _button.RegisterCallback<ClickEvent>(_ => OpenFileBrowser());
            _button.RegisterCallback<ClickEvent>(e => OnClickBrowseBtn?.Invoke(e));
        }

        static VisualElement Container()
        {
            var container = new VisualElement();
            container.style.flexDirection = FlexDirection.Row;

            var fileNameField = new Button();
            fileNameField.name = FILE_NAME_FIELD;
            fileNameField.pickingMode = PickingMode.Ignore;
            fileNameField.AddToClassList("unity-base-field__input");
            container.Add(fileNameField);

            var btn = new Button();
            btn.name = BROWSE_BTN;
            btn.text = "...";
            container.Add(btn);

            return container;
        }

        void OpenFileBrowser()
        {
            SFB.StandaloneFileBrowser.OpenFilePanelAsync(
                label,
                DefaultRootPath,
                value.extension.ParseExtension(),
                false,
                OnSelectFile);
        }

        void OnSelectFile(string[] paths)
        {
            if (paths.Length is 0 or > 1)
                return;

            var path = paths[0];
            if (FileProcessor is not null)
                value = FileProcessor(path);
            else
                value.path = path;
        }

        public class Bindable : DataBinder.Bindable
        {
            public override T ElementBuilder<T>() =>
                new FileInputElement(Label) as T;
            public override void Bind(VisualElement ui, object obj) =>
                CommonBind<FileInputElement, FileIO._File>(ui, obj);
        }
    }
}
