using Manage_File_Application.DAL;
using Manage_File_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage_File_Application.Model;

namespace Manage_File_Application.ElasticCore
{
    class ElasticDAO
    {
        private ConnectionToES connect;
        public ElasticDAO()
        {
            connect = new ConnectionToES();
        }

        public List<File> SearchByField(int field, string query)
        {
            List<File> response = null;
            if (query.Equals("Enter some text here"))
            {
                response = connect.client.SearchAsync<File>(ele => ele
                                    .Index("files_manager_index")
                                    ).Result.Documents.ToList();
                return response;
            }
            switch (field)
            {
                case 0:
                    response = connect.client.SearchAsync<File>(ele => ele
                                    .Index("files_manager_index")
                                    .Query(qry => qry
                                        .QueryString(qryStr => qryStr
                                        .DefaultField(df => df.Name)
                                        .Query("*" + query + "*")))).Result.Documents.ToList();
                    return response;

                case 1:
                    response = connect.client.SearchAsync<File>(ele => ele
                                    .Index("files_manager_index")
                                    .Query(qry => qry
                                        .MatchPhrase(m=>m
                                            .Field(p => p.Content)
                                            .Query("*" + query + "*"))))
                                            .Result.Documents.ToList();
                    return response;
            }
            
            return null;
        }

        public bool CheckResponse(Nest.IResponse response)
        {
            if ((response.ApiCall.HttpStatusCode == 201 || response.ApiCall.HttpStatusCode == 200) && response.ApiCall.Success == true)
            {
                return true;
            }
            return false;
        }

        public bool Create(File file)
        {
            var response = connect.client.Index<File>(file, i => i
                       .Index("files_manager_index")
                       .Id(file.Id)
                       .Refresh(Elasticsearch.Net.Refresh.True));
            return CheckResponse(response);
        }

        public async Task<bool> Delete(string id)
        {
            var response = await connect.client.DeleteAsync<File>(id, i => i
                .Index("files_manager_index")
                .Refresh(Elasticsearch.Net.Refresh.True));
            return CheckResponse(response);
        }

        public async Task<bool> DeleteAll()
        {
            var response = await connect.client.DeleteByQueryAsync<File>(del => del.Query(q => q.QueryString(qs => qs.Query("*"))));
            return CheckResponse(response);
        }
    }
}
