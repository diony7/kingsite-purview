using System;
using System.Collections.Generic;

using System.Text;
using KingSite.BaseRepository;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using IBatisNet.DataMapper.Configuration.Statements;
using IBatisNet.Common;
using KingSite.Purview.Common;

namespace KingSite.Purview.Repository {
    internal class BaseProvider : IbatisBase {
        public BaseProvider(string connectionStringName, DBType dbType) : base("KingSite.Purview", connectionStringName, dbType) { }

        public BaseProvider() : base("KingSite.Purview", Config.GetConnectionName(), Config.GetDBType() ) { }

        protected void CPage(int pageIndex, int pageSize, int recordCount, out int startRow, out int endRow) {
            pageSize = Math.Abs(pageSize);
            int r = 0;
            int pageCount = Math.DivRem(recordCount, pageSize, out r);
            pageCount = r > 0 ? pageCount + 1 : pageCount;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            startRow = (pageIndex - 1) * pageSize;
            endRow = pageIndex * pageSize > recordCount ? recordCount : pageIndex * pageSize;
        }

        public DataSet QueryForDataSet(string statementName, object paramObject) {
            DataSet ds = new DataSet();
            ISqlMapper mapper = this.SqlMapper;
            IMappedStatement statement = mapper.GetMappedStatement(statementName);
            if (!mapper.IsSessionStarted) {
                mapper.OpenConnection();
            }
            RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
            statement.PreparedCommand.Create(scope, mapper.LocalSession, statement.Statement, paramObject);

            IDbCommand command = mapper.LocalSession.CreateCommand(CommandType.Text);
            command.CommandText = scope.IDbCommand.CommandText;
            //foreach (IDataParameter pa in scope.IDbCommand.Parameters) {
            //    command.Parameters.Add(new SqlParameter(pa.ParameterName, pa.Value));
            //} 
            mapper.LocalSession.CreateDataAdapter(command).Fill(ds);

            return ds;
        }

    }

 
}
