namespace RolesManager.Entity
{
    public class ComboBoxObject<T>
    {
        public bool IsSelected { get; set; }
        public T ObjectData { get; set; }

        public ComboBoxObject(T objectData)
        {
            ObjectData = objectData;
        }

        public ComboBoxObject(T objectData, bool isSelected)
        {
            IsSelected = isSelected;
            ObjectData = objectData;
        }
    }
}