using System.Collections.Generic;
using UnityEngine;
using System;
using SRF;
using UnityEngine.UI;

namespace SRDebugger.UI.Controls.Data
{
    public class DropDownControl : DataBoundControl
    {
        [RequiredField] public Text Title;
        [RequiredField] public Dropdown Dropdown;
        private SRDropDownData _dropdownData;

        protected override void Start()
        {
            base.Start();
            Dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        protected override void OnDestroy()
        {
            Dropdown.onValueChanged.RemoveAllListeners();
            base.OnDestroy();
        }

        private void OnValueChanged(int index)
        {
            _dropdownData.SelectionIndex = index;
        }

        protected override void OnBind(string propertyName, Type t)
        {
            base.OnBind(propertyName, t);
            Title.text = propertyName;
        }

        protected override void OnValueUpdated(object newValue)
        {
            _dropdownData = newValue as SRDropDownData;
            if(_dropdownData == null)
            {
                Dropdown.ClearOptions();
                return;
            }
            List<string> options = new List<string>();
            foreach(var valueOption in _dropdownData.Options)
            {
                options.Add(valueOption.ToString());
            }
            Dropdown.AddOptions(options);
            Dropdown.SetValueWithoutNotify(_dropdownData.SelectionIndex);
        }

        public override bool CanBind(Type type, bool isReadOnly)
        {
            return type == typeof (SRDropDownData);
        }
    }
}
