using Manage_File_Application.DAL;
using Manage_File_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage_File_Application.Models;

namespace Manage_File_Application.ElasticCore
{
    class ElasticDAO
    {
        private ConnectionToES connect;
        public ElasticDAO()
        {
            connect = new ConnectionToES();
        }

        public List<File> SearchAll()
        {
            return connect.client.Search<File>().Documents.ToList();
        }

        public List<File> Search(string keyword)
        {
            List<File> response = null;
            response = connect.client.SearchAsync<File>(ele => ele
                                    .Query(qry => qry
                                        .QueryString(qryStr => qryStr
                                        .Query("*" + keyword + "*")
                                        .Fields(fs => fs.Fields(ff=>ff.Name, ff=>ff.Content))))).Result.Documents.ToList();
            return response;
        }
        public List<File> SearchByField(string field, string query)
        {
            List<File> response = null;

            field = field.ToLower();

            switch (field)
            {
                case "name":
                    response = connect.client.SearchAsync<File>(ele => ele
                                    .Query(qry => qry
                                        .QueryString(qryStr => qryStr
                                        .DefaultField(df => df.Name)
                                        .Query("*"+ query + "*")))).Result.Documents.ToList();
                    return response;

                case "content":
                    response = connect.client.SearchAsync<File>(ele => ele
                                    .Query(qry => qry
                                        .Bool(b => b
                                            .Must(m => m
                                                .Match(mc => mc
                                                    .Field(file => file.Content)
                                                    .Query(query)))))).Result.Documents.ToList();
                    return response;

                case "extension":
                    response = connect.client.SearchAsync<File>(ele => ele
                                    .Query(qry => qry
                                        .Bool(b => b
                                            .Must(m => m
                                                .Match(mc => mc
                                                    .Field(file => file.Extension)
                                                    .Query(query)))))).Result.Documents.ToList();
                    return response;
            }

            return null;
        }

        public async Task<bool> refreshRecords(File[] files)
        {
            var response = await connect.client.BulkAsync(b=>b.Index("manager_files").IndexMany<File>(files)
                       .Refresh(Elasticsearch.Net.Refresh.True));
            return CheckResponse(response);
        }

        public bool CheckResponse(Nest.IResponse response)
        {
            if ((response.ApiCall.HttpStatusCode == 201 || response.ApiCall.HttpStatusCode == 200) && response.ApiCall.Success == true)
            {
                return true;
            }
            return false;
        }

        //add new
        public async Task<bool> Create(File file)
        {
            var response = await connect.client.IndexAsync<File>(file, i => i
                       .Index("manager_files")
                       .Id(file.Id)
                       .Refresh(Elasticsearch.Net.Refresh.True));
            return CheckResponse(response);
        }


        //
        public async Task<bool> Delete(string id)
        {
            var response = await connect.client.DeleteAsync<File>(id, i => i
                .Index("manager_files")
                .Refresh(Elasticsearch.Net.Refresh.True));
            return CheckResponse(response);
        }

        //update
        public async Task<bool> Edit(string id, File file)
        {
            var response = await connect.client.UpdateAsync<File>(file, i => i
                       .Index("manager_files")
                       .Doc(file)
                       .Refresh(Elasticsearch.Net.Refresh.True));
            var abc = 2;
            return CheckResponse(response);
        }

        //search all
        public async Task<Nest.ISearchResponse<File>> Find(string SearchString)
        {
            var response = await connect.client.SearchAsync<File>(e => e
                .Index("manager_files")
                //.Size(1)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Name)
                        .Query(SearchString)
                    )
                )
            );

            return response;
        }

        public async Task<bool> DeleteAll()
        {
            var response = await connect.client.DeleteByQueryAsync<File>(del => del.Query(q => q.QueryString(qs => qs.Query("*"))));
            return CheckResponse(response);
        }
    }
}
