using Manage_File_Application.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Example connection to elastic search
namespace Manage_File_Application.DAL
{
    class ConnectionToES
    {

        /// Elastic settings
        private ConnectionSettings settings;

        /// Current instantiated client
        public ElasticClient client { get; set; }

        /// Constructor
        public ConnectionToES()
        {
            var node = new Uri("http://180.93.172.126:9200");
            settings = new ConnectionSettings(node)
                .DefaultMappingFor<File>(i => i
                    .IndexName("files_manager_index")
                    .IdProperty(p => p.Id))
                .EnableDebugMode()
                .PrettyJson()
                .RequestTimeout(TimeSpan.FromMinutes(2));

            client = new ElasticClient(settings);
            
        }
    }
}
