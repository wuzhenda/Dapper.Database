﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Database.Adapters;
using Dapper.Database.Mapper;

namespace Dapper.Database.Extensions
{
    /// <summary>
    ///     The Dapper.Database extensions for Dapper
    /// </summary>
    public static partial class SqlMapperExtensions
    {
        #region GetList Queries

        /// <summary>
        ///     Returns a list entities of type T.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>enumerable list of entities</returns>
        public static IEnumerable<T> GetList<T>(this IDbConnection connection, string sql = null,
            IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var sqlHelper = new SqlQueryHelper(typeof(T), connection);
            return connection.Query<T>(sqlHelper.Adapter.GetListQuery(sqlHelper.TableInfo, sql), null, transaction,
                commandTimeout: commandTimeout);
        }

        /// <summary>
        ///     Returns a list entities of type T.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">The parameters of the where clause to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<T> GetList<T>(this IDbConnection connection, string sql, object parameters,
            IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var sqlHelper = new SqlQueryHelper(typeof(T), connection);
            return connection.Query<T>(sqlHelper.Adapter.GetListQuery(sqlHelper.TableInfo, sql), parameters,
                transaction, commandTimeout: commandTimeout);
        }

        /// <summary>
        ///     Returns a list entities of type T.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<T1> GetList<T1, T2>(this IDbConnection connection, string sql, string splitOn = null,
            IDbTransaction transaction = null, int? commandTimeout = null) where T1 : class where T2 : class =>
            connection.Query<T1, T2>(sql, null, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<T1> GetList<T1, T2>(this IDbConnection connection, string sql, object parameters,
            string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class => connection.Query<T1, T2>(sql, parameters, transaction,
            commandTimeout: commandTimeout, splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<T1> GetList<T1, T2, T3>(this IDbConnection connection, string sql,
            string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class => connection.Query<T1, T2, T3>(sql, new { },
            transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<T1> GetList<T1, T2, T3>(this IDbConnection connection, string sql, object parameters,
            string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class => connection.Query<T1, T2, T3>(sql, parameters,
            transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));


        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<T1> GetList<T1, T2, T3, T4>(this IDbConnection connection, string sql,
            string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where T4 : class => connection.Query<T1, T2, T3, T4>(sql,
            new { }, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<T1> GetList<T1, T2, T3, T4>(this IDbConnection connection, string sql,
            object parameters, string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where T4 : class => connection.Query<T1, T2, T3, T4>(sql,
            parameters, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<TRet> GetList<T1, T2, TRet>(this IDbConnection connection, Func<T1, T2, TRet> mapper,
            string sql, string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where TRet : class => connection.Query(sql, mapper, null, transaction,
            commandTimeout: commandTimeout, splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<TRet> GetList<T1, T2, TRet>(this IDbConnection connection, Func<T1, T2, TRet> mapper,
            string sql, object parameters, string splitOn = null, IDbTransaction transaction = null,
            int? commandTimeout = null) where T1 : class where T2 : class where TRet : class => connection.Query(sql,
            mapper, parameters, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<TRet> GetList<T1, T2, T3, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, TRet> mapper, string sql, string splitOn = null, IDbTransaction transaction = null,
            int? commandTimeout = null) where T1 : class where T2 : class where T3 : class where TRet : class =>
            connection.Query(sql, mapper, new { }, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<TRet> GetList<T1, T2, T3, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, TRet> mapper, string sql, object parameters, string splitOn = null,
            IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where TRet : class => connection.Query(sql, mapper,
            parameters, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));


        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<TRet> GetList<T1, T2, T3, T4, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, T4, TRet> mapper, string sql, string splitOn = null, IDbTransaction transaction = null,
            int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where T4 : class where TRet : class => connection.Query(
            sql, mapper, new { }, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static IEnumerable<TRet> GetList<T1, T2, T3, T4, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, T4, TRet> mapper, string sql, object parameters, string splitOn = null,
            IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where T4 : class where TRet : class => connection.Query(
            sql, mapper, parameters, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        #endregion

        #region GetListAsync Queries

        /// <summary>
        ///     Returns a list entities of type T.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>enumerable list of entities</returns>
        public static async Task<IEnumerable<T>> GetListAsync<T>(this IDbConnection connection, string sql = null,
            IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var adapter = GetFormatter(connection);
            return await connection.GetListImplAsync<T>(adapter, sql, null, transaction, commandTimeout);
        }

        /// <summary>
        ///     Returns a list entities of type T.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">The parameters of the where clause to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<T>> GetListAsync<T>(this IDbConnection connection, string sql,
            object parameters, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var adapter = GetFormatter(connection);
            return await connection.GetListImplAsync<T>(adapter, sql, parameters, transaction, commandTimeout);
        }


        /// <summary>
        ///     Returns a list entities of type T.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<T1>> GetListAsync<T1, T2>(this IDbConnection connection, string sql,
            string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class => await connection.QueryAsync<T1, T2>(sql, null, transaction,
            commandTimeout: commandTimeout, splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<T1>> GetListAsync<T1, T2>(this IDbConnection connection, string sql,
            object parameters, string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class => await connection.QueryAsync<T1, T2>(sql, parameters, transaction,
            commandTimeout: commandTimeout, splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<T1>> GetListAsync<T1, T2, T3>(this IDbConnection connection, string sql,
            string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class => await connection.QueryAsync<T1, T2, T3>(sql, new { },
            transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<T1>> GetListAsync<T1, T2, T3>(this IDbConnection connection, string sql,
            object parameters, string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class => await connection.QueryAsync<T1, T2, T3>(sql,
            parameters, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));


        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<T1>> GetListAsync<T1, T2, T3, T4>(this IDbConnection connection,
            string sql, string splitOn = null, IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where T4 : class =>
            await connection.QueryAsync<T1, T2, T3, T4>(sql, new { }, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        /// <summary>
        ///     Returns a list entities of type T1.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<T1>> GetListAsync<T1, T2, T3, T4>(this IDbConnection connection,
            string sql, object parameters, string splitOn = null, IDbTransaction transaction = null,
            int? commandTimeout = null) where T1 : class where T2 : class where T3 : class where T4 : class =>
            await connection.QueryAsync<T1, T2, T3, T4>(sql, parameters, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<TRet>> GetListAsync<T1, T2, TRet>(this IDbConnection connection,
            Func<T1, T2, TRet> mapper, string sql, string splitOn = null, IDbTransaction transaction = null,
            int? commandTimeout = null) where T1 : class where T2 : class => await connection.QueryAsync(sql, mapper,
            null, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<TRet>> GetListAsync<T1, T2, TRet>(this IDbConnection connection,
            Func<T1, T2, TRet> mapper, string sql, object parameters, string splitOn = null,
            IDbTransaction transaction = null, int? commandTimeout = null) where T1 : class where T2 : class =>
            await connection.QueryAsync(sql, mapper, parameters, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<TRet>> GetListAsync<T1, T2, T3, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, TRet> mapper, string sql, string splitOn = null, IDbTransaction transaction = null,
            int? commandTimeout = null) where T1 : class where T2 : class where T3 : class where TRet : class =>
            await connection.QueryAsync(sql, mapper, new { }, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<TRet>> GetListAsync<T1, T2, T3, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, TRet> mapper, string sql, object parameters, string splitOn = null,
            IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where TRet : class => await connection.QueryAsync(sql,
            mapper, parameters, transaction, commandTimeout: commandTimeout,
            splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3) }));


        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<TRet>> GetListAsync<T1, T2, T3, T4, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, T4, TRet> mapper, string sql, string splitOn = null, IDbTransaction transaction = null,
            int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where T4 : class where TRet : class =>
            await connection.QueryAsync(sql, mapper, new { }, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        /// <summary>
        ///     Returns a list entities of type TRet.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="mapper">Open SqlConnection</param>
        /// <param name="sql">The where clause to delete</param>
        /// <param name="parameters">Parameters of the clause</param>
        /// <param name="splitOn">The field we should split the result on to return the next object</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<IEnumerable<TRet>> GetListAsync<T1, T2, T3, T4, TRet>(this IDbConnection connection,
            Func<T1, T2, T3, T4, TRet> mapper, string sql, object parameters, string splitOn = null,
            IDbTransaction transaction = null, int? commandTimeout = null)
            where T1 : class where T2 : class where T3 : class where T4 : class where TRet : class =>
            await connection.QueryAsync(sql, mapper, parameters, transaction, commandTimeout: commandTimeout,
                splitOn: splitOn ?? SplitOnArgument(new[] { typeof(T2), typeof(T3), typeof(T4) }));

        /// <summary>
        ///     Returns a list entities of type T.
        /// </summary>
        /// <param name="connection">Sql Connection</param>
        /// <param name="adapter">ISqlAdapter for getting the sql statement</param>
        /// <param name="sql">The where clause</param>
        /// <param name="parameters">Parameters of the where clause</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>True if records are deleted</returns>
        private static async Task<IEnumerable<T>> GetListImplAsync<T>(this IDbConnection connection,
            ISqlAdapter adapter, string sql, object parameters, IDbTransaction transaction = null,
            int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            var tableInfoCache = TableInfoCache(type);
            var selectSql = adapter.GetListQuery(tableInfoCache, sql);
            return await connection.QueryAsync<T>(selectSql, parameters, transaction, commandTimeout);
        }

        #endregion
    }
}
