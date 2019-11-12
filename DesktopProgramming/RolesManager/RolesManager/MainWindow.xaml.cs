using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RolesManager.Entity;
using RolesManager.Model;
using RolesManager.DBManager;

namespace RolesManager
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            CbIsUsed.SelectedIndex = 0;
        }

        private void OnCbObjectsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            comboBox.SelectedItem = null;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            #region Обработка ошибок ввода

            if (TbRoleName.Text.Length == 0 || TbRoleName.Text.Any(c => !char.IsLetter(c)) || TbRoleName.Text.Length < 10)
            {
                MessageBox.Show("Имя роли некорректно!");
                return;
            }

            if (TbRoleDescription.Text.Length < 10 || TbRoleDescription.Text.Length == 0)
            {
                MessageBox.Show("Описание роли слишком короткое!");
                return;
            }

            if (CbCreateFromBase.IsChecked.GetValueOrDefault(false) && (TbBaseRole.Text.Length == 0 || TbBaseRole.Text.Any(c => !char.IsLetter(c))))
            {
                MessageBox.Show("Некорректно имя базовой роли");
                return;
            }

            #endregion

            var name = TbRoleName.Text;
            var description = TbRoleDescription.Text;
            var isUsed = ((KeyValuePair<bool, string>)CbIsUsed.SelectionBoxItem).Key;
            var conList = new[]
            {
                new KeyValuePair<string, bool>("RU_TEST", CbRuTest.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("RU_WORK", CbRuWork.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("UA_TEST", CbUaTest.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("UA_WORK", CbUaWork.IsChecked.GetValueOrDefault(false))
            };

            List<KeyValuePair<int, string>> result;

            if (CbCreateFromBase.IsChecked.GetValueOrDefault(false))
            {
                var baseRole = TbBaseRole.Text;
                result = DbManager.InsertRoleFromBase(name, description, isUsed, baseRole, conList);
                result.ForEach(x => TbLog.Text += $"RoleId: {x.Key} \n {x.Value}\n----------------------\n");
            }
            else
            {
                var listGroups = CbGroups.Items.Cast<ComboBoxObject<KeyValuePair<int, string>>>()
                                           .Where(cbObject => cbObject.IsSelected)
                                           .Select(cbObject => cbObject.ObjectData.Key).ToList();
                
                result = DbManager.InsertRole(name, description, isUsed, listGroups, conList);
                result.ForEach(x => TbLog.Text += $"RoleId: {x.Key} \n {x.Value}\n----------------------\n");
            }
            
            TbLog.Focus();
            TbLog.CaretIndex = TbLog.Text.Length;
            TbLog.ScrollToEnd();
        }

        private void ButtonInsert_OnClick(object sender, RoutedEventArgs e)
        {
            #region Обработка ошибок ввода

            if (TbInsertingRoleName.Text.Length == 0 || TbInsertingRoleName.Text.Any(c => !char.IsLetter(c)) || TbInsertingRoleName.Text.Length < 10)
            {
                MessageBox.Show("Имя роли некорректно!");
                return;
            }

            if (CmbAddingAction.SelectedIndex == 0 && TbBaseRoleForInsert.Text.Length == 0 || TbBaseRoleForInsert.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Некорректно имя базовой роли");
                return;
            }

            if (CmbAddingAction.SelectedIndex == 1 && CbGroupsForInsert.Items.Cast<ComboBoxObject<KeyValuePair<int, string>>>().All(x => !x.IsSelected))
            {
                MessageBox.Show("Не выбрано ни одной группы");
                return;
            }

            #endregion

            var name = TbInsertingRoleName.Text;
            var baseRole = TbBaseRoleForInsert.Text;
            var groups = CmbAddingAction.SelectedIndex == 1
                ? CbGroupsForInsert.Items
                                   .Cast<ComboBoxObject<KeyValuePair<int, string>>>()
                                   .Where(cbObject => cbObject.IsSelected)
                                   .Select(cbObject => cbObject.ObjectData.Key).ToList()
                : new List<int>();
            var conList = new[]
            {
                new KeyValuePair<string, bool>("RU_TEST", CbRuTestForInsert.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("RU_WORK", CbRuWorkForInsert.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("UA_TEST", CbUaTestForInsert.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("UA_WORK", CbUaWorkForInsert.IsChecked.GetValueOrDefault(false))
            };

            var result = DbManager.InsertRoleInGroupsFromBase(name, baseRole, groups, conList);
            result.ForEach(x => TbLogForInsert.Text += $"RoleId: {x.Key} \n {x.Value}\n----------------------\n");

            TbLogForInsert.Focus();
            TbLogForInsert.CaretIndex = TbLogForInsert.Text.Length;
            TbLogForInsert.ScrollToEnd();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            #region Обработка ошибок ввода

            if (TbDeletingRoleName.Text.Length == 0 || TbDeletingRoleName.Text.Any(c => !char.IsLetter(c)) || TbDeletingRoleName.Text.Length < 10)
            {
                MessageBox.Show("Имя роли некорректно!");
                return;
            }
            
            if (CmbAction.SelectedIndex == 1
                && CbGroupsFromDelete.Items.Cast<ComboBoxObject<KeyValuePair<int, string>>>().All(x => !x.IsSelected))
            {
                MessageBox.Show("Не выбрано ни одной группы");
                return;
            }

            #endregion

            var name = TbDeletingRoleName.Text;
            var groups = CmbAction.SelectedIndex == 1
                ? CbGroupsFromDelete.Items
                                    .Cast<ComboBoxObject<KeyValuePair<int, string>>>()
                                    .Where(cbObject => cbObject.IsSelected)
                                    .Select(cbObject => cbObject.ObjectData.Key).ToList()
                : new List<int>();
            var conList = new[]
            {
                new KeyValuePair<string, bool>("RU_TEST", CbRuTestForDelete.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("RU_WORK", CbRuWorkForDelete.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("UA_TEST", CbUaTestForDelete.IsChecked.GetValueOrDefault(false)),
                new KeyValuePair<string, bool>("UA_WORK", CbUaWorkForDelete.IsChecked.GetValueOrDefault(false))
            };
            var mustDeleteRole = CmbAction.SelectedIndex == 0;
            var result = DbManager.DeleteRole(name, groups, mustDeleteRole, conList);
            result.ForEach(x => TbLogForDelete.Text += $"RoleId: {x.Key} \n {x.Value}\n----------------------\n");

            TbLogForDelete.Focus();
            TbLogForDelete.CaretIndex = TbLogForDelete.Text.Length;
            TbLogForDelete.ScrollToEnd();
        }

        private void CbCreateFromBase_OnChecked(object sender, RoutedEventArgs e)
        {
            SpCreateFromBase.Visibility = Visibility.Visible;
            Application.Current.MainWindow.MaxHeight = Application.Current.MainWindow.Height += 70;
        }

        private void CbCreateFromBase_OnUnchecked(object sender, RoutedEventArgs e)
        {
            SpCreateFromBase.Visibility = Visibility.Collapsed;
            TbBaseRole.Text = string.Empty;
            Application.Current.MainWindow.MaxHeight = Application.Current.MainWindow.Height -= 70;
        }

        private void CmbAction_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbAction.SelectedIndex == 1)
            {
                if (SpDeleteFromCustomGroups == null) return;
                SpDeleteFromCustomGroups.Visibility = Visibility.Visible;
                Application.Current.MainWindow.MaxHeight = Application.Current.MainWindow.Height += 70;
            }
            else
            {
                if (SpDeleteFromCustomGroups == null) return;
                SpDeleteFromCustomGroups.Visibility = Visibility.Collapsed;
                Application.Current.MainWindow.MaxHeight = Application.Current.MainWindow.Height -= 70;
            }
        }

        private void CmbAddingAction_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbAddingAction.SelectedIndex == 0)
            {
                if (SpInsertFromBase == null)
                    return;
                SpInsertFromBase.Visibility = Visibility.Visible;
                if (SpInsertInCustomGroups == null)
                    return;
                SpInsertInCustomGroups.Visibility = Visibility.Collapsed;
                Application.Current.MainWindow.MaxHeight = Application.Current.MainWindow.Height += 70;
            }
            else
            {
                if (SpInsertFromBase == null)
                    return;
                SpInsertFromBase.Visibility = Visibility.Collapsed;
                if (SpInsertInCustomGroups == null)
                    return;
                SpInsertInCustomGroups.Visibility = Visibility.Visible;
                Application.Current.MainWindow.MaxHeight = Application.Current.MainWindow.Height -= 70;
            }
        }
    }
}