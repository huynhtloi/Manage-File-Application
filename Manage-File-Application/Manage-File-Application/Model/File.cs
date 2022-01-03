using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_File_Application.Models
{
    [ElasticsearchType(RelationName = "file_info")]
    class File
    {
        [Text(Name = "id")]
        public string Id { get; set; }

        [Text(Name = "path")]
        public string Path { get; set; }

        [Text(Name = "name_file")]
        public string Name { get; set; }

        [Text(Name = "content")]
        public string Content { get; set; }

        [Date(Format = "MMddyyyy")]
        public DateTime DateCreate { get; set; }

        [Text(Name = "extension")]
        public string Extension { get; set; }
    }
}
