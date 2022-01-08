using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_File_Application.Model
{
    [ElasticsearchType(RelationName = "file_info")]
    class File
    {
        public string Id { get; set; }

        public string Path { get; set; }

        public bool isFolder { get; set; }

        public string Name { get; set; }

        [Keyword]
        public string Content { get; set; }

        [Date(Format = "MMddyyyy")]
        public DateTime DateCreate { get; set; }

        public string Extension { get; set; }
    }
}
