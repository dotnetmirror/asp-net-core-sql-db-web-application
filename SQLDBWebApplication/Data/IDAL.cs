using DotnetMirror.SQLDBWebApplication.Models;

namespace DotnetMirror.SQLDBWebApplication.Data
{
    public interface IDAL
    {
        List<Cert> ListCertfications();
        Cert GetCertfication(string id);
        void Save(Cert cert);

        void Delete(string code);
    }

}