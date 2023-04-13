using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyBatisNet.DAL
{
    public static class BaseDA
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("BaseDA");

        private static ISqlMapper iSqlMapper = Mapper.Instance();

        #region 查询

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="primaryKeyId"></param>
        /// <returns></returns>
        public static T Query<T,V>(string statementName, V primaryKeyId) where T : class
        {
            T t = null;
            try
            {
                if (iSqlMapper != null)
                {
                    t = iSqlMapper.QueryForObject<T>(statementName, primaryKeyId);
                    Debug.WriteLine(statementName + " 方法查询单条记录成功！");
                    log.Info(statementName + " 方法查询单条记录成功！");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(statementName + " 方法查询单条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法查询单条记录失败！原因：" + ex.Message);
            }
            return t;
        }


        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <typeparam name="V">查询字段数据类型</typeparam>
        /// <param name="statementName"></param>
        /// <param name="primaryKeyId"></param>
        /// <returns></returns>
        public static IList<T> QueryWhere<T,V>(string statementName, V primaryKeyId)
        {
            IList<T> lisT = null;
            try
            {
                if (iSqlMapper != null)
                {
                    lisT = iSqlMapper.QueryForList<T>(statementName, primaryKeyId);
                    Debug.WriteLine(statementName + " 方法查询多条记录成功！");
                    log.Info(statementName + " 方法查询多条记录成功！");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(statementName + " 方法查询多条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法查询多条记录失败！原因：" + ex.Message);
            }
            return lisT;
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public static IList<T> QueryForList<T>(string statementName, object parameterObject = null)
        {
            IList<T> lisT = null;
            try
            {
                if (iSqlMapper != null)
                {
                    lisT = iSqlMapper.QueryForList<T>(statementName, parameterObject);
                    Debug.WriteLine(statementName + " 方法查询所有记录成功！");
                    log.Info(statementName + " 方法查询所有记录成功！");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(statementName + " 方法查询所有记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法查询所有记录失败！原因：" + ex.Message);
            }
            return lisT;
        }

        #endregion

        #region 新增

        /// <summary>
        /// 插入单条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Insert<T>(string statementName, T t)
        {
            bool isCheck = false;
            try
            {
                if (iSqlMapper != null)
                {
                    iSqlMapper.BeginTransaction();
                    iSqlMapper.Insert(statementName, t);
                    iSqlMapper.CommitTransaction();
                    isCheck = true;
                    Debug.WriteLine(statementName + " 方法录入单条记录成功！");
                    log.Info(statementName + " 方法录入单条记录成功！");
                }
            }
            catch (Exception ex)
            {
                if (iSqlMapper != null)  iSqlMapper.RollBackTransaction();
                Debug.WriteLine(statementName + " 方法录入单条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法录入单条记录失败！原因：" + ex.Message);
            }
            return isCheck;
        }

        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="lisT"></param>
        /// <returns></returns>
        public static bool InsertForList<T>(string statementName, IList<T> lisT)
        {
            bool isCheck = false;
            try
            {
                if (iSqlMapper != null)
                {
                    if (lisT.Any())
                    {
                        iSqlMapper.BeginTransaction();
                        foreach (var t in lisT)
                        {
                            iSqlMapper.Insert(statementName, t);
                        }
                        iSqlMapper.CommitTransaction();
                        isCheck = true;
                        Debug.WriteLine(statementName + " 方法录入多条记录成功！");
                        log.Info(statementName + " 方法录入多条记录成功！");
                    }
                }
            }
            catch (Exception ex)
            {
                if (iSqlMapper != null) iSqlMapper.RollBackTransaction();
                Debug.WriteLine(statementName + " 方法录入多条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法录入多条记录失败！原因：" + ex.Message);
            }
            return isCheck;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 更新单条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int Update<T>(string statementName, T t)
        {
            int i = 0;
            try
            {
                if (iSqlMapper != null)
                {
                    iSqlMapper.BeginTransaction();
                    i = iSqlMapper.Update(statementName, t);
                    iSqlMapper.CommitTransaction();
                    Debug.WriteLine(statementName + " 方法更新单条记录成功！受影响行数：" + i);
                    log.Info(statementName + " 方法更新单条记录成功！受影响行数：" + i);
                }
            }
            catch (Exception ex)
            {
                if (iSqlMapper != null) iSqlMapper.RollBackTransaction();
                Debug.WriteLine(statementName + " 方法更新单条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法更新单条记录失败！原因：" + ex.Message);
            }
           
            return i;
        }

        /// <summary>
        /// 更新多条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="lisT"></param>
        /// <returns></returns>
        public static int UpdateForList<T>(string statementName, IList<T> lisT)
        {
            int i = 0;
            try
            {
                if (iSqlMapper != null)
                {
                    if (lisT.Any())
                    {
                        iSqlMapper.BeginTransaction();
                        foreach (var t in lisT)
                        {
                            int j = iSqlMapper.Update(statementName, t);
                            i += j;
                        }
                        iSqlMapper.CommitTransaction();
                        Debug.WriteLine(statementName + " 方法更新多条记录成功！受影响行数：" + i);
                        log.Info(statementName + " 方法更新多条记录成功！受影响行数：" + i);
                    }
                }
            }
            catch (Exception ex)
            {
                if (iSqlMapper != null) iSqlMapper.RollBackTransaction();
                Debug.WriteLine(statementName + " 方法更新多条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法更新多条记录失败！原因：" + ex.Message);
            }
            return i;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T">主键数据类型</typeparam>
        /// <param name="statementName"></param>
        /// <param name="primaryKeyId"></param>
        /// <returns></returns>
        public static int Delete<T>(string statementName, T primaryKeyId)
        {
            int i = 0;
            try
            {
                if (iSqlMapper != null)
                {
                    iSqlMapper.BeginTransaction();
                    i = iSqlMapper.Delete(statementName, primaryKeyId);
                    iSqlMapper.CommitTransaction();
                    Debug.WriteLine(statementName + " 方法删除单条记录成功！受影响行数：" + i);
                    log.Info(statementName + " 方法删除单条记录成功！受影响行数：" + i);
                }
            }
            catch (Exception ex)
            {
                if (iSqlMapper != null) iSqlMapper.RollBackTransaction();
                Debug.WriteLine(statementName + " 方法删除单条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法删除单条记录失败！原因：" + ex.Message);
            }
            return i;
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <typeparam name="T">主键数据类型</typeparam>
        /// <param name="statementName"></param>
        /// <param name="primaryKeyIds"></param>
        /// <returns></returns>
        public static int DeleteForList<T>(string statementName, IList<T> primaryKeyIds)
        {
            int i = 0;
            try
            {
                if (iSqlMapper != null)
                {
                    if (primaryKeyIds.Any())
                    {
                        iSqlMapper.BeginTransaction();
                        i = iSqlMapper.Delete(statementName, primaryKeyIds);
                        iSqlMapper.CommitTransaction();
                        Debug.WriteLine(statementName + " 方法删除多条记录成功！受影响行数：" + i);
                        log.Info(statementName + " 方法删除多条记录成功！受影响行数：" + i);
                    }
                }
            }
            catch (Exception ex)
            {
                if (iSqlMapper != null) iSqlMapper.RollBackTransaction();
                Debug.WriteLine(statementName + " 方法删除多条记录失败！原因：" + ex.Message);
                log.Error(statementName + " 方法删除多条记录失败！原因：" + ex.Message);
            }
            return i;
        }

        #endregion
    }
}
