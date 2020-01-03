﻿using System;
using System.Data;

namespace AspNetCore.Identity.Dapper
{
    /// <summary>
    /// A base class for all identity tables.
    /// </summary>
    public class IdentityTable : TableBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnectionFactory"></param>
        public IdentityTable(IDbConnectionFactory dbConnectionFactory) {
            if (dbConnectionFactory == null) {
                throw new ArgumentNullException(nameof(dbConnectionFactory));
            }
            DbConnection = dbConnectionFactory.Create();
        }

        /// <summary>
        /// The type of the database connection class used to access the store.
        /// </summary>
        protected IDbConnection DbConnection { get; }

        /// <inheritdoc/>
        protected override void OnDispose() {
            if (DbConnection != null) {
                DbConnection.Dispose();
            }
        }
    }
}