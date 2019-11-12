using System.Collections.Generic;
using System.Collections.ObjectModel;
using RolesManager.Entity;
using RolesManager.DBManager;

namespace RolesManager.Model
{
    public class ViewModel
    {
        public ObservableCollection<ComboBoxObject<KeyValuePair<int, string>>> CmbContent { get; }
        public ObservableCollection<KeyValuePair<bool, string>> CbIsUsedContent { get; }

        public ViewModel()
        {
            #region Заполнение групп ролей

            CmbContent = new ObservableCollection<ComboBoxObject<KeyValuePair<int, string>>>();
            var identityGroups = DbManager.SelectIdentityGroups();
            if (identityGroups != null && identityGroups.Count != 0)
                foreach (var item in identityGroups)
                {
                    CmbContent.Add(new ComboBoxObject<KeyValuePair<int, string>>(new KeyValuePair<int, string>(item.Key, item.Value)));
                }

            #endregion

            #region Статусы активности

            CbIsUsedContent = new ObservableCollection<KeyValuePair<bool, string>>
            {
                new KeyValuePair<bool, string>(true, "Используется"),
                new KeyValuePair<bool, string>(false, "Не используется")
            };

            #endregion
        }
    }
}