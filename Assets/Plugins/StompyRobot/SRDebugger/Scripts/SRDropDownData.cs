using System;

namespace SRDebugger
{
    public class SRDropDownData
    {
        public event Action<int> SelectionChanged;
        public readonly object[] Options;
        private int _selectionIndex;

        public int SelectionIndex
        {
            get => _selectionIndex;
            set
            {
                if (_selectionIndex == value)
                {
                    return;
                }

                _selectionIndex = value;
                SelectionChanged?.Invoke(_selectionIndex);
            }
        }

        public void SetValueWithoutNotify(int value)
        {
            _selectionIndex = value;
        }

        public SRDropDownData(int selectionIndex, object[] options)
        {
            _selectionIndex = selectionIndex;
            Options = options;
        }
    }
}
