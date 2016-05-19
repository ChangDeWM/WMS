using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

namespace WMS.Common.Reids
{
    public class RedisCache
    {
        private static string RedisPath = System.Configuration.ConfigurationSettings.AppSettings["RedisConnection"];
        //默认缓存过期时间单位秒
        public static int secondsTimeOut = 30 * 60;

        #region -- 连接信息 --
        //10.0.18.8:6379
        public static PooledRedisClientManager prcm = CreateManager(new string[] { RedisPath }, new string[] { RedisPath });
        private static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            // 支持读写分离，均衡负载 
            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 5, // “写”链接池链接数 
                MaxReadPoolSize = 5, // “读”链接池链接数 
                AutoStart = true,
            });
        }
        #endregion

        #region -- Item --
        /// <summary>
        /// 设置单体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static bool Item_Set<T>(string key, T t)
        {
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    return redis.Set<T>(key, t, new TimeSpan(1, 0, 0));
                }
            }
            catch (Exception ex)
            {
                // LogInfo
            }
            return false;
        }

        /// <summary>
        /// 获取单体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Item_Get<T>(string key) where T : class
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.Get<T>(key);
            }
        }

        /// <summary>
        /// 移除单体
        /// </summary>
        /// <param name="key"></param>
        public static bool Item_Remove(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.Remove(key);
            }
        }

        #endregion

        #region -- List --

        public static void List_Add<T>(string key, T t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var redisTypedClient = redis.GetTypedClient<T>();
                redisTypedClient.AddItemToList(redisTypedClient.Lists[key], t);
            }
        }

        public static bool List_Remove<T>(string key, T t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var redisTypedClient = redis.GetTypedClient<T>();
                return redisTypedClient.RemoveItemFromList(redisTypedClient.Lists[key], t) > 0;
            }
        }
        public static void List_RemoveAll<T>(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var redisTypedClient = redis.GetTypedClient<T>();
                redisTypedClient.Lists[key].RemoveAll();
            }
        }

        public static int List_Count(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.GetListCount(key);
            }
        }

        public static List<T> List_GetRange<T>(string key, int start, int count)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var c = redis.GetTypedClient<T>();
                return c.Lists[key].GetRange(start, start + count - 1);
            }
        }

        public static List<T> List_GetList<T>(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var c = redis.GetTypedClient<T>();
                return c.Lists[key].GetRange(0, c.Lists[key].Count);
            }
        }

        public static List<T> List_GetList<T>(string key, int pageIndex, int pageSize)
        {
            int start = pageSize * (pageIndex - 1);
            return List_GetRange<T>(key, start, pageSize);
        }

        /// <summary>
        /// 设置缓存过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="datetime"></param>
        public static void List_SetExpire(string key, DateTime datetime)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                redis.ExpireEntryAt(key, datetime);
            }
        }
        #endregion

        #region -- Set --
        public static void Set_Add<T>(string key, T t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var redisTypedClient = redis.GetTypedClient<T>();
                redisTypedClient.Sets[key].Add(t);
            }
        }
        public static bool Set_Contains<T>(string key, T t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var redisTypedClient = redis.GetTypedClient<T>();
                return redisTypedClient.Sets[key].Contains(t);
            }
        }
        public static bool Set_Remove<T>(string key, T t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var redisTypedClient = redis.GetTypedClient<T>();
                return redisTypedClient.Sets[key].Remove(t);
            }
        }
        #endregion

        #region -- Hash --
        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public static bool Hash_Exist<T>(string key, string dataKey)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.HashContainsEntry(key, dataKey);
            }
        }

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public static bool Hash_Set<T>(string key, string dataKey, T t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return redis.SetEntryInHash(key, dataKey, value);
            }
        }
        /// <summary>
        /// 移除hash中的某值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public static bool Hash_Remove(string key, string dataKey)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.RemoveEntryFromHash(key, dataKey);
            }
        }
        /// <summary>
        /// 移除整个hash
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public static bool Hash_Remove(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.Remove(key);
            }
        }
        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public static T Hash_Get<T>(string key, string dataKey)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                string value = redis.GetValueFromHash(key, dataKey);
                return ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(value);
            }
        }
        /// <summary>
        /// 获取整个hash的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<T> Hash_GetAll<T>(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var list = redis.GetHashValues(key);
                if (list != null && list.Count > 0)
                {
                    List<T> result = new List<T>();
                    foreach (var item in list)
                    {
                        var value = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                        result.Add(value);
                    }
                    return result;
                }
                return null;
            }
        }
        /// <summary>
        /// 设置缓存过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="datetime"></param>
        public static void Hash_SetExpire(string key, DateTime datetime)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                redis.ExpireEntryAt(key, datetime);
            }
        }
        #endregion

        #region -- SortedSet --
        /// <summary>
        ///  添加数据到 SortedSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="score"></param>
        public static bool SortedSet_Add<T>(string key, T t, double score)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return redis.AddItemToSortedSet(key, value, score);
            }
        }
        /// <summary>
        /// 移除数据从SortedSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool SortedSet_Remove<T>(string key, T t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return redis.RemoveItemFromSortedSet(key, value);
            }
        }
        /// <summary>
        /// 修剪SortedSet
        /// </summary>
        /// <param name="key"></param>
        /// <param name="size">保留的条数</param>
        /// <returns></returns>
        public static int SortedSet_Trim(string key, int size)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.RemoveRangeFromSortedSet(key, size, 9999999);
            }
        }
        /// <summary>
        /// 获取SortedSet的长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int SortedSet_Count(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.GetSortedSetCount(key);
            }
        }

        /// <summary>
        /// 获取SortedSet的分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<T> SortedSet_GetList<T>(string key, int pageIndex, int pageSize)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var list = redis.GetRangeFromSortedSet(key, (pageIndex - 1) * pageSize, pageIndex * pageSize - 1);
                if (list != null && list.Count > 0)
                {
                    List<T> result = new List<T>();
                    foreach (var item in list)
                    {
                        var data = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                        result.Add(data);
                    }
                    return result;
                }
            }
            return null;
        }


        /// <summary>
        /// 获取SortedSet的全部数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<T> SortedSet_GetListALL<T>(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                var list = redis.GetRangeFromSortedSet(key, 0, 9999999);
                if (list != null && list.Count > 0)
                {
                    List<T> result = new List<T>();
                    foreach (var item in list)
                    {
                        var data = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                        result.Add(data);
                    }
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置缓存过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="datetime"></param>
        public static void SortedSet_SetExpire(string key, DateTime datetime)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                redis.ExpireEntryAt(key, datetime);
            }
        }

        //public static double SortedSet_GetItemScore<T>(string key,T t)
        //{
        //    using (IRedisClient redis = prcm.GetClient())
        //    {
        //        var data = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
        //        return redis.GetItemScoreInSortedSet(key, data);
        //    }
        //    return 0;
        //}

        #endregion

        #region Key/Value存储
        public static int AddValue(string key, string t)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.AppendToValue(key, t);
            }
        }

        /// <summary>
        /// 设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeout"></param>
        public static void SetExpire(string key, int timeout = 0)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                if (timeout >= 0)
                {
                    redis.ExpireEntryAt(key, DateTime.Now.AddSeconds(timeout));
                }
            }
        }
        /// <summary>
        /// 更新过期时间，默认30分钟
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeout"></param>
        public static void UpExpire(string key, int timeout = 1800)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                redis.ExpireEntryAt(key, DateTime.Now.AddSeconds(timeout));
            }
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存建</param>
        /// <param name="t">缓存值</param>
        /// <param name="timeout">过期时间，单位秒,-1：不过期，0：默认过期时间</param>
        /// <returns></returns>
        public static bool Set<T>(string key, T t, int timeout = -1)
        {
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    if (timeout > 0)
                    {
                        return redis.Set<T>(key, t, DateTime.Now.AddSeconds(timeout));
                    }
                    else if (timeout.Equals(0))
                    {
                        return redis.Set<T>(key, t, DateTime.Now.AddSeconds(secondsTimeOut));
                    }
                    else
                    {
                        return redis.Set<T>(key, t);
                    }
                }
            }
            catch (Exception ex)
            {
                // LogInfo
                return false;
            }
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.Get<T>(key);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Remove(string key)
        {
            using (IRedisClient redis = prcm.GetClient())
            {
                return redis.Remove(key);
            }
        }

        public static bool Add<T>(string key, T t, int timeout)
        {
            try
            {
                using (IRedisClient redis = prcm.GetClient())
                {
                    if (timeout.Equals(0))
                    {
                        return redis.Add<T>(key, t, DateTime.Now.AddSeconds(secondsTimeOut));
                    }
                    else if (timeout > 00)
                    {
                        return redis.Add<T>(key, t, DateTime.Now.AddSeconds(timeout));
                    }
                    else
                    {
                        return redis.Add<T>(key, t);
                    }
                }
            }
            catch (Exception ex)
            {
                // LogInfo
                return false;
            }
        }
        #endregion
        public static bool ExistsKey(string key)
        {
            //var redis = prcm.RedisClientFactory.CreateRedisClient();
            using (RedisClient redis = prcm.GetClient() as RedisClient)
            {
                return redis.Exists(key) == 0;
            }
        }
        public static long TTL(string key)
        {
            using (RedisClient redis = prcm.GetClient() as RedisClient)
            {
                return redis.Ttl(key);
            }
        }
    }
}
