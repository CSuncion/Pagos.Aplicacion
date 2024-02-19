using Microsoft.Extensions.Configuration;

namespace Pagos.CrossCutting.Configs
{
    public class AppConfiguration
    {

        private readonly IConfiguration _configInfo;
        public AppConfiguration(IConfiguration configInfo)
        {
            _configInfo = configInfo;
        }
        public string ConexionDBPagos
        {
            get
            {
                return _configInfo["dbVenta-cnx"];
            }
            private set { }
        }
        public string UrlBaseServicioStock
        {
            get
            {
                return _configInfo["url-base-servicio-stock"];
            }
            private set { }
        }
        public string LogMongoServerDB
        {
            get
            {
                return _configInfo["log-mongo-server-db"];
            }
            private set { }
        }
        public string LogMongoDbCollection
        {
            get
            {
                return _configInfo["log-mongo-db-collection"];
            }
            private set { }
        }
    }
}
