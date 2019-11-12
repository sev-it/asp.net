using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Dapper;

namespace RolesManager.DBManager
{
    public static class DbManager
    {
        #region Строки подключения

        private static IDbConnection CrmPayTestConnection => new SqlConnection("Data Source=192.168.0.120;Initial Catalog=CrmPay;Persist Security Info=True;User ID=aspnetengine; Password=multipaspf0rb@se;TimeOut=160");
        private static IDbConnection CrmPayWorkConnection => new SqlConnection("Data Source=91.105.201.31,17333;Initial Catalog=CrmPay;Persist Security Info=True;User ID=aspnet_test; Password=n3NRfY38bz5dqEnjUkZBx2ExF08fF2;TimeOut=300");
        private static IDbConnection UsmpTestConnection => new SqlConnection("Data Source=192.168.0.112;Initial Catalog=USMPAY;Persist Security Info=True;User ID=sa; Password=Prestige@09;TimeOut=160");
        private static IDbConnection UsmpWorkConnection => new SqlConnection("Data Source=91.105.201.31,14333;Initial Catalog=USMPAY;Persist Security Info=True;User ID=aspnetengine; Password=wRi0n2U41QlK0l5p073fLYOCqtX0qn;TimeOut=3200");
        
        #endregion

        #region Запросы

        private const string IsRoleExist = @"SELECT
                                                  COUNT(*)
                                             FROM
                                                  IdentityRoles
                                             WHERE
                                                  Name = @Name";
        private const string InsertRoleCommand = @"INSERT
                                                    INTO
                                                         IdentityRoles
                                                    VALUES (
                                                               @Name,
                                                               @Description,
                                                               @IsUsed
                                                           );
                                                    SELECT
                                                         CAST(SCOPE_IDENTITY() AS int)";
        private const string GetRoleIdByName = @"SELECT
                                                      Id
                                                 FROM
                                                      IdentityRoles
                                                 WHERE
                                                      Name = @Name";

        private const string GetGroupsByRoleId = @"SELECT
                                                        GroupId
                                                   FROM
                                                        IdentityRolesInGroups
                                                   WHERE
                                                        RoleId = @RoleId";

        #endregion

        public static List<KeyValuePair<int, string>> SelectIdentityGroups()
        {
            using (var crmTestConnection = CrmPayTestConnection)
            {
                try
                {
                    crmTestConnection.Open();
                    var result = crmTestConnection.QueryMultiple(@"SELECT
                                                                        *
                                                                   FROM
                                                                        IdentityGroups
                                                                   WHERE
                                                                        Id NOT IN (1, 5, 6)
                                                                        AND Id <= 40")
                        .Read()
                        .Select(x => new KeyValuePair<int, string>((int)x.Id, (string)x.Name))
                        .ToList();
                    crmTestConnection.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new List<KeyValuePair<int, string>>();
                }
            }
        }

        public static List<KeyValuePair<int, string>> InsertRole(string name, string description, bool isUsed, List<int> groups, params KeyValuePair<string, bool>[] conList)
        {
            var result = new List<KeyValuePair<int, string>>();
            if (conList.Length == 0)
                return result;

            #region RU Test

            if (conList.Any(x => x.Key.Equals("RU_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayTest = CrmPayTestConnection)
                {
                    crmPayTest.Open();
                    if (!crmPayTest.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                    {
                        var r = InsertRoleAdapter(crmPayTest, name, description, isUsed, groups);
                        result.Add(new KeyValuePair<int, string>(r.Key, $"RU Test: {r.Value}"));
                    }
                    else
                        result.Add(new KeyValuePair<int, string>(0, "RU Test: Роль уже существует"));
                }

            #endregion

            #region RU Work

            if (conList.Any(x => x.Key.Equals("RU_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayWork = CrmPayWorkConnection)
                {
                    crmPayWork.Open();
                    if (!crmPayWork.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                    {
                        var r = InsertRoleAdapter(crmPayWork, name, description, isUsed, groups);
                        result.Add(new KeyValuePair<int, string>(r.Key, $"RU Work: {r.Value}"));
                    }
                    else
                        result.Add(new KeyValuePair<int, string>(0, "RU Work: Роль уже существует"));
                }

            #endregion

            #region UA Test

            if (conList.Any(x => x.Key.Equals("UA_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var usmpTest = UsmpTestConnection)
                {
                    usmpTest.Open();
                    if (!usmpTest.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                    {
                        var r = InsertRoleAdapter(usmpTest, name, description, isUsed, groups);
                        result.Add(new KeyValuePair<int, string>(r.Key, $"UA Test: {r.Value}"));
                    }
                    else
                        result.Add(new KeyValuePair<int, string>(0, "UA Test: Роль уже существует"));
                }

            #endregion

            #region UA Work

            if (!conList.Any(x => x.Key.Equals("UA_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                return result;

            using (var usmpWork = UsmpWorkConnection)
            {
                usmpWork.Open();
                if (!usmpWork.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                {
                    var r = InsertRoleAdapter(usmpWork, name, description, isUsed, groups);
                    result.Add(new KeyValuePair<int, string>(r.Key, $"UA Work: {r.Value}"));
                }
                else
                    result.Add(new KeyValuePair<int, string>(0, "UA Work: Роль уже существует"));
            }

            #endregion

            return result;
        }

        public static List<KeyValuePair<int, string>> InsertRoleFromBase(string name, string description, bool isUsed, string baseRole, params KeyValuePair<string, bool>[] conList)
        {
            List<int> groups;
            var result = new List<KeyValuePair<int, string>>();
            KeyValuePair<int, string> currentResult;
            if (conList.Length == 0)
                return result;

            #region RU Test

            if (conList.Any(x => x.Key.Equals("RU_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayTest = CrmPayTestConnection)
                {
                    crmPayTest.Open();
                    var baseRoleId = crmPayTest.ExecuteScalar<int>(GetRoleIdByName, new {Name = baseRole});
                    if (baseRoleId == 0)
                        result.Add(new KeyValuePair<int, string>(0, $"RU Test: Базовая роль с именем '{baseRole}' не найдена! Роль не создана!"));
                    else
                    {
                        groups = crmPayTest.Query<int>(GetGroupsByRoleId, new {RoleId = baseRoleId }).ToList();
                        currentResult = InsertRoleAdapter(crmPayTest, name, description, isUsed, groups);
                        result.Add(new KeyValuePair<int, string>(currentResult.Key, $"RU Test: {currentResult.Value}"));
                    }
                }

            #endregion

            #region RU Work

            if (conList.Any(x => x.Key.Equals("RU_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayWork = CrmPayWorkConnection)
                {
                    crmPayWork.Open();
                    var baseRoleId = crmPayWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = baseRole });
                    if (baseRoleId == 0)
                        result.Add(new KeyValuePair<int, string>(0, $"RU Work: Базовая роль с именем '{baseRole}' не найдена! Роль не создана!"));
                    else
                    {
                        groups = crmPayWork.Query<int>(GetGroupsByRoleId, new { RoleId = baseRoleId }).ToList();
                        currentResult = InsertRoleAdapter(crmPayWork, name, description, isUsed, groups);
                        result.Add(new KeyValuePair<int, string>(currentResult.Key, $"RU Work: {currentResult.Value}"));
                    }
                }

            #endregion

            #region UA Test

            if (conList.Any(x => x.Key.Equals("UA_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var usmpTest = UsmpTestConnection)
                {
                    usmpTest.Open();
                    var baseRoleId = usmpTest.ExecuteScalar<int>(GetRoleIdByName, new { Name = baseRole });
                    if (baseRoleId == 0)
                        result.Add(new KeyValuePair<int, string>(0, $"UA Test: Базовая роль с именем '{baseRole}' не найдена! Роль не создана!"));
                    else
                    {
                        groups = usmpTest.Query<int>(GetGroupsByRoleId, new { RoleId = baseRoleId }).ToList();
                        currentResult = InsertRoleAdapter(usmpTest, name, description, isUsed, groups);
                        result.Add(new KeyValuePair<int, string>(currentResult.Key, $"UA Test: {currentResult.Value}"));
                    }
                }

            #endregion

            #region UA Work

            if (!conList.Any(x => x.Key.Equals("UA_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                return result;

            using (var usmpWork = UsmpWorkConnection)
            {
                usmpWork.Open();
                var baseRoleId = usmpWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = baseRole });
                if (baseRoleId == 0)
                    result.Add(new KeyValuePair<int, string>(0, $"UA Work: Базовая роль с именем '{baseRole}' не найдена! Роль не создана!"));
                else
                {
                    groups = usmpWork.Query<int>(GetGroupsByRoleId, new { RoleId = baseRoleId }).ToList();
                    currentResult = InsertRoleAdapter(usmpWork, name, description, isUsed, groups);
                    result.Add(new KeyValuePair<int, string>(currentResult.Key, $"UA Work: {currentResult.Value}"));
                }
            }

            #endregion

            return result;
        }

        public static List<KeyValuePair<int, string>> InsertRoleInGroupsFromBase(string name, string baseRole, List<int> groups, params KeyValuePair<string, bool>[] conList)
        {
            List<int> rolesGroups;
            var result = new List<KeyValuePair<int, string>>();
            KeyValuePair<int, string> currentResult;
            if (conList.Length == 0)
                return result;

            #region RU Test

            if (conList.Any(x => x.Key.Equals("RU_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayTest = CrmPayTestConnection)
                {
                    crmPayTest.Open();
                    var baseRoleId = crmPayTest.ExecuteScalar<int>(GetRoleIdByName, new {Name = baseRole});
                    var insertingRoleId = crmPayTest.ExecuteScalar<int>(GetRoleIdByName, new {Name = name});
                    if (baseRoleId == 0 && !groups.Any())
                        result.Add(new KeyValuePair<int, string>(0, $"RU Test: Базовая роль с именем '{baseRole}' не найдена!"));
                    else
                        if (insertingRoleId == 0)
                            result.Add(new KeyValuePair<int, string>(0, $"RU Test: Роль для вставки с именем '{baseRole}' не найдена!"));
                    else
                    {
                        rolesGroups = groups.Any()
                            ? groups
                            : crmPayTest.Query<int>(GetGroupsByRoleId, new { RoleId = baseRoleId }).ToList();
                        currentResult = InsertFromBaseAdapter(crmPayTest, insertingRoleId, baseRoleId, rolesGroups);
                        result.Add(new KeyValuePair<int, string>(currentResult.Key, $"RU Test: {currentResult.Value}"));
                    }
                }

            #endregion

            #region RU Work

            if (conList.Any(x => x.Key.Equals("RU_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayWork = CrmPayWorkConnection)
                {
                    crmPayWork.Open();
                    var baseRoleId = crmPayWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = baseRole });
                    var insertingRoleId = crmPayWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = name });
                    if (baseRoleId == 0 && !groups.Any())
                        result.Add(new KeyValuePair<int, string>(0, $"RU Work: Базовая роль с именем '{baseRole}' не найдена!"));
                    else
                        if (insertingRoleId == 0)
                            result.Add(new KeyValuePair<int, string>(0, $"RU Work: Роль для вставки с именем '{baseRole}' не найдена!"));
                    else
                    {
                        rolesGroups = groups.Any()
                            ? groups
                            : crmPayWork.Query<int>(GetGroupsByRoleId, new { RoleId = baseRoleId }).ToList();
                        currentResult = InsertFromBaseAdapter(crmPayWork, insertingRoleId, baseRoleId, rolesGroups);
                        result.Add(new KeyValuePair<int, string>(currentResult.Key, $"RU Work: {currentResult.Value}"));
                    }
                }

            #endregion

            #region UA Test

            if (conList.Any(x => x.Key.Equals("UA_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var usmpTest = UsmpTestConnection)
                {
                    usmpTest.Open();
                    var baseRoleId = usmpTest.ExecuteScalar<int>(GetRoleIdByName, new { Name = baseRole });
                    var insertingRoleId = usmpTest.ExecuteScalar<int>(GetRoleIdByName, new { Name = name });
                    if (baseRoleId == 0 && !groups.Any())
                        result.Add(new KeyValuePair<int, string>(0, $"UA Test: Базовая роль с именем '{baseRole}' не найдена!"));
                    else
                        if (insertingRoleId == 0)
                            result.Add(new KeyValuePair<int, string>(0, $"UA Test: Роль для вставки с именем '{baseRole}' не найдена!"));
                    else
                    {
                        rolesGroups = groups.Any()
                            ? groups
                            : usmpTest.Query<int>(GetGroupsByRoleId, new { RoleId = baseRoleId }).ToList();
                        currentResult = InsertFromBaseAdapter(usmpTest, insertingRoleId, baseRoleId, rolesGroups);
                        result.Add(new KeyValuePair<int, string>(currentResult.Key, $"UA Test: {currentResult.Value}"));
                    }
                }

            #endregion

            #region UA Work

            if (!conList.Any(x => x.Key.Equals("UA_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                return result;
            using (var usmpWork = UsmpWorkConnection)
            {
                usmpWork.Open();
                var baseRoleId = usmpWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = baseRole });
                var insertingRoleId = usmpWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = name });
                if (baseRoleId == 0 && !groups.Any())
                    result.Add(new KeyValuePair<int, string>(0, $"UA Work: Базовая роль с именем '{baseRole}' не найдена!"));
                else
                    if (insertingRoleId == 0)
                        result.Add(new KeyValuePair<int, string>(0, $"UA Work: Роль для вставки с именем '{baseRole}' не найдена!"));
                else
                {
                    rolesGroups = groups.Any()
                            ? groups
                            : usmpWork.Query<int>(GetGroupsByRoleId, new { RoleId = baseRoleId }).ToList();
                    currentResult = InsertFromBaseAdapter(usmpWork, insertingRoleId, baseRoleId, rolesGroups);
                    result.Add(new KeyValuePair<int, string>(currentResult.Key, $"UA Work: {currentResult.Value}"));
                }
            }

            #endregion

            return result;
        }

        public static List<KeyValuePair<int, string>> DeleteRole(string name, List<int> groups, bool mustDeleteRole, params KeyValuePair<string, bool>[] conList)
        {
            var result = new List<KeyValuePair<int, string>>();
            if (conList.Length == 0)
                return result;

            #region RU Test

            if (conList.Any(x => x.Key.Equals("RU_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayTest = CrmPayTestConnection)
                {
                    crmPayTest.Open();
                    if (crmPayTest.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                    {
                        var roleId = crmPayTest.ExecuteScalar<int>(GetRoleIdByName, new { Name = name });
                        var r = DeleteRoleAdapter(crmPayTest, roleId, groups, mustDeleteRole);
                        result.Add(new KeyValuePair<int, string>(r.Key, $"RU Test: {r.Value}"));
                    }
                    else
                        result.Add(new KeyValuePair<int, string>(0, "RU Test: Роль не существует"));
                }

            #endregion

            #region RU Work

            if (conList.Any(x => x.Key.Equals("RU_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var crmPayWork = CrmPayWorkConnection)
                {
                    crmPayWork.Open();
                    if (crmPayWork.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                    {
                        var roleId = crmPayWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = name });
                        var r = DeleteRoleAdapter(crmPayWork, roleId, groups, mustDeleteRole);
                        result.Add(new KeyValuePair<int, string>(r.Key, $"RU Work: {r.Value}"));
                    }
                    else
                        result.Add(new KeyValuePair<int, string>(0, "RU Work: Роль не существует"));
                }

            #endregion

            #region UA Test

            if (conList.Any(x => x.Key.Equals("UA_TEST", StringComparison.OrdinalIgnoreCase) && x.Value))
                using (var usmpTest = UsmpTestConnection)
                {
                    usmpTest.Open();
                    if (usmpTest.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                    {
                        var roleId = usmpTest.ExecuteScalar<int>(GetRoleIdByName, new { Name = name });
                        var r = DeleteRoleAdapter(usmpTest, roleId, groups, mustDeleteRole);
                        result.Add(new KeyValuePair<int, string>(r.Key, $"UA Test: {r.Value}"));
                    }
                    else
                        result.Add(new KeyValuePair<int, string>(0, "UA Test: Роль не существует"));
                }

            #endregion

            #region UA Work

            if (!conList.Any(x => x.Key.Equals("UA_WORK", StringComparison.OrdinalIgnoreCase) && x.Value))
                return result;

            using (var usmpWork = UsmpWorkConnection)
            {
                usmpWork.Open();
                if (usmpWork.Query<bool>(IsRoleExist, new { Name = name }).FirstOrDefault())
                {
                    var roleId = usmpWork.ExecuteScalar<int>(GetRoleIdByName, new { Name = name });
                    var r = DeleteRoleAdapter(usmpWork, roleId, groups, mustDeleteRole);
                    result.Add(new KeyValuePair<int, string>(r.Key, $"UA Work: {r.Value}"));
                }
                else
                    result.Add(new KeyValuePair<int, string>(0, "UA Work: Роль не существует"));
            }

            #endregion

            return result;
        }

        private static KeyValuePair<int, string> InsertRoleAdapter(IDbConnection connection, string name, string description, bool isUsed, List<int> groups)
        {
            try
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var roleId = 0;
                    try
                    {
                        roleId = connection.Query<int>(InsertRoleCommand,
                                                       transaction: transaction,
                                                       param: new
                                                       {
                                                           Name = name,
                                                           Description = description,
                                                           IsUsed = isUsed
                                                       }).Single();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        connection.Close();
                        var msg = $@"{(connection.ConnectionString.Contains("192.168.0.118")
                            ? "Ошибка при добавлении роли в RU Test БД"
                            : connection.ConnectionString.Contains("192.168.0.112")
                                ? "Ошибка при добавлении роли в UA Test БД"
                                : connection.ConnectionString.Contains("91.105.201.31,17333")
                                    ? "Ошибка при добавлении роли в RU Work БД"
                                    : connection.ConnectionString.Contains("91.105.201.31,14333")
                                        ? "Ошибка при добавлении роли в UA Work БД"
                                        : "")}" + $" Message: {ex.Message}";
                        return new KeyValuePair<int, string>(roleId, msg);
                    }

                    if (groups != null && groups.Count != 0 && roleId != 0)
                    {
                        try
                        {
                            connection.Execute($@"INSERT
                                                  INTO
                                                       IdentityRolesInGroups
                                                  SELECT
                                                       Id,
                                                       @RoleId
                                                  FROM
                                                       IdentityGroups
                                                  WHERE
                                                       Id IN ({(groups.Count > 0 ? string.Join(",", Array.ConvertAll(groups.ToArray(), x => x.ToString())) : "-1")})",
                                               transaction: transaction,
                                               param: new { RoleId = roleId });
                            transaction.Commit();
                            connection.Close();
                            return new KeyValuePair<int, string>(roleId, $"Успешно! Количество обработанных групп: {groups.Count}");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            connection.Close();
                            var msg = $@"{(connection.ConnectionString.Contains("192.168.0.118")
                                ? "Ошибка при добавлении роли в группу в RU Test БД"
                                : connection.ConnectionString.Contains("192.168.0.112")
                                    ? "Ошибка при добавлении роли в группу в UA Test БД"
                                    : connection.ConnectionString.Contains("91.105.201.31,17333")
                                        ? "Ошибка при добавлении роли в группу в RU Work БД"
                                        : connection.ConnectionString.Contains("91.105.201.31,14333")
                                            ? "Ошибка при добавлении роли в группу в UA Work БД"
                                            : "")}" + $" Message: {ex.Message}";
                            return new KeyValuePair<int, string>(roleId, msg);
                        }
                    }
                    transaction.Commit();
                    connection.Close();
                    return new KeyValuePair<int, string>(roleId, "Успешно");
                }
            }
            catch (Exception ex)
            {
                var msg = $@"{(connection.ConnectionString.Contains("192.168.0.118")
                            ? "Ошибка при добавлении роли в RU Test БД"
                            : connection.ConnectionString.Contains("192.168.0.112")
                                ? "Ошибка при добавлении роли в UA Test БД"
                                : connection.ConnectionString.Contains("91.105.201.31,17333")
                                    ? "Ошибка при добавлении роли в RU Work БД"
                                    : connection.ConnectionString.Contains("91.105.201.31,14333")
                                        ? "Ошибка при добавлении роли в UA Work БД"
                                        : "")}" + $" Message: {ex.Message}";
                return new KeyValuePair<int, string>(0, msg);
            }
        }

        private static KeyValuePair<int, string> InsertFromBaseAdapter(IDbConnection connection, int insertingRoleId, int baseRoleId, List<int> groups)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    connection.Execute($@"INSERT
                                          INTO
                                               IdentityRolesInGroups
                                          SELECT
                                               Id,
                                               @RoleId
                                          FROM
                                               IdentityGroups
                                          WHERE
                                               Id IN ({(groups?.Count > 0 ? string.Join(",", Array.ConvertAll(groups.ToArray(), x => x.ToString())) : "-1")})",
                                       transaction: transaction,
                                       param: new { RoleId = insertingRoleId });
                    transaction.Commit();
                    connection.Close();
                    return new KeyValuePair<int, string>(insertingRoleId, $"Успешно! Количество обработанных групп: {groups?.Count}. {(baseRoleId != 0 ? $"Id базовой роли: {baseRoleId}" : "")}");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                    var msg = $@"{(connection.ConnectionString.Contains("192.168.0.118")
                        ? "Ошибка при добавлении роли в группу в RU Test БД"
                        : connection.ConnectionString.Contains("192.168.0.112")
                            ? "Ошибка при добавлении роли в группу в UA Test БД"
                            : connection.ConnectionString.Contains("91.105.201.31,17333")
                                ? "Ошибка при добавлении роли в группу в RU Work БД"
                                : connection.ConnectionString.Contains("91.105.201.31,14333")
                                    ? "Ошибка при добавлении роли в группу в UA Work БД"
                                    : "")}" + $" Message: {ex.Message}";
                    return new KeyValuePair<int, string>(insertingRoleId, msg);
                }
            }
        }

        private static KeyValuePair<int, string> DeleteRoleAdapter(IDbConnection connection, int roleId, List<int> groups, bool mustDeleteRole)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    if (groups.Any())
                    {
                        connection.Execute($@"DELETE
                                              FROM
                                                   IdentityRolesInGroups
                                              WHERE
                                                   RoleId = @RoleId
                                                   AND GroupId IN ({string.Join(",", Array.ConvertAll(groups.ToArray(), x => x.ToString()))})",
                                           new { RoleId = roleId },
                                           transaction);
                        transaction.Commit();
                        connection.Close();
                        return new KeyValuePair<int, string>(roleId, $"Успешно! Количество обработанных групп: {groups.Count}");
                    }
                    connection.Execute(@"DELETE
                                         FROM
                                              IdentityRolesInGroups
                                         WHERE
                                              RoleId = @RoleId", new {RoleId = roleId}, transaction);
                    if (!mustDeleteRole)
                    {
                        transaction.Commit();
                        connection.Close();
                        return new KeyValuePair<int, string>(roleId, $"Успешно! Количество обработанных групп: {groups.Count}");
                    }
                    connection.Execute(@"DELETE
                                         FROM
                                              IdentityRoles
                                         WHERE
                                              Id = @RoleId", new { RoleId = roleId }, transaction);
                    transaction.Commit();
                    connection.Close();
                    return new KeyValuePair<int, string>(roleId, $"Роль успешно удалена! Количество обработанных групп: {groups.Count}");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                    var msg = $@"{(connection.ConnectionString.Contains("192.168.0.118")
                        ? $"Ошибка при удалении роли {(mustDeleteRole ? "" : "из групп")} в RU Test БД"
                        : connection.ConnectionString.Contains("192.168.0.112")
                            ? $"Ошибка при удалении роли {(mustDeleteRole ? "" : "из групп")} в UA Test БД"
                            : connection.ConnectionString.Contains("91.105.201.31,17333")
                                ? $"Ошибка при удалении роли {(mustDeleteRole ? "" : "из групп")} в RU Work БД"
                                : connection.ConnectionString.Contains("91.105.201.31,14333")
                                    ? $"Ошибка при удалении роли {(mustDeleteRole ? "" : "из групп")} в UA Work БД"
                                    : "")}" + $" Message: {ex.Message}";
                    return new KeyValuePair<int, string>(roleId, msg);
                }
            }
        }
    }
}